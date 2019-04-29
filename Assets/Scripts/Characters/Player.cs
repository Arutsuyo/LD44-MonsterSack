using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    [Header("Player Info")]
    public double hp;
    public int infectionRatio;
    public bool attacked = false;
    public float attackSpeed = 0.5f;

    [Header("UI Elements")]
    public bool showInv = false;
    public Text hitpoints;
    public Text prompt;
    public Text dead;
    public Image fader;

    [Header("Script References")]
    public Inventory inv;
    public HingeJoint trashBag;
    public GameObject trashHit;

    [Header("Audio Clips")]
    public AudioSource hitSound;
    public AudioClip[] hitSounds;
    private JointMotor jm;
    // Start is called before the first frame update
    void Start()
    {
        infectionRatio = 0;
        hp = 100;
        hitpoints.text = "HP: " + hp;
        prompt.text = "";
        jm = trashBag.motor;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            showInv = !showInv;

        }
        if (Input.GetKeyDown(KeyCode.Space) && !attacked)
        {
            Debug.Log("ATACKKKKKKKK");
            attacked = true;
            trashHit.SetActive(true);
            jm.targetVelocity = 20000;
            jm.force = 3000;
            trashBag.motor = jm;
            StartCoroutine("AttackMe");
        }
    }
    IEnumerator AttackMe()
    {
        yield return new WaitForSeconds(0.25f);
        jm.force = 0;
        jm.targetVelocity = 0;
        trashBag.motor = jm;
        trashHit.SetActive(false);
        yield return new WaitForSeconds(0.75f);
        attacked = false;
    }
    // Replace a body part
    void replaceBodyPart()  
    {
        if (showInv)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hp < 100)
            {
                prompt.text = "Limb replaced";
                hp = hp + 25;

                if (hp >= 80)
                {
                    hp = 100;
                }
            }
            else
                prompt.text = "MAX HEALTH";
            StartCoroutine(ClearPrompt());
        }
    }

    // Called by enemy script during their attack animation
    public void TakeDamage(double damage)
    {
        hitSound.PlayOneShot(hitSounds[Random.Range(0, 4)]);
        hp -= damage;
        if(hp <= 0)
        {
            // Make sure we're not dying twice
            if(!dead.gameObject.activeSelf)
            {
                dead.gameObject.SetActive(true);
                StartCoroutine(FadeToBlack());
            }
        }
    }

    public IEnumerator ClearPrompt()
    {
        yield return new WaitForSeconds(3.0f);
        prompt.text = "";
    }

    public IEnumerator FadeToBlack()
    {
        float startTime = Time.time;
        float curtime = 0;
        while(Time.time - startTime < 3)
        {
            curtime = Time.time - startTime;
            fader.color = new Color(fader.color.r,
                fader.color.g,
                fader.color.b,
                Mathf.Lerp(0.0f, 1, curtime / 3.0f));
            yield return null;
        }
    }
}