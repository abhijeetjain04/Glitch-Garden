using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Timer : MonoBehaviour
{
    private float levelSeconds;
    private Slider GameTimer;
    private AudioSource audiosource;
    private bool isLevelEnd = false;
    private Levelmanager levelmanager;
    private GameObject WinText;
    private GameObject button;
    private GameObject spawn;
    private float difficulty_level;

	void Start ()
    {
        GameTimer = GetComponent<Slider>();
        audiosource = GetComponent<AudioSource>();
        levelmanager = GameObject.FindObjectOfType<Levelmanager>();
        button = GameObject.Find("Buttons");
        WinCondition();
        WinText.SetActive(false);
        difficulty_level = PlayerPrefsManager.GetDifficulty();
        SetTimerAsDifficulty();
	}
    void SetTimerAsDifficulty()
    {
        if (difficulty_level == 1)
        {
            levelSeconds = 50f;
        }
        if (difficulty_level == 2)
        {
            levelSeconds = 80f;
        }
        if (difficulty_level == 3)
        {
            levelSeconds = 100f;
        }
    }
    void WinCondition()
    {
        WinText = GameObject.Find("Win text");
        if (!WinText)
            Debug.LogWarning("Win lable not found");
    }
	
	void Update ()
    {
        GameTimer.value = Time.timeSinceLevelLoad / levelSeconds;
        if (Time.timeSinceLevelLoad >= levelSeconds && !isLevelEnd)
        {
            HandleWinCondition();
        }
	}

    void HandleWinCondition()
    {
        DestroyAllTaggedObject();
        audiosource.Play();
        WinText.SetActive(true);
        button.SetActive(false);
        Invoke("LoadNextLevel", audiosource.clip.length);
        isLevelEnd = true;
    }

    void DestroyAllTaggedObject()
    {
        GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("destroyOnWin");

        foreach (GameObject taggedObject in taggedObjectArray)
        {
            Destroy(taggedObject);
        }
    }

    void LoadNextLevel()
    {
        levelmanager.LoadNextLevel(); 
    }
}
