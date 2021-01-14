using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Llamp_NPC : MonoBehaviour
{
    public GameObject[] Lamp;
    public TextMeshPro Tx_text;
    public GameObject quad;
    public GameObject Gm_text;

    int FindLamp()
    {
        int Lamp_count = 0;
        GameObject Lamp = GameObject.Find("Lamp");
        for (int i = 0; i < Lamp.transform.childCount; i++)
        {
            Lamp_count++;
            if (Lamp.transform.GetChild(i).GetComponentInChildren<Lamp>().transform.GetChild(0).gameObject.activeSelf == true)
                Lamp_count--;         
        }
        return Lamp_count;
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Gm_text.SetActive(true);
            Tx_text.text = "남은 가로등 갯수: " + FindLamp();
            float x = Tx_text.preferredWidth;
            x = (x > 3) ? 3 : x + 0.15f;
            quad.transform.localScale = new Vector2(x, Tx_text.preferredHeight / 2 + 0.15f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Gm_text.SetActive(false);
    }

  
}
