using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimation : MonoBehaviour
{
    public NavMeshAgent nma;
    public Animator animate;
    public TriggerEnemyAttack tea;

    public bool trackingRange = false;
    private GameObject player;

    void Start()
    {
        trackingRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (trackingRange)
        {
            nma.isStopped = false;
            nma.SetDestination(player.transform.position);
        }
        else
            nma.isStopped = true;
    }

    void OnTriggerEnter(Collider other)
    {
        //checks to see if the player has entered the melee collider.
        if (other.tag == "Player")
        {
            trackingRange = true;
            player = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            trackingRange = false;
        }
    }
}
