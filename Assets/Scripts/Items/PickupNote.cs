using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupNote : MonoBehaviour
{
    public Item item;
    public GameObject parent;
    public void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            Inventory i = c.gameObject.GetComponent<Inventory>();
            if (i.PickupItem(item))
            {
                parent.SetActive(false);
            }
        }
    }

}
