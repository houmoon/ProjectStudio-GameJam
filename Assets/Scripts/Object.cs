using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public bool Interactable = false;
    public bool hasEntered = false;

    //콜백함수 정의.
    public delegate void Callback();
    private Callback callback = null;

    public void SetCallBack(Callback cal)
    {
        callback = cal;
    }

    private void Update()
    {
        if(this.Interactable && this.hasEntered && this.callback != null)
        {
            if(Input.GetButtonDown("Submit"))
            {
                this.GetComponent<Collider2D>().enabled = false;
                this.callback();
            }
            
        }
    }

    public void DisplayIndicator(bool toggle)
    {
        //UI로 표시해주는 기능이 필요.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            this.hasEntered = true;
            UIElement.Instance.FocusInteraction(transform);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            this.hasEntered = false;
            UIElement.Instance.DefocusInteraction();
        }
    }
}

