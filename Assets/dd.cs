using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class dd : MonoBehaviour
{
    public Vector2 v2;
    private bool dragging;
    private Vector2 origPos;
    public IconManager img;
    public int Val = 0;

    public Image LA;
    public Image RA;
    public Image Head;

    public static Image SLA;
    public static Image SRA;
    public static Image SHEAD;
    public RectTransform rt;
    public Image self;
    public Image T1;
    public Image T2;
    public void Start()
    {
        if (LA)
        {
            SLA = LA;
        }
        if (RA)
        {
            SRA = RA;
        }
        if (Head)
        {
            SHEAD = Head;
        }

        rt = gameObject.GetComponent<RectTransform>();
        self = gameObject.GetComponent<Image>();
    }
    public void Update()
    {
        if (dragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - v2;
        }
    }

    public void OnDown(BaseEventData bb)
    {
        if(self.color.a < 0.1f) { return; }
        Debug.Log("PD?");
        origPos = (Vector2)transform.position;
        v2 = ((PointerEventData)bb).position - (Vector2)transform.position;
        dragging = true;
    }
    public void OnUp(BaseEventData bb)
    {
        Debug.Log("PU?");
        dragging = false;
        if (!Isgood())
        {
            transform.position = origPos;
        }
        else
        {
            Debug.Log(getTarget());
            if(img.OnEndDrag(Val, getTarget()))
            {
                // Replace...
                int gT = getTarget();
                Debug.Log(gT);
                switch (gT)
                {
                    case 0:
                        SLA.sprite = gameObject.GetComponent<Image>().sprite;
                        SLA.color = new Color(1, 1, 1, 1f);
                        break;
                    case 1:
                        SRA.sprite = gameObject.GetComponent<Image>().sprite;
                        SRA.color = new Color(1, 1, 1, 1f);
                        break;
                    case 2:
                        SHEAD.sprite = gameObject.GetComponent<Image>().sprite; ;
                        SHEAD.color = new Color(1, 1, 1, 1f);
                        break;
                    default:
                        break;

                }
                gameObject.GetComponent<Image>().sprite = null;
                transform.position = origPos;
                img.OnShow();
            }
            else
            {
                transform.position = origPos;
            }
        }
    }
    private bool Isgood()
    {
        return getTarget()!= -1;
    }
    private int getTarget()
    {
        /*Rect tt = new Rect((Vector2)transform.position, Vector2.one);
        Debug.Log(tt);
        Debug.Log(new Rect((Vector2)SLA.rectTransform.position + SLA.rectTransform.sizeDelta, SLA.rectTransform.sizeDelta));
        T1.rectTransform.position = SLA.rectTransform.position;
        T2.rectTransform.position = SLA.rectTransform.position + (Vector3)SLA.rectTransform.sizeDelta;
        Debug.Log(SLA.rectTransform.rect);*/
        Vector3[] v = new Vector3[4];
        SLA.rectTransform.GetWorldCorners(v);
        /*T1.transform.position = v[0];
        T2.transform.position = v[2];*/
        if (new Rect((Vector2)v[0], (Vector2)(v[2] - v[0])).Contains((Vector2)transform.position + v2))
        {
            return 0;
        }
        else
        {
            SRA.rectTransform.GetWorldCorners(v);
            if (new Rect((Vector2)v[0], (Vector2)(v[2] - v[0])).Contains((Vector2)transform.position + v2))
            {
                return 1;
            }
            else
            {
                SHEAD.rectTransform.GetWorldCorners(v);
                if (new Rect((Vector2)v[0], (Vector2)(v[2] - v[0])).Contains((Vector2)transform.position + v2))
                {
                    return 2;
                }
                else
                {
                    return -1;
                }
            }
        }
    }   
}
