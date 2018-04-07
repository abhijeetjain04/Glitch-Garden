using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour
{
    private Musicmanager musicmanager;
    private float volume;

    void Start ()
    {
        musicmanager = GameObject.FindObjectOfType<Musicmanager>();
        if (musicmanager)
        {
            volume = PlayerPrefsManager.GetMasterVolume();
            musicmanager.ChangeVolume(volume);
        }
        else { Debug.LogError("Music manager not found"); }
	}
	
	
	void Update ()
    {
      
	}
}
