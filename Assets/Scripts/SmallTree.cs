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

    private void LateUpdate()
    {
        this.Interactable = PlayerController.Instance.GetShovel;
    }

    public void Cut()
    {
        Interactable = false;
        hasEntered = false;
        this.GetComponent<Collider2D>().enabled = false;

        sprite.transform.DOMoveY(transform.position.y + 0.4f,0.7f).SetEase(Ease.OutQuart);
        sprite.transform.DORotate(new Vector3(0,0,65),0.6f).SetEase(Ease.OutQuart);
        sprite.DOFade(0,0.5f).OnComplete(() =>  gameObject.SetActive(false) );

        Debug.Log("나무 짤림");
    }
}
