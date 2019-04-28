using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script pretains to the box collider to attack the player
//that is spawned from the enemy after the melee attack animation from the enemy.

public class EnemyAttack : MonoBehaviour                        
{
    [Header ("Script References")]
    public EnemyAnimation ea;
    public Player player;

    [Header ("Box Collider")]
    public Collider attackCollider;                            //box collider for enemy to attack.

    // Start is called before the first frame update
    void Start()
    {
        ea = GetComponent<EnemyAnimation>();
        player = GetComponent<Player>();
        attackCollider = GetComponent<Collider>();
        attackCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ea.isHit == true)                                  //checks to see if the player has been hit.
        {
            attackCollider.enabled = true;
            StartCoroutine(EnemyAttackDelay());            //if player is in the melee collider then start delay.
            attackCollider.enabled = false;
        }
    }

    IEnumerator EnemyAttackDelay()
    {
        yield return new WaitForSeconds(0.5f);             //Waits for 0.5 secs.
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.TakeDamage(15);        //calls the Player script Take Damage function if player is in the spawned box collider.
        }
    }
}
