using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class MenuScript : MonoBehaviour
{
    //public enum characterList { character1, character2, character3, character4, character5 };
    public static int P1;
    public static int P2;
    private bool gameMode = false;
    [SerializeField] Sprite[] HeroesIcons = new Sprite[5];
    [SerializeField] Image P1I;
    [SerializeField] Image P2I;
    

    GameObject lastSelectedGO;

    public int getP1() { return P1; }
    public int getP2() { return P2; }

    //P1 - true; P2 - flase
    public void CharacterChooseP1Button(int chrP)
    {
        //EventSystem.current.SetSelectedGameObject(null);
        //lastSelectedGO = GameObject.Find("Charecter1pl2");
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Charecter1pl2"));
        P1 = chrP;
        P1I.sprite = HeroesIcons[P1];
    }

    public void CharacterChooseP2Button(int chrP)
    {
        //EventSystem.current.SetSelectedGameObject(null);
        //lastSelectedGO = GameObject.Find("StartPlayButton");
        EventSystem.current.SetSelectedGameObject(GameObject.Find("StartPlayButton"));
        P2 = chrP;
        P2I.sprite = HeroesIcons[P2];
    }

    public void NormalModeButton()
    {
        //EventSystem.current.SetSelectedGameObject(null);
        //lastSelectedGO = GameObject.Find("Charecter1pl1");
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Charecter1pl1"));
        gameMode = false;
    }

    public void EventModeButton()
    {
        //EventSystem.current.SetSelectedGameObject(null);
        //lastSelectedGO = GameObject.Find("Charecter1pl1");
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Charecter1pl1"));
        gameMode = true;
    }

    public void PlayGameButton()
    {
        if (gameMode)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void ForSelectButton(GameObject s)
    {
        //EventSystem.current.SetSelectedGameObject(null);
        //lastSelectedGO = s;
        EventSystem.current.SetSelectedGameObject(s);
    }

    public void Awake()
    {
        //P1I = GameObject.Find("MImageP1").GetComponent<Image>();
        //P2I = GameObject.Find("MImageP2").GetComponent<Image>();
    }

    public void Start()
    {
        
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        lastSelectedGO = GameObject.Find("PlayButton"); 
    }

    public void Update()
    {
        //EventSystem.current.SetSelectedGameObject(lastSelectedGO);
    }
}
