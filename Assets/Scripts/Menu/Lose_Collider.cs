using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose_Collider : MonoBehaviour
{
    private Levelmanager levelmanager;

	void Start ()
    {
        levelmanager = GameObject.FindObjectOfType<Levelmanager>();
	}
		
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        levelmanager.loadLevel("03b_Lose");
    }
}
