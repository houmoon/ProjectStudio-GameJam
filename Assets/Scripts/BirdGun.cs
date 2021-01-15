using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGun : MonoBehaviour
{
    public GameObject bullet;
    public GameObject shootpoint;
    Vector3 worldMousePos;
    public float speed;
    void Update()
    {
        worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = worldMousePos - shootpoint.transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;


        shootpoint.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetMouseButtonDown(0))
        {
            if (PlayerController.Instance.Return_SpriteFlipX)
            {
                if (angle < 180 && angle > 110)
                {
                    Instantiate(bullet, shootpoint.transform.position, shootpoint.transform.rotation);
                }
            }
            else
            {
                if (angle < 70 && angle > 0)
                {
                    Instantiate(bullet, shootpoint.transform.position, shootpoint.transform.rotation);
                }
            }
        }
    }
}
