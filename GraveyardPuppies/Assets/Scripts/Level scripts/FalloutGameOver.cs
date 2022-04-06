using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalloutGameOver : MonoBehaviour
{
    public Transform respawn; // Tähän respawnaus kohta
    public Transform falling; // Tähän tason alle tehty boxi, mihin osuessa hahmo on pudonnut
    public Text livesText; // Elämät-laskuri tähän

    public GameObject GameOverUI;
    public GameObject Tombstone;

    private int lives;

    public bool GameIsOver = false;

   // public LevelTwoScript GameFinishedCheck; // Kutsutaan toista scriptiä

    void Awake()
    {
        lives = 3; // Tason alussa 3 elämää
        SetLivesText(); // Elämälaskurifunktion kutsu
    }

    //*********************** Erilaisia funktioita ***********************//

    public void GameOver()
    {
        GameIsOver = true;
        GameOverUI.SetActive(true);
        Tombstone.SetActive(true);
        Time.timeScale = 0f; // Aika pysähtyy
    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
    }

    //*********************** Hahmon putoaminen ***********************//

        /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == falling)
        {
            // Jos elämiä enemmäin kuin 0
            if (lives > 0)
            {
                transform.position = respawn.position; // Hahmo respawnautuu määritettyyn kohtaan
                if (GameFinishedCheck.GameIsFinished == true) // Tarkistetaan toisesta scripitistä jos peli on loppunut
                {
                    SetLivesText(); // Elämät ei enää vähene, vaikka tippuisi alas, eli Game over ei voi aktivoitua kun peli on loppunut
                }
                else if (GameFinishedCheck.GameIsFinished == false) // Tarkistetaan toisesta scripitistä jos peli ei ole loppunut
                {
                    lives = lives - 1; // Tippuessa yksi elämä vähenee
                    SetLivesText();
                }
            }
            else if (lives <= 0) // Jos elämiä on alle 0 tai 0
            {
                if (GameFinishedCheck.GameIsFinished == true) // Tarkistetaan toisesta scripitistä jos peli on loppunut
                {
                    transform.position = respawn.position; // Hahmo respawnautuu määritettyyn kohtaan
                    SetLivesText(); // Elämät ei enää vähene, vaikka tippuisi alas, eli Game over ei voi aktivoitua kun peli on loppunut
                }
                else if (GameFinishedCheck.GameIsFinished == false) // Tarkistetaan toisesta scripitistä jos peli ei ole loppunut
                {
                    // Peli ei ole loppunut, joten aktivoituu GameOver funktio
                    GameOver();
                }
            }
        }   
    }*/
}
