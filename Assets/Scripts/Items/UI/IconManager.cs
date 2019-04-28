using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconManager : MonoBehaviour
{
    [Header("Location Information")]
    public int startx, starty, gapx, gapy, width, height;

    [Header("Image Prefab")]
    public List<Image> imgs;

    [Header("Player Script References")]
    public Inventory inv;
}
