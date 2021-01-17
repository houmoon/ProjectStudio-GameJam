using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Object
{
    public ItemType type;
    public ObjectPooler effect;
    public GameObject effect_obj;

    private void Start()
    {
        SetCallBack(Getitem);
    }

    void Getitem()
    {
        PlayerController.Instance.GetItem(type);
        effect_obj = effect.GetPooledObject();
        effect_obj.transform.position = transform.position;
        effect_obj.SetActive(true);

        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            this.callback();
        }
        
    }
}
