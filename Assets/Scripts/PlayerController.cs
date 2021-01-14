using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigid;
    public float speed;
    public float jumpPower; 
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(h, 0, 0);
        if (h > 0.0f || h < 0.0f)
            animator.SetBool("isMove", true);
        else
            animator.SetBool("isMove", false);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector2.up*jumpPower,ForceMode2D.Impulse);
            Debug.Log("jump");
        }
    }
}
