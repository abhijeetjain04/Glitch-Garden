using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicmanager : MonoBehaviour
{
    public AudioClip[] LevelMusicChangeArray;
    private AudioSource audioScorce;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audioScorce = GetComponent<AudioSource>();
        audioScorce.volume = PlayerPrefsManager.GetMasterVolume();
    }

    private void OnLevelWasLoaded(int level)
    {
        if (LevelMusicChangeArray[level])
        {
            audioScorce.clip = LevelMusicChangeArray[level];
            audioScorce.loop = true;
            audioScorce.Play();
        }
    }

    public void ChangeVolume(float value)
    {
        audioScorce.volume = value;
    }

}
