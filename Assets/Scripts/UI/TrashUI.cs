using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TrashUI : MonoBehaviour
{
    [Header("UI References")]
    public Image Mask;
    public Image Parent;
    
    [Header("Trash Size")]
    public float CurSize;
    public float MaxSize;
    
    [Header("Debugging")]
    public bool CallUpdate = false;
    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (CallUpdate)
        {
            CallUpdate = false;
            UpdateUI();
        }
    }
    public void UpdateUI()
    {
        Mask.rectTransform.sizeDelta = new Vector2(Mask.rectTransform.sizeDelta.x, Mathf.Lerp(0f, Parent.rectTransform.sizeDelta.y, CurSize/MaxSize));
    }
}
