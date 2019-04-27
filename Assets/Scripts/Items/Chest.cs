using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : BodyPart
{
    public Chest(double[] newStats) : base(newStats)
    {

    }

    new public ItemTypes GetItemType()
    {
        return ItemTypes.chest;
    }
}
