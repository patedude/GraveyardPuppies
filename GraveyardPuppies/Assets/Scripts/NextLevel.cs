using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public Controller allIsCollected;

    public GameObject arrowNextLevel; // Nuoli, mikä ei ole aktiivinen (eli ei ole näkyvissä)


    void Update()
    {
        if (allIsCollected.allBonesCollected == true)
        {
            arrowNextLevel.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.CompareTag("NextLevel")) // Nuoli on triggeri ja sille on tehty tagi nimeltä NextLevel
        {
            SceneManager.LoadScene(4); // Kun nuoleen osutaan, seuraava taso latautuu
        }
    }
}
