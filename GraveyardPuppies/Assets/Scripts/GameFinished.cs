using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFinished : MonoBehaviour
{
    public GameObject GameFinishedUI; // Tähän tulee pelin lopetuksen paneeli

    public bool GameIsFinished = false;

    public Controller allIsCollected;



    void Update()
    {
        GameFinishedPanel(); // Kutsutaan pelin lopetus funktiota
    }

    public void GameFinishedPanel()
    {
        if (allIsCollected.allBonesCollected == true)
        {
            GameIsFinished = true;
            GameFinishedUI.SetActive(true);
        }
    }
}
