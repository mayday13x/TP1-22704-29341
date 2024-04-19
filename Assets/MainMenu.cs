using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public Player player;
    public void PlayGame()
    {
        // SceneManager.LoadScene(0);
        mainMenu.SetActive(false);
        player.Play();

    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
         Application.Quit();
    }

}
