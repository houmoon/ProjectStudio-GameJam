using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public Animator ani;
    public GameObject Light;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ani.Play("Lamp_on");
            Light.SetActive(true);

        }
    }

}
