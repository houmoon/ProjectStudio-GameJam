using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UI_Tween : MonoBehaviour
{
    public Ease type;
    private void OnEnable()
    {
        transform.DOScale(0,0);
        transform.DOScale(1,0.5f).SetEase(type);
    }
}
