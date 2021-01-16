using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    SHOVEL=0,SPREADER=1,AXE=2
}

public class ItemContainer : MonoBehaviour
{
    public RectTransform Shovel,Spreader,Axe;

    public void Add(ItemType type)
    {
        switch(type)
        {
            case ItemType.SHOVEL:
                AddUI(ref Shovel);
                break;
            case ItemType.SPREADER:
                AddUI(ref Spreader);
                break;
            case ItemType.AXE:
                AddUI(ref Axe);
                break;
        }
    }

    void AddUI(ref RectTransform target)
    {
        for(int i=0;i<3;i++)
        {
            if(transform.GetChild(i).childCount <= 0)
            {
                target.transform.SetParent(transform.GetChild(i));
                target.anchoredPosition = Vector2.zero;
                return;
            }

        }
    }
}
