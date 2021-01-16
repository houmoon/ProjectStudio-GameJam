using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HPContainer : MonoBehaviour
{
    public Sprite HpOn,HpOff;
    
    private List<Image> HpUIs = new List<Image>();

    private int currentHP;
    private bool displayempty = false;

    private void Start()
    {
        for(int i = 0;i < 3; i++)
        {
            HpUIs.Add(transform.GetChild(i).GetComponent<Image>());
        }

        UpdateHPUI();
    }

    public void UpdateHPUI()
    {
        displayempty = false;

        currentHP = PlayerController.Instance.Return_HP;

        if(currentHP == 0)
        displayempty = true;

        for(int i = 0;i < 3; i++)
        {
            if(!displayempty)
                HpUIs[i].sprite = HpOn;
            else
               HpUIs[i].sprite = HpOff;

            if(currentHP - 1 == i)
                displayempty = true;
        }
    }

}
