using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    [Header("Attach per enemy")]
    public GameObject model;
    public double damagePerHit = 20;
    public float swingTimer = 3f;

    [Header("Navigation")]
    public NavMeshAgent nma;
    public GameObject detectorObj;
    public GameObject AttackRangeObj;
    public GameObject hitboxObj;
    public bool trackingRange = false;
    public bool meleeRange = false;

    private Detection detection;
    private MeleeRange melee;
    private Hitbox hitbox;
    private bool canSwing;

    private Animator animator;
    private GameObject playerGO;
    private Player playercs;

    void Start()
    {
        // Get the models animator
        animator = model.GetComponent<Animator>();

        // Get detection references
        detection = detectorObj.GetComponent<Detection>();
        melee = AttackRangeObj.GetComponent<MeleeRange>();
        hitbox = hitboxObj.GetComponent<Hitbox>();

        // Put the enemy into idle
        trackingRange = false;
        meleeRange = false;
        canSwing = true;
        animator.SetBool("InRange", false);
        animator.SetBool("InMeleeRange", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (trackingRange)
        {
            nma.isStopped = false;
            nma.SetDestination(playerGO.transform.position);
            if(meleeRange)
            {
                if (canSwing)
                {
                    canSwing = false;
                    hitboxObj.SetActive(true);
                    animator.SetBool("InMeleeRange", true);
                }
            }
        }
        else
        {
            meleeRange = false;
            canSwing = true;
            nma.isStopped = true;
            animator.SetBool("InRange", false);
            animator.SetBool("InMeleeRange", false);
        }
    }

    public void OnDetectEnter(Collider other)
    {
        //checks to see if the player has entered the melee collider.
        trackingRange = true;
        playerGO = other.gameObject;
        playercs = playerGO.GetComponent<Player>();
        animator.SetBool("InRange", true);
    }

    public void OnDetectExit(Collider other)
    {
        trackingRange = false;
        animator.SetBool("InRange", false);
    }

    public void OnMeleeEnter(Collider other)
    {
        meleeRange = true;
    }

    public void OnMeleeExit(Collider other)
    {
        meleeRange = false;
        animator.SetBool("InMeleeRange", false);
    }

    public void OnHitEnter(Collider other)
    {
        hitboxObj.SetActive(false);
        StartCoroutine(SwingDelay());
        animator.SetBool("InMeleeRange", false);
    }

    private IEnumerator SwingDelay()
    {
        yield return new WaitForSeconds(0.5f);
        playercs.TakeDamage(damagePerHit);
        if(swingTimer - 0.5f > 0)
            yield return new WaitForSeconds(swingTimer - 0.5f);
        canSwing = true;
    }
}
