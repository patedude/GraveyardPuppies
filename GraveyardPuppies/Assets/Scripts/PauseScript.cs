using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PauseScript : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenu;
    public GameObject PauseButton;
    public GameObject ExitButton;
    

    // Kutsutaan toisia scriptejä
    //public FalloutGameOver GameOverCheck;
    //public LevelTwoScript GameFinishedCheck;
    /*
    void Update()
    {
        // Escistä avautuu ja sulkeutuu pausemenu JOS peli ei ole game over tilassa EIKÄ peli ole loppunut
        if (Input.GetKeyDown(KeyCode.Escape) && GameOverCheck.GameIsOver == false && GameFinishedCheck.GameIsFinished == false) // tarkistetaan toisesta scriptistä
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }*/

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Pause"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (CrossPlatformInputManager.GetButtonDown("Exit"))
        {
            Resume();
        }
    }

    public void Resume()
    {
        // Resumesta klikkaamalla peli jatkuu, kilkkailut on laitettu käyttöliittymän puolelta
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        // Pausen funktio, aika pysähtyy
        PauseMenu.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        // Menusta klikkaamalla peli menee aloitusvalikkoon, kilkkailut on laitettu käyttöliittymän puolelta
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        // Quit klikkaamalla peli loppuu, kilkkailut on laitettu käyttöliittymän puolelta
        Application.Quit();
    }
}
