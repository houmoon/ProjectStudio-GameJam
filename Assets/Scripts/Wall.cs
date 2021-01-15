using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Wall : MonoBehaviour
{
    public Vector3 WayPoint;
    private Vector3 StartingPoint;
    private bool moved = false;

    private void Start()
    {
        StartingPoint = new Vector3(transform.position.x, transform.position.y, 0);
        WayPoint = transform.GetChild(0).position;
    }

    public void Toggle()
    {
        if(moved)
            transform.DOMove(StartingPoint, 1.0f).SetEase(Ease.OutQuart);
        else
            transform.DOMove(WayPoint, 1.0f).SetEase(Ease.OutQuart);

        moved = !moved;
    }


}
