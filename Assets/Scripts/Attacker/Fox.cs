using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour
{
    private Animator anim;
    private Attacker attacker;

    void Start()
    {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // object ready to take gravestone
        GameObject obj = collision.gameObject; // object ready to take 

        if (!obj.GetComponent<Defender>())
        {
            return;
        }

        if (obj.GetComponent<Gravestone>())
        {
            anim.SetTrigger("jump trigger");
        }
        else
        {
            anim.SetBool("isAttacking", true);
            attacker.Attack(obj);
        }

    }
}
