﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enum to specify item types. Whenever a new class is created, please addd its 
// name to the enum.
public enum ItemTypes
{
    item = 0,
    bodypart = 1,
    head,
    chest,
    arm,
    leg
}
public class Item : MonoBehaviour
{
    /// <summary>
    /// Value is used when selling to the shop. Monster parts have 
    /// a positive weight, while human parts have a negative value.
    /// If a negative value is detected in the shop, it will apply a
    /// scalar to the sell value. Human parts trade value is lower 
    /// by default.
    /// </summary>
    public int value;
    
    // Used to limit the number of items the player can carry.
    public int weight;

    public ItemTypes GetItemType()
    {
        return ItemTypes.item;
    }
}

public class BodyPart : Item
{
    /// <summary>
    /// Strength - Power of the body part
    /// Agility - Movement / Animation speed scalar
    /// Defense - Armor
    /// Humanity - Effects the players humanity scalar when equip
    /// </summary>
    public double[] stats;

    public string species;
    
    public double speciesScalar;

    new public ItemTypes GetItemType()
    {
        return ItemTypes.bodypart;
    }
}