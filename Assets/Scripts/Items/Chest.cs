using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : BodyPart
{

    new public ItemTypes GetItemType()
    {
        return ItemTypes.chest;
    }
}
