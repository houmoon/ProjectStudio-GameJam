using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (PlayerController.Instance.Return_isSit == true)
                return;
            PlayerController.Instance.IncreaseHP(-1);
        }
    }
}
