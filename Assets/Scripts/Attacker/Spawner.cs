using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] attackerPrefabArray;
    	
	void Update ()
    {
        foreach (GameObject thisAttacker in attackerPrefabArray)
        {
            if (isTimeToSpawn (thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
	}

    bool isTimeToSpawn(GameObject attackergameObject)
    {
        Attacker attacker = attackergameObject.GetComponent<Attacker>();
        float meanSpwandealy = attacker.seenEverySecond;
        float spawnPerSecond = 1 / meanSpwandealy;

        if (Time.deltaTime > meanSpwandealy)
        {
            Debug.LogError("Spwan rate capped");
        }

        float threshold = spawnPerSecond * Time.deltaTime/5;

        return (Random.value < threshold);
    }

    void Spawn(GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;
    }
}
