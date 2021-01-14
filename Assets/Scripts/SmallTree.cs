using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SmallTree : Object
{
    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        SetCallBack(Cut);
    }

    public void Cut()
    {
        Interactable = false;
        hasEntered = false;

        sprite.DOFade(0,0.5f).OnComplete(() =>  gameObject.SetActive(false) );

        Debug.Log("나무 짤림");
    }
}
