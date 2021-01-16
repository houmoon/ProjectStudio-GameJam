using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magma : Object
{
    public float timer = 3.0f;
    ParticleSystem particle;
    Collider2D collider;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
        particle = GetComponent<ParticleSystem>();
        SetCallBack(SetDisable);
    }

    private void LateUpdate()
    {
        this.Interactable = PlayerController.Instance.GetSpreader;
    }

    void SetDisable()
    {
        if(PlayerController.Instance.SpreaderAmount > 0)
        {
            collider.enabled = false;
            particle.Stop();
            PlayerController.Instance.SpreaderAmount--;
            UIElement.Instance.UpdateSpreaderAmount();
            StartCoroutine(ReadytoBack());
        }
        
    }

    IEnumerator ReadytoBack()
    {
        yield return new WaitForSeconds(timer);
        particle.Play();
        collider.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController.Instance.IncreaseHP(-1);
        Debug.Log("aa");
    }
}
