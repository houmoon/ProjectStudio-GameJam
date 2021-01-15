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

    public bool GetAxe=false;
    public bool GetShovel=false;
    public bool GetSpreader = false;
    public int SpreaderAmount = 0;

    //디버그용 메서드
    public void SetAxe(bool boolean) { GetAxe = boolean; }
    public void SetShovel(bool boolean) { GetShovel = boolean; }
    public void SetSpreader(bool boolean) { GetSpreader = boolean; }

    public void SetSpreaderAmount(int amount) { SpreaderAmount = amount; }
    
    SpriteRenderer sprite;
    Animator animator;
    Rigidbody2D rigid;
    BoxCollider2D boxcol;
    public float speed;
    float firstspeed;
    public float jumpPower;
    public LayerMask groundLayer;
    float h, v;
    bool isGround = false;
    bool isWall = false;
    bool isStarPiece = false;
    bool isSit=false;

    Vector2 boxcolfisrt_offset;
    Vector2 boxcolfisrt_size;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        boxcol = GetComponent<BoxCollider2D>();

        boxcolfisrt_offset = boxcol.offset;
        boxcolfisrt_size = boxcol.size;
        firstspeed = speed;
    }

    void FixedUpdate()
    {
        Move();
        Ground();
        if (Input.GetButtonDown("Jump") && isGround)
            Jump();
        Wall();
        sit();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "starpiece")
        {
            Debug.Log("isstarpiece"+isStarPiece);

            isStarPiece = true;
        }
        if (collision.tag == "ClearObject")
        {
            //clear!
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "starpiece")
        {
            Debug.Log("isstarpiece" + isStarPiece);

            isStarPiece = false;
        }

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
        if (isStarPiece)
            rigid.AddForce(Vector2.up * jumpPower*1.5f, ForceMode2D.Impulse);
        else
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    void sit()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isSit = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isSit = false;
        }

        if (isSit)
        {
            animator.SetBool("isSit", true);
            boxcol.offset = new Vector2(boxcolfisrt_offset.x, boxcolfisrt_offset.y / 2);
            boxcol.size = new Vector2(boxcolfisrt_size.x, boxcolfisrt_size.y / 2);
            speed = firstspeed / 2;
        }
        else
        {
            animator.SetBool("isSit", false);
            boxcol.offset = new Vector2(boxcolfisrt_offset.x, boxcolfisrt_offset.y);
            boxcol.size = new Vector2(boxcolfisrt_size.x, boxcolfisrt_size.y);
            speed = firstspeed;
        }
    }

    void Ground()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.02f, LayerMask.GetMask("Ground"));

        Debug.DrawRay(transform.position,Vector3.down,Color.red);

        if (hit.collider != null) //땅에 닿으면? 트루 리턴
        {
            Debug.Log("Hit");
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
