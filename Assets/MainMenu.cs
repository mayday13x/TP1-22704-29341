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
    public AudioSource main_sound;

    public void PlayGame()
    {
        // SceneManager.LoadScene(0);
        mainMenu.SetActive(false);
        player.Play();
        main_sound.loop = true;
        main_sound.Play();
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
        player.transform.position = new Vector3(0,2f, -90.7f);
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