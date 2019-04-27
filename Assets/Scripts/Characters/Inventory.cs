using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Item Management")]
    public List<BodyPart> CurrentEquipment;

    /// <summary>
    /// This will 
    /// </summary>
    public List<Item> Sack;


    /// <summary>
    /// Players stats. These will be calculated every time parts are equip.
    /// </summary>
    public double[] stats;


}
