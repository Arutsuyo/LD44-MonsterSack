using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

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

    /// <summary>
    /// Value is used when selling to the shop. Monster parts have 
    /// a positive weight, while human parts have a negative value.
    /// If a negative value is detected in the shop, it will apply a
    /// scalar to the sell value. Human parts trade value is lower 
    /// by default.
    /// </summary>
    public int value;
}