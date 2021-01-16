using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    bool isDie = false;
    Color color;
    IEnumerator DIe()
    {
        SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
        for (int i = 0; i<10; i++)
        {
            color.a = i*0.1f;
            spr.color = color;
            yield return new WaitForSeconds(0.1f);
        }
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !isDie)
        {
            if (PlayerController.Instance.Return_isSit == true)
                return;
            PlayerController.Instance.IncreaseHP(-1);
        }
        if(collision.gameObject.tag == "Bullet")
        {
            isDie = true;
            StartCoroutine(DIe());
        }
    }
}
