    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeRange : MonoBehaviour
{

    public EnemyManager manager;
    public bool inRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
            manager.OnMeleeEnter(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
            manager.OnMeleeExit(other);
        }
    }

}
