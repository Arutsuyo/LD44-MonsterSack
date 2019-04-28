using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyAnimation : MonoBehaviour
{
    Animator animate;
    //EnemyDetection ed;
    bool hit;
    bool dead;
    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponentInParent<Animator>();
        //ed = GetComponent<EnemyDetection>();
        hit = false;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
            Debug.Log(other.gameObject);
        if (other.tag == "Player")
        {
            animate.SetBool("InMeleeRange", true);
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
