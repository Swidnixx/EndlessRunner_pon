using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    #region Singleton
    public static SoundManager instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
    #endregion

    AudioSource audioSource;
    public bool muted;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleMuted()
    {
        muted = !muted;
    }
}
