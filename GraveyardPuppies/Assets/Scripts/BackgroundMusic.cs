using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    static bool AudioBegin = false;
    void Awake()
    {
        if (!AudioBegin)
        {
            GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }
}
