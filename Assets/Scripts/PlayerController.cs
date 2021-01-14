using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //플레이어 클래스의 싱글톤 인스턴스 생성.
    public static PlayerController Instance;
    private void Awake()    {Instance = this;}
    /// //////////////////////////////////////////////////////////////////


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
