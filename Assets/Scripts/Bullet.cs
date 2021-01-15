using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float speed;
    private void Start()
    {
        rigid.velocity = transform.right * speed;
    }
    void Update()
    {
        
    }
}
