using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject GameOverMenu;
    public GameObject Score;

    public Player player;
    public Animator animator;
    public Score score;
    public void PlayGame()
    {
        // SceneManager.LoadScene(0);
        mainMenu.SetActive(false);
        player.Play();
        Debug.Log("Playgame");

    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        // player.transform.position = Vector3.zero;
        score.Score_ = 0;
        player.transform.position = new Vector3(0,2f,0);
        player.GetComponent<Animator>().Play("Running");
        GameOverMenu.SetActive(false);
       // Score.SetActive(true);
        PlayGame();
    }

    public void QuitGame()
    {
         Application.Quit();
    }

}
