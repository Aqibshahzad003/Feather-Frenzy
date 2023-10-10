using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGsound : MonoBehaviour
{
    private static BGsound instance;

    public AudioSource bgSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        bgSound.Play();
    }
}
