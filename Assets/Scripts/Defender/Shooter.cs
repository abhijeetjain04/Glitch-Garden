using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile, gun;

    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    void Start()
    {
        //animator = GameObject.FindObjectOfType<Animator>();
        animator = GetComponent<Animator>();

        // create a parent if necessary
        projectileParent = GameObject.Find("Projectile");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectile");
        }

        SetMylaneSpawner();
    }

    private void Update()
    {
        if (IsAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    //Look through all spawner and set mylaneSpanwer if found
    void SetMylaneSpawner()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawnerArray)
        {
            if (spawner.transform.position.y == this.transform.position.y)
            {
                myLaneSpawner = spawner;
                return;
            }
        }
        Debug.LogError(name + "cant find the spawner");
    }

    bool IsAttackerAheadInLane()
    {
        // Exit if no attacker
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }

        // If there are attacker , are they ahead ?
        foreach (Transform attackers in myLaneSpawner.transform)
        {
            if (attackers.transform.position.x > transform.position.x)
            {
                return true;
            }
        }

        // Attacker in lane , but not infornt
        return false;
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
