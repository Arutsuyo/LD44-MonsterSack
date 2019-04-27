using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : BodyPart
{

    public Head(double[] newStats) : base(newStats)
    {

    }

    new public ItemTypes GetItemType()
    {
        return ItemTypes.head;
    }
}
