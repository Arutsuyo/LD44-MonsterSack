using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconManager : MonoBehaviour
{
    [Header("Location Information")]
    public int startx, starty, gapx, gapy, width, height;

    [Header("UI Element References")]
    public Image invPanel;
    public Image equipPanel;
    public Text statText;

    [Header("Player Script References")]
    public Inventory inv;
    public Player player;
    public InventoryHolderUI holderUI;
    private bool latched = true;

    public void OnShow()
    {
        if (!player.showInv)
        {
            invPanel.gameObject.SetActive(false);
            equipPanel.gameObject.SetActive(false);
            statText.gameObject.SetActive(false);
            return;
        }
        invPanel.gameObject.SetActive(true);
        equipPanel.gameObject.SetActive(true);
        statText.gameObject.SetActive(true);
        int i = 0;
        for (; i < inv.Sack.Count; i++)
        {
            /*SpriteRenderer img = inv.Sack[i].icon;
            img.size = new Vector2(width, height);
            img.transform.position = new Vector3(
                startx + i * width + i * gapx,
                starty + i * height + i * gapy,
                0);
            img.gameObject.SetActive(true);*/
            holderUI.imageSlots[i].color = new Color(255, 255, 255, 255);
            holderUI.imageSlots[i].sprite = inv.Sack[i].icon.sprite;
        }
        for(; i < holderUI.imageSlots.Length; i++)
        {
            holderUI.imageSlots[i].color = new Color(0,0,0,0);
        }
    }
    private void OnGUI()
    {
        if(player.showInv != latched)
        {
            OnShow();
            latched = player.showInv;
        }
    }
}
