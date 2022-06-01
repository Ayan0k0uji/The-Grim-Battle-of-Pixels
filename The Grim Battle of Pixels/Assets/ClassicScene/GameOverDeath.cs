using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOverDeath : MonoBehaviour
{
    [SerializeField] DeathCounter deathCounter;
    [SerializeField] PauseScript pauseScr;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Image player1Label;
    [SerializeField] Image player2Label;
    private bool gameOver = false;

    private void Start()
    {

    }

    private void Update()
    {
        if ((deathCounter.GetDeathCountPlayer1() == 3 || deathCounter.GetDeathCountPlayer2() == 3) && !gameOver)
        {
            pauseScr.Pause();
            gameOverPanel.transform.gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(GameObject.Find("ButtonPlayAgain"));
            gameOver = true;
            if (deathCounter.GetDeathCountPlayer1() == 3)
            {
                player2Label.transform.gameObject.SetActive(true);
            }
            else
            {
                player1Label.transform.gameObject.SetActive(true);
            }
        }
    }

    public void playAgaingBA()
    {
        //pauseScr.Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void exitBA()
    {
        //pauseScr.Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public bool getGameOver() { return gameOver; }
}
