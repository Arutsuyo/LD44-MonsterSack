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

    public bool PickupItem(Item itm)
    {
        if(CheckCarryCapacity(itm.weight))
        {
            Debug.Log("Picking up :" + itm.name);

            Sack.Add(itm);

            return true;
        }

        Debug.Log("Item " + itm.name + " is too heavy");
        return false;
    }

    public bool CheckCarryCapacity(int newWeight)
    {
        throw new NotImplementedException();
        return true;
    }

    public bool EquiptPart(BodyPart part, ItemTypes loc, bool leftRight = false)
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
                Debug.LogWarning("Item Cannot be equipt: " + part.name);
                break;
        }
        CalculateStats();

        return equip;
    }

    public void CalculateStats()
    {
        throw new NotImplementedException();
    }

}
