using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Laskurit yms käyttöön
using UnityEngine.SceneManagement; // Toiseen tasoon pääsemiset

public class Controller : MonoBehaviour
{
    public Text countText; // Tähän vedetään luiden laskuri
    public int count; // Laskee kerätyt luut
    public int maxBones; // Levelistä riippuva
    public bool allBonesCollected;

    // Näitä tarvitaan luiden keräämisen ääniin
    public AudioClip SoundEffect;
    private AudioSource source;

    

    void Awake()
    {
        count = 0;
        source = GetComponent<AudioSource>();
        SetCountText(); // Laskurin funktio 
    }

    void Update()
    {
        allBonesCollected = false;
        AllBones();
    }

    void AllBones()
    {
        if (count == maxBones)
        {
            allBonesCollected = true;
        }
    }

    //*********************** KERÄTTÄVIEN ESINEIDEN LASKURIN FUNKTIO ***********************//

    void SetCountText()
    {
        countText.text = "Bones: " + count.ToString() + "/" + maxBones; // Näkyy teksti ja kerättyjen esineiden määrä
    }


    //*********************** LUIDEN KERÄÄMISEN/SEURAAVAAN TASOON SIIRTYMISEN FUNKTIO ***********************//

    void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.CompareTag("BonesTwo")) // Luut ovat triggereitä ja niille on tehty tagi nimeltä PickUp
        {
            source.PlayOneShot(SoundEffect); // Ääniefekti soitetaan
            Collider.gameObject.SetActive(false); // Jos luuhun osutaan, se poistetaan näkyvistä eli se ei ole sitten aktiivinen, eli se ei enää näy pelissä
            count = count + 2; // Yhteenlaskettu summa plus kerätty uusi luu
            SetCountText(); // Ilman tätä laskuri ei päivity
        }
        else if (Collider.gameObject.CompareTag("BonesThree")) // Luut ovat triggereitä ja niille on tehty tagi nimeltä PickUp
        {
            source.PlayOneShot(SoundEffect); // Ääniefekti soitetaan
            Collider.gameObject.SetActive(false); // Jos luuhun osutaan, se poistetaan näkyvistä eli se ei ole sitten aktiivinen, eli se ei enää näy pelissä
            count = count + 3; // Yhteenlaskettu summa plus kerätty uusi luu
            SetCountText(); // Ilman tätä laskuri ei päivity
        }

    }
}
