using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager audioManager;

    void Awake()
    {
        if (audioManager)
        {
            DestroyImmediate(this);
        }
        else
        {
            DontDestroyOnLoad(this);
            audioManager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
