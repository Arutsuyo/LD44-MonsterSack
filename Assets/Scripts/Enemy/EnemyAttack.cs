using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script pretains to the box collider to attack the player
//that is spawned from the enemy after the melee attack animation from the enemy.

public class EnemyAttack : MonoBehaviour
{
    public EnemyAnimation eAnim;
    [Header("Box Collider")]
    public Collider attackCollider;                            //box collider for enemy to attack.

    // Start is called before the first frame update
    void Start()
    {
        attackCollider = GetComponent<Collider>();
        attackCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update is called once per frame
    public void EnableTrigger()
    {
        Debug.Log("is hit Enemy Attack");
        attackCollider.enabled = true;
        Debug.Log("Collider Enabled");
        StartCoroutine("EnemyAttackDelay");            //if player is in the melee collider then start delay.
    }

    IEnumerator EnemyAttackDelay()
    {
        yield return new WaitForSeconds(0.5f);
        attackCollider.enabled = false;
        Debug.Log("Collider Disabled");
    }

    IEnumerator WaitToAttack()
    {
        yield return new WaitForSeconds(1);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().TakeDamage(15);
            attackCollider.enabled = false;
            StopCoroutine("EnemyAttackDelay");
            Debug.Log("Collider Disabled");
        }
    }
}
