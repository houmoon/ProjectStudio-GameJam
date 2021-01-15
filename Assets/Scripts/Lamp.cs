using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public Animator ani;
    public GameObject Light;
    bool onCheck = false;

    IEnumerator LightOn()
    {
        for(int i = 0; i<5; i++)
        {
            if(Light.activeSelf == true)
                Light.SetActive(false);
            else
            {
                if (i == 4)
                    Light.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().intensity = 1f;
                else
                    Light.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().intensity = 0.5f;
                Light.SetActive(true);

            }
            yield return new WaitForSeconds(0.1f);          
        }
    }
    void Light_On()
    {
        Light.SetActive(true);
    }
    void Light_Off()
    {
        Light.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !onCheck)
        {
            onCheck = true;
            ani.Play("Lamp_on");
            StartCoroutine(LightOn());


        }
    }
}
