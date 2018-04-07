using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour
{
    private Levelmanager levelmanager;

    void Start()
    {
        levelmanager = GameObject.FindObjectOfType<Levelmanager>();
    }

    private void OnMouseDown()
    {
        levelmanager.loadLevel("01a_Start_scene");
    }
}
