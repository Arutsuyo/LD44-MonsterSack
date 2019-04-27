using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : BodyPart
{
    public Leg(double[] newStats) : base(newStats)
    {

    }


    new public ItemTypes GetItemType()
    {
        return ItemTypes.leg;
    }
}
