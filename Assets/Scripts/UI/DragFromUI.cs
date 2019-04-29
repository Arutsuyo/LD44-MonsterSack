using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class DragFromUI : MonoBehaviour
{
    public int from;
    public IconManager IM;
    public void Click(BaseEventData d)
    {
        Debug.Log("HERE");
    }


}
