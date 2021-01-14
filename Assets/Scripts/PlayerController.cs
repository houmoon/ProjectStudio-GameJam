﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigid;
    public float speed;
    public float jumpPower;
    public LayerMask groundLayer;

    bool isJump = false;
    bool isGround = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
        Jump();
        //Ground();
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
            if (Ground())
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    bool Ground()
    {
        Vector2 pos = new Vector2(this.transform.position.x, this.transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.down, 0.1f, groundLayer);

        if (hit.collider != null && hit.collider.tag == "Ground") //땅에 닿으면? 트루 리턴
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 0.0f);
            Debug.Log("ground");
            isGround = true;
            return true;
        }
        else
        {
            isGround = false;
            return false;
        }
    }
}
