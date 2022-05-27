using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
//using System;
//using System.Text;
//using System.Linq;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text JoinError;
    [SerializeField] private Text CreateError;
    [SerializeField] private Text NameError;
    [SerializeField] private Text LogText;
    [SerializeField] private InputField JoinField;
    [SerializeField] private InputField CreateField;
    [SerializeField] private InputField NameField;
    private PhotonView photonView;
    private int P1 = 4;
    private int P2 = 4;
    [SerializeField] Image P1I;
    [SerializeField] Image P2I;
    [SerializeField] Sprite[] HeroesIcons = new Sprite[5];
    private string roomID = "";
    private bool host = false;
    private bool plReady = false;
    private bool connectedToMaster = false;
    private bool neqName = true;

    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        connectedToMaster = true;
        Log("Connected to Master");
    }

    public void ButtonCr()
    {
        PhotonNetwork.NickName = NameField.text;
        Log(PhotonNetwork.NickName);
        if (PhotonNetwork.NickName != "" && connectedToMaster)
        {
            NameField.transform.parent.gameObject.SetActive(false);
            CreateField.transform.parent.gameObject.SetActive(true);
        }
        else if (PhotonNetwork.NickName == "")
            NameError.text = "Enter Name";


    }

    public void ButtonJ()
    {
        PhotonNetwork.NickName = NameField.text;
        Log(PhotonNetwork.NickName);
        if (PhotonNetwork.NickName != "" && connectedToMaster)
        {
            NameField.transform.parent.gameObject.SetActive(false);
            JoinField.transform.parent.gameObject.SetActive(true);
        }
    }

    public void CreateRoom()
    {
        if (connectedToMaster && CreateField.textComponent.text != "")
        {
            host = true;
            roomID = CreateField.textComponent.text;
            Log(roomID);
            PhotonNetwork.CreateRoom(roomID, new Photon.Realtime.RoomOptions { MaxPlayers = 2 });
        }
    }

    public void JoinRoom()
    {
        if (connectedToMaster && JoinField.textComponent.text != "")
        {
            string inputRoomID = JoinField.textComponent.text;
            Log(inputRoomID);
            if (PhotonNetwork.JoinRoom(inputRoomID) == false) JoinError.text = "Room Name label is empty";
        }
        else
            JoinError.text = "Enter the room Name";
    }


    public override void OnJoinedRoom()
    {
        if (!host && PhotonNetwork.PlayerList[0].NickName == PhotonNetwork.NickName)
        {
            PhotonNetwork.LeaveRoom();
            neqName = false;
            JoinError.text = "Nicknames are repeated";
        }
        else
        {
            neqName = true;
        }

        if (host && neqName)
        {
            GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(8).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(12).gameObject.SetActive(true);
            photonView = PhotonView.Get(this);
            StartCoroutine("Baty");
        } 
        else if(neqName)
        {
            GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(9).gameObject.SetActive(false);
            photonView = PhotonView.Get(this);
            StartCoroutine("Baty");
        }
        //PhotonNetwork.LoadLevel("GameScene");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        CreateError.text = message;
    }
    

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        JoinError.text = message;
    }

    private void Log(string asf)
    {
        Debug.Log(asf);
        LogText.text += "\n";
        LogText.text += asf;
    }

    public void Select(int chrP)
    {
        if (host)
        {
            photonView.RPC("Send_Hero", PhotonNetwork.PlayerList[1], (object)chrP);
            P1 = chrP;
            P1I.sprite = HeroesIcons[P1];
        }
        else
        {
            photonView.RPC("Send_Hero", PhotonNetwork.PlayerList[0], (object)chrP);
            P2 = chrP;
            P2I.sprite = HeroesIcons[P2];
        }
        GameObject.Find("Canvas").transform.GetChild(11).gameObject.SetActive(true);
        StartCoroutine("Qwer");
    }

    [PunRPC]
    public void Send_Hero(int a)
    {
        if (host)
            P2 = a;
        else
            P1 = a;
    }

    /*public string getUniqueID()
    {
        StringBuilder builder = new StringBuilder();
        Enumerable.Range(65, 26).Select(e => ((char)e).ToString()).Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
            .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
            .OrderBy(e => Guid.NewGuid())
            .Take(10)
            .ToList().ForEach(e => builder.Append(e));
        return builder.ToString();
    }*/

    IEnumerator Baty()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                GameObject.Find("Canvas").transform.GetChild(12).gameObject.SetActive(false);
                GameObject.Find("Canvas").transform.GetChild(10).gameObject.SetActive(true);
                break;
            }
        }
    }

    IEnumerator Qwer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            if (P1 != 4 && P2 != 4)
            {
                if (host)
                {
                    P2I.sprite = HeroesIcons[P2];
                }
                else
                {
                    P1I.sprite = HeroesIcons[P1];
                }
                break;
            }
        }
    }

    public void LeaveRoomButton()
    {
        if (host)
        {
            photonView.RPC("LeaveRoomPl", PhotonNetwork.PlayerList[1]);
        }
        else
        {
            photonView.RPC("LeaveRoomPl", PhotonNetwork.PlayerList[0]);
        }
        roomID = "";
        PhotonNetwork.LeaveRoom();
    }

    [PunRPC]
    public void LeaveRoomPl()
    {
        roomID = "";
        PhotonNetwork.LeaveRoom();
        GameObject.Find("Canvas").transform.GetChild(11).gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(10).gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(6).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);
    }

    public void PlayerReady()
    {
        if (host)
        {
            GameObject.Find("Canvas").transform.GetChild(11).transform.GetChild(6).gameObject.SetActive(true);
            photonView.RPC("SetReady", PhotonNetwork.PlayerList[1]);
            StartCoroutine("StartMatch");
        }
        else
        {
            GameObject.Find("Canvas").transform.GetChild(11).transform.GetChild(7).gameObject.SetActive(true);
            photonView.RPC("SetReady", PhotonNetwork.PlayerList[0]);
        }
    }

    IEnumerator StartMatch()
    {
        while (true)
        {
            if (plReady)
            {
                PhotonNetwork.LoadLevel("GameScene");
                break;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    [PunRPC]
    private void SetReady()
    {
        plReady = true;
        if (host)
        {
            GameObject.Find("Canvas").transform.GetChild(11).transform.GetChild(7).gameObject.SetActive(true);
        }
        else
        {
            GameObject.Find("Canvas").transform.GetChild(11).transform.GetChild(6).gameObject.SetActive(true);
        }
    }

    public void Button3()
    {
        PhotonNetwork.LeaveRoom();
        StopCoroutine("Baty");
    }
}
