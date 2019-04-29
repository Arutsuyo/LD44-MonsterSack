using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public void OnTriggerEnter(Collider e)
    {
        if(e.gameObject.GetComponentInParent<EnemyManager>() != null)
        {
            e.gameObject.GetComponentInParent<EnemyManager>().Damage(20);
        }
    }
}
