using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour
{
    /* [Range(-1f, 1.5f)]
     public float CurrentSpeed;*/
    [Tooltip("Average number of seconds between apperances")]
    public float seenEverySecond;
    private float CurrentSpeed;
    private GameObject currentTarget;
    private Animator animator;

	void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	void Update ()
    {
        transform.Translate(Vector3.left * CurrentSpeed * Time.deltaTime);
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void SetSpeed(float speed)
    {
        CurrentSpeed = speed;
    }
    // called from the animation at time of actual attack
    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
