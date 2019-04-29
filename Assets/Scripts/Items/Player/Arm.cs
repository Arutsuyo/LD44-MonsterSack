using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : BodyPart
{

    public bool IsLeft;
    public Arm(double[] newStats) : base(newStats)
    {

    }

    new public ItemTypes GetItemType()
    {
        return ItemTypes.arm;
    }
}
