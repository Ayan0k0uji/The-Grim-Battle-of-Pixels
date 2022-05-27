using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System;
using System.Text;
using System.Linq;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text JoinError;
    [SerializeField] private Text LogText;
    [SerializeField] private InputField inputField;
    private PhotonView photonView;
    private int P1 = 4;
    private int P2 = 4;
    [SerializeField] Image P1I;
    [SerializeField] Image P2I;
    [SerializeField] Sprite[] HeroesIcons = new Sprite[5];
    private bool PL1 = false;
    private bool plReady = false;
    private string roomID = "";
    private bool connectedToMaster = false;
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

    public void CreateRoom()
    {
        if (connectedToMaster && roomID == "")
        {
            PhotonNetwork.NickName = "Player1";
            PL1 = true;
            roomID = getUniqueID();
            Log(roomID);
            PhotonNetwork.CreateRoom(roomID, new Photon.Realtime.RoomOptions { MaxPlayers = 2 });
        }
    }

    public void JoinRoom()
    {
        if (connectedToMaster && inputField.textComponent.text != "")
        {
            PhotonNetwork.NickName = "Player2";
            string inputRoomID = inputField.textComponent.text;
            Log(inputRoomID);
            if (PhotonNetwork.JoinRoom(inputRoomID) == false) JoinError.text = "Room ID label is empty";
        }
        else
            JoinError.text = "Enter the room ID";
    }


    public override void OnJoinedRoom()
    {
        GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(6).gameObject.SetActive(false);
        photonView = PhotonView.Get(this);
        StartCoroutine("Baty");
        //PhotonNetwork.LoadLevel("GameScene");
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
        if (PL1)
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
        GameObject.Find("Canvas").transform.GetChild(9).gameObject.SetActive(true);
        StartCoroutine("Qwer");
    }

    [PunRPC]
    public void Send_Hero(int a)
    {
        if (PL1)
            P2 = a;
        else
            P1 = a;
    }

    public string getUniqueID()
    {
        StringBuilder builder = new StringBuilder();
        Enumerable.Range(65, 26).Select(e => ((char)e).ToString()).Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
            .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
            .OrderBy(e => Guid.NewGuid())
            .Take(10)
            .ToList().ForEach(e => builder.Append(e));
        return builder.ToString();
    }

    IEnumerator Baty()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                GameObject.Find("Canvas").transform.GetChild(8).gameObject.SetActive(true);
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
                if (PL1)
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
        if (PL1)
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
        GameObject.Find("Canvas").transform.GetChild(8).gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(6).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);
    }

    public void PlayerReady()
    {
        if (PL1)
        {
            GameObject.Find("Canvas").transform.GetChild(9).transform.GetChild(6).gameObject.SetActive(true);
            photonView.RPC("SetReady", PhotonNetwork.PlayerList[1]);
            StartCoroutine("StartMatch");
        }
        else
        {
            GameObject.Find("Canvas").transform.GetChild(9).transform.GetChild(7).gameObject.SetActive(true);
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
        if (PL1)
        {
            GameObject.Find("Canvas").transform.GetChild(9).transform.GetChild(7).gameObject.SetActive(true);
        }
        else
        {
            GameObject.Find("Canvas").transform.GetChild(9).transform.GetChild(6).gameObject.SetActive(true);
        }
    }
}
