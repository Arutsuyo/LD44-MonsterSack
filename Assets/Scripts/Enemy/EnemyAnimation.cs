using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    Animator animate;                                   //animator for enemy animations.
    public bool isHit;                                  // checks if the player has been hit.
    bool hit;                                           //checks if the enemy has been hit.
    bool dead;                                          //checks if the enemy is dead.

    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponentInParent<Animator>();
        hit = false;
        dead = false;
        isHit = false;
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")                          //checks to see if the player has entered the melee collider.
        {
            animate.SetBool("InMeleeRange", true);
            isHit = true;
        }
        else if(hit == true)
        {
            animate.SetTrigger("TakeDamage");
        }
        else if(dead == true)
        {
            animate.SetTrigger("Dead");
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            animate.SetBool("InMeleeRange", false);
        }
    }
}
