using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    Animator animDetect;
    // Start is called before the first frame update
    void Start()
    {
        animDetect = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if(other.tag == "Player")
        {
            animDetect.SetBool("InRange", true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animDetect.SetBool("InRange", false);
        }
    }
}
