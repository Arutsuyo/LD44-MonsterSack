using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconManager : MonoBehaviour
{
    [Header("Location Information")]
    public int startx, starty, gapx, gapy, width, height;

    [Header("Player Script References")]
    public Inventory inv;
    public Player player;

    private void OnGUI()
    {
        if (!player.showInv)
            return;

        for(int i = 0; i < inv.Sack.Count; i++)
        {
            Image img = inv.Sack[i].icon;
            img.rectTransform.position = new Vector3(
                startx + i * width + i * gapx,
                starty + i * height + i * gapy,
                0);
            img.rectTransform.sizeDelta = new Vector2(width, height);
            img.gameObject.SetActive(true);
        }
    }
}
