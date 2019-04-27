using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int infectionRatio;
    public double hp;
    public Text hitpoints;
    public Text infectRat;
    public Text prompt;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        infectionRatio = 0;
        hp = 100;
        hitpoints.text = "HP: " + hp;
        prompt.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        hitpoints.text = "HP: " + hp;
        replaceBodyPart();
    }

    void FixedUpdate()
    {
        inputMovement();
    }

    void inputMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            rb.AddForce(movement * speed);
        }
    }

    double HealthPoints()
    {
        return hp;
    }
    void replaceBodyPart()
    {
        if(Input.GetKey(KeyCode.E))
        {
            if (hp < 100)
            {
                prompt.text = "Limb repaired";
                hp = hp + 25;
                HealthPoints();
            }
            else
                prompt.text = "MAX HEALTH";
        }
    }

    void OnTriggerEnter(Collider other) //when a monster touches you depending on the color is the amount of health you lose.
    {
        if(other.tag == "Common Monster")
        {
            hp = hp - 10;
            HealthPoints();
        }
        else if (other.tag == "Rare Monster")
        {
            hp = hp - 20;
            HealthPoints();
        }
        else if (other.tag == "Legendary Monster")
        {
            hp = hp - 35;
            HealthPoints();
        }
        else if (other.tag == "Epic Monster")
        {
            hp = hp - 50;
            HealthPoints();
        }
        else if (other.tag == "Chroma Monster")
        {
            hp = hp - 75;
            HealthPoints();
        }
    }
}
