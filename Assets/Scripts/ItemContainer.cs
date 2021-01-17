using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    SHOVEL=0,SPREADER=1,AXE=2,GLASS=3
}

public class ItemContainer : MonoBehaviour
{
    public RectTransform Shovel,Spreader,Axe,Glass;

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
            case ItemType.GLASS:
                AddUI(ref Glass);
                break;
        }
    }

    void AddUI(ref RectTransform target)
    {
        for(int i=0;i< transform.childCount;i++)
        {
            if(transform.GetChild(i).childCount <= 0)
            {
                target.transform.SetParent(transform.GetChild(i));
                transform.GetChild(i).gameObject.SetActive(true);
                target.anchoredPosition = Vector2.zero;
                return;
            }

        }
    }
}
