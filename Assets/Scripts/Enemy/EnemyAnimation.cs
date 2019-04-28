using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator animate;                                   //animator for enemy animations.
    public EnemyAttack eAtt;
    bool hit;                                           //checks if the enemy has been hit.
    bool dead;                                          //checks if the enemy is dead.
    public bool attAnimation;                                  //checks if the melee animation is running.

    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponentInParent<Animator>();
        hit = false;
        dead = false;
        attAnimation = false;
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")                          //checks to see if the player has entered the melee collider.
        {
            Debug.Log("player entered");
            animate.SetBool("InMeleeRange", true);
            attAnimation = true;
            eAtt.EnableTrigger();
            Debug.Log("is hit Enemy Animation");
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
