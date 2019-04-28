using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    public double hp;
    public int infectionRatio;

    [Header("UI Elements")]
    public Text hitpoints;
    public Text prompt;
    public Text dead;
    public Image fader;

    // Start is called before the first frame update
    void Start()
    {
        infectionRatio = 0;
        hp = 100;
        hitpoints.text = "HP: " + hp;
        prompt.text = "";
    }

    private void Update()
    {
        if (hp > 0)
            TakeDamage(1);
    }

    // Replace a body part
    void replaceBodyPart()  
    {
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
        hp -= damage;
        if(hp <= 0)
        {
            dead.gameObject.SetActive(true);
            StartCoroutine(FadeToBlack());
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