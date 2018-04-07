using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Optionscontroller : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider difficultySlider;
    public Levelmanager levelmanager;

    private Musicmanager musicmanager;

	void Start ()
    {
        musicmanager = GameObject.FindObjectOfType<Musicmanager>();

        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	void Update ()
    {
        musicmanager.ChangeVolume(volumeSlider.value);
	}

    public void SetDefaults()
    {
       volumeSlider.value = 0.8f;
       difficultySlider.value = 1f;
    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);
        levelmanager.loadLevel("01a_Start_scene");
    }
}
