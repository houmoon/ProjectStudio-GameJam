using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPot : Object
{
    private void Start()
    {
        UIElement.Instance.UpdateSpreaderAmount();
        Interactable = true;
        SetCallBack(FillSpreader);
    }

    public void FillSpreader()
    {
        if(PlayerController.Instance.GetSpreader)
        PlayerController.Instance.SpreaderAmount = 5;

        UIElement.Instance.UpdateSpreaderAmount();
    }
}
