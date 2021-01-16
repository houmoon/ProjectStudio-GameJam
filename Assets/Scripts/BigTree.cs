using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class BigTree : Object
{
    public GameObject SmallTree;
    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        SetCallBack(Cut);
    }

    private void LateUpdate()
    {
        this.Interactable = PlayerController.Instance.GetAxe;
    }

    public void Cut()
    {
        Interactable = false;
        hasEntered = false;
        this.GetComponent<Collider2D>().enabled = false;

        sprite.transform.DOMoveY(transform.position.y + 0.4f,0.7f).SetEase(Ease.OutQuart);
        sprite.transform.DORotate(new Vector3(0,0,65),0.6f).SetEase(Ease.OutQuart);
        sprite.DOFade(0,0.5f).OnComplete(() => FinishCutting() );
    }

    void FinishCutting()
    {
        SmallTree.SetActive(true);
        gameObject.SetActive(false);
    }
}
