using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPot : Object
{
    private AudioSource audio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        UIElement.Instance.UpdateSpreaderAmount();
        Interactable = true;
        SetCallBack(FillSpreader);
    }

    public void FillSpreader()
    {
        if(PlayerController.Instance.GetSpreader)
        {
            PlayerController.Instance.SpreaderAmount = 5;
            audio.Play();
        }
        

        UIElement.Instance.UpdateSpreaderAmount();
    }
}
