using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstPause : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenu;

    void Update()
    {
        // Escistä avautuu ja sulkeutuu pausemenu
        if (Input.GetKeyDown(KeyCode.Escape))
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
    }

    public void Resume()
    {
        // Resumesta klikkaamalla peli jatkuu, kilkkailut on laitettu käyttöliittymän puolelta
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        // Pausen funktio, aika pysähtyy
        PauseMenu.SetActive(true);
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
