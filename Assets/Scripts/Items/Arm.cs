using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : BodyPart
{
    public bool LeftRight;

    new public ItemTypes GetItemType()
    {
        return ItemTypes.arm;
    }
}
