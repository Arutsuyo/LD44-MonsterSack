using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterHealthUI : MonoBehaviour
{
    [Header("UI References")]
    public Image Head;
    public Image Torso;
    public Image LLeg;
    public Image RLeg;
    public Image LArm;
    public Image RArm;
    [Header("Current Health for Part")]
    public float HeadHP;
    public float TorsoHP;
    public float LLegHP;
    public float RLegHP;
    public float LArmHP;
    public float RArmHP;
    [Header("Max Health for Part")]
    public float MHeadHP;
    public float MTorsoHP;
    public float MLLegHP;
    public float MRLegHP;
    public float MLArmHP;
    public float MRArmHP;
    [Header("Colors for Health")]
    public Color32 ZeroHealth;
    public Color32 FullHealth;
    [Header("Debugging")]
    public bool CallUpdate = false;
    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }
    public void Update()
    {
        if (CallUpdate){
            CallUpdate = false;
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        Head.color = Color32.Lerp(ZeroHealth, FullHealth, HeadHP / MHeadHP);
        Torso.color = Color32.Lerp(ZeroHealth, FullHealth, TorsoHP / MTorsoHP);
        LLeg.color = Color32.Lerp(ZeroHealth, FullHealth, LLegHP / MLLegHP);
        RLeg.color = Color32.Lerp(ZeroHealth, FullHealth, RLegHP / MRLegHP);
        LArm.color = Color32.Lerp(ZeroHealth, FullHealth, LArmHP / MLArmHP);
        RArm.color = Color32.Lerp(ZeroHealth, FullHealth, RArmHP / MRArmHP);

    }
}
