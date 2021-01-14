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

<<<<<<< Updated upstream
    public bool GetAxe=false;
    public bool GetShovel=false;

    //디버그용 메서드
    public void SetAxe(bool boolean) { GetAxe = boolean; }
    public void SetShovel(bool boolean) { GetShovel = boolean; }
    

=======
    SpriteRenderer sprite;
>>>>>>> Stashed changes
    Animator animator;
    Rigidbody2D rigid;
    public float speed;
    public float jumpPower;
    public LayerMask groundLayer;
    float h, v;
    bool isGround = false;
    bool isWall = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        Move();
        Ground();
        if (Input.GetButtonDown("Jump") && isGround)
            Jump();
        Wall();
    }

    void Move()
    {
        h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        v = Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Translate(h, 0, 0);
        if (h > 0.0f)//|| h < 0.0f)
        {
            animator.SetBool("isMove", true);
            sprite.flipX = false;
        }
        else if (h < 0.0f)
        {
            animator.SetBool("isMove", true);
            sprite.flipX = true;
        }
        else
        {
            animator.SetBool("isMove", false);
            
        }
    }

    void Jump()
    {
        rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        
    }

    void Ground()
    {
        Vector2 pos = new Vector2(this.transform.position.x, this.transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.down, 0.02f, groundLayer);

        if (hit.collider != null && hit.collider.tag == "Ground") //땅에 닿으면? 트루 리턴
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 0.0f);
            isGround = true;
            animator.SetBool("isGround", true);
        }
        else
        {
            isGround = false;
            animator.SetBool("isGround", false);
        }
    }

    void Wall()
    {
        Vector2 pos = new Vector2(this.transform.position.x, this.transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.right, 0.45f, groundLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(pos, Vector2.left, 0.45f, groundLayer);


        if (hit.collider != null && hit.collider.tag == "Ground") //땅에 닿으면? 트루 리턴
        {
            Debug.Log("that is Wall!!");
            if (Input.GetKey(KeyCode.W))
            {
                rigid.gravityScale = 0;
                isWall = true;
                sprite.flipX = false;
                transform.Translate(0, v, 0);
                animator.SetBool("isWall", true);
                Debug.Log("ONNNN Wall!!");
            }
        }
        else if (hit2.collider != null && hit2.collider.tag == "Ground")
        {
            Debug.Log("that is Wall!!");
            if (Input.GetKey(KeyCode.W))
            {
                rigid.gravityScale = 0;
                isWall = true;
                sprite.flipX = true;
                transform.Translate(0, v, 0);
                animator.SetBool("isWall", true);
                Debug.Log("ONNN Wall!!");
            }
        }
        else //if (Input.GetKeyUp(KeyCode.W))
        {
            rigid.gravityScale = 1;
            animator.SetBool("isWall", false);
            Debug.Log("no Wall");
            isWall = false;
        }
    }
}
