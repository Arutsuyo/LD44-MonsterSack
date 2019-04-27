using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : BodyPart
{

    new public ItemTypes GetItemType()
    {
        return ItemTypes.head;
    }
}
