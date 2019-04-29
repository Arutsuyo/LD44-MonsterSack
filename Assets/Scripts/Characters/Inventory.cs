using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    [Header("Item Management")]
    public Head e_Head;
    public Chest e_Chest;
    public Arm e_LArm, e_RArm;
    public Leg e_LLeg, e_RLeg;


    /// <summary>
    /// This will have a limit of _weight carry capacity, determined by the stats
    /// of the player.
    /// </summary>
    public List<Item> Sack;

    [Header("Player Info")]
    /// <summary>
    /// Players stats. These will be calculated every time parts are equip.
    /// </summary>
    public double[] stats;
    public int CarryWeight = 24;

    [Header("Player Obj Reference")]
    public GameObject LArmAttach;
    public GameObject RArmAttach;
    public GameObject HeadAttach;

    private GameObject curLArm;
    private GameObject curRArm;
    private GameObject curHead;

    [Header("Script References")]
    public Player player;

    [Header("UI References")]
    public TrashUI trashUI;
    public CharacterHealthUI charUI;
    
    public void Start()
    {
        trashUI.MaxSize = CarryWeight;
        trashUI.CurSize = 0;
        trashUI.UpdateUI();
    }
    public bool PickupItem(Item itm)
    {
        if(CheckCarryCapacity(itm.weight))
        {
            Debug.Log("Picking up :" + itm.name);
            
            Sack.Add(itm);
            int totalWeight = 0;
            foreach (Item item in Sack)
            {
                totalWeight += item.weight;
            }
            trashUI.CurSize = totalWeight;
            trashUI.UpdateUI();
            return true;
        }

        Debug.Log("Item " + itm.name + " is too heavy");
        return false;
    }
    public void UpdateCarry()
    {
        int totalWeight = 0;
        foreach (Item item in Sack)
        {
            totalWeight += item.weight;
        }
        trashUI.CurSize = totalWeight;
        trashUI.UpdateUI();
    }
    public bool CheckCarryCapacity(int newWeight)
    {
        int totalWeight = 0;
        foreach(Item item in Sack)
        {
            totalWeight += item.weight;
        }
        if (totalWeight + newWeight <= CarryWeight)
            return true;
        else
            return false;
    }

    public bool EquipPart(BodyPart part, ItemTypes loc, bool leftRight = false)
    {
        bool equip = false;
        switch(loc)
        {
            case ItemTypes.head:
                e_Head = (Head)part;
                equip = true;
                break;

            case ItemTypes.chest:
                e_Chest = (Chest)part;
                equip = true;
                break;

            case ItemTypes.arm:
                if(leftRight)
                    e_LArm = (Arm)part;
                else
                    e_RArm = (Arm)part;
                equip = true;
                break;

            case ItemTypes.leg:
                if (leftRight)
                    e_LLeg = (Leg)part;
                else
                    e_RLeg = (Leg)part;
                equip = true;
                break;

            default:
                Debug.LogWarning("Item Cannot be equip: " + part.name);
                break;
        }

        if(equip)
            CalculateStats();

        return equip;
    }

    public void CalculateStats()
    {
        for (int i = 0; i < stats.Length; i++)
            stats[i] = 0;

        for (int i = 0; i < stats.Length; i++)
            stats[i] = e_Head.stats[i]
            + e_Chest.stats[i]
            + e_LArm.stats[i]
            + e_RArm.stats[i]
            + e_LLeg.stats[i]
            + e_RLeg.stats[i];


        if(e_LArm!= null)
        {
            // Attach the e_Larm..
            GameObject go = GameObject.Instantiate(e_LArm.ItemToAttach, LArmAttach.transform);
            go.transform.localPosition = Vector3.zero;
            go.transform.localRotation = Quaternion.identity;
            go.transform.localScale = Vector3.one;
            if(curLArm == null || curLArm.Equals(null))
            {
                curLArm = go;
            }
            else
            {
                Destroy(curLArm);
                curLArm = go;
            }
        }
        if (e_RArm != null)
        {
            // Attach the e_Larm..
            GameObject go = GameObject.Instantiate(e_RArm.ItemToAttach, RArmAttach.transform);
            go.transform.localPosition = Vector3.zero;
            go.transform.localRotation = Quaternion.identity;
            go.transform.localScale = Vector3.one;
            if (curRArm == null || curRArm.Equals(null))
            {
                curRArm = go;
            }
            else
            {
                Destroy(curRArm);
                curRArm = go;
            }
        }
        if(e_Head != null)
        {
            GameObject go = GameObject.Instantiate(e_Head.ItemToAttach, HeadAttach.transform);
            go.transform.localPosition = Vector3.zero;
            go.transform.localRotation = Quaternion.identity;
            go.transform.localScale = Vector3.one;
            if (curHead == null || curHead.Equals(null))
            {
                curHead = go;
            }
            else
            {
                Destroy(curHead);
                curHead = go;
            }
        }
    }

}
