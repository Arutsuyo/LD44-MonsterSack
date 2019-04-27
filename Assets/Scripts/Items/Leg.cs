using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : BodyPart
{

    new public ItemTypes GetItemType()
    {
        return ItemTypes.leg;
    }
}
