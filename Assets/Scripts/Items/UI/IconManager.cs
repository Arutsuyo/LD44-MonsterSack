using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IconManager : MonoBehaviour
{
    [Header("Location Information")]
    public int startx, starty, gapx, gapy, width, height;

    [Header("UI Element References")]
    public GameObject invPanel;
    public GameObject equipPanel;
    public Text statText;

    [Header("Player Script References")]
    public Inventory inv;
    public Player player;
    public InventoryHolderUI holderUI;
    public Transform armory;
    private bool latched = true;

    public bool OnEndDrag( int from, int targ)
    {
        // Oh boy :|
        ItemTypes ddj = 0;
        bool L = false;
        BodyPart bp = (BodyPart)inv.Sack[from];
        if(targ == 0)
        {
            ddj = ItemTypes.arm;
            if(bp is Arm)
            {
                if (!((Arm)bp).IsLeft)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            L = true;
        }else if(targ == 1)
        {
            ddj = ItemTypes.arm;
            if (bp is Arm)
            {
                if (((Arm)bp).IsLeft)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            L = false;
        }
        else if(targ == 2)
        {
            ddj = ItemTypes.head;
            if (!(bp is Head))
            {
                return false;    
            }
            
        }

        bool dk = (inv.EquipPart(bp, ddj, L));
        if(dk)
        {
            inv.Sack.RemoveAt(from);
            inv.UpdateCarry();
        }
        return dk;
        
    }

    public void OnShow()
    {
        if (!player.showInv)
        {
            foreach (Transform f in invPanel.transform)
            {
                f.gameObject.SetActive(false);
            }
            foreach(Transform f in armory)
            {
                f.gameObject.SetActive(false);
            }
            equipPanel.gameObject.SetActive(false);
            statText.gameObject.SetActive(false);
            return;
        }
        foreach (Transform f in invPanel.transform)
        {
            f.gameObject.SetActive(true);
        }
        foreach (Transform f in armory)
        {
            f.gameObject.SetActive(true);
        }
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
        // Anything greater than or equal to 24 is items...
        for(; i < 24; i++)
        {
            holderUI.imageSlots[i].color = new Color(0,0,0,0);
        }
        // Go over the remaining slots...
        for(; i < holderUI.imageSlots.Length; i++)
        {
            if(holderUI.imageSlots[i].sprite == null)
            {
                holderUI.imageSlots[i].color = new Color(0, 0, 0, 0);
            }
            else
            {
                holderUI.imageSlots[i].color = new Color(1f, 1f, 1f, 1f);
            }
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
