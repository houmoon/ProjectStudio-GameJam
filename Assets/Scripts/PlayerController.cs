using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditorInternal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //플레이어 클래스의 싱글톤 인스턴스 생성.
    public static PlayerController Instance;
    private void Awake()    {  HP = MaxHP; Instance = this;}
    /// //////////////////////////////////////////////////////////////////

    public bool GetAxe=false;
    public bool GetShovel=false;
    public bool GetSpreader = false;
    public int SpreaderAmount = 0;
    public void SetSpreaderAmount(int amount) { SpreaderAmount = amount; }
    
    SpriteRenderer sprite;
    Animator animator;
    Rigidbody2D rigid;
    BoxCollider2D boxcol;

    //플레이어 체력
    private int HP;
    [SerializeField] private int MaxHP;
    public void SetHP(int amount) { HP = amount; UIElement.Instance.hpContainer.UpdateHPUI(); }
    public void IncreaseHP(int amount) { HP += amount; UIElement.Instance.hpContainer.UpdateHPUI(); }

    //플레이어 이동 관련 변수
    public float speed;
    float firstspeed;
    public float jumpPower;
    public LayerMask groundLayer;
    float h, v;

    //충돌 판정 관련 변수
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
        else
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
            if (Input.GetKey(KeyCode.W))
            {
                rigid.gravityScale = 0;
                isWall = true;
                sprite.flipX = true;
                transform.Translate(0, v, 0);
                animator.SetBool("isWall", true);
            }
        }
        else //if (Input.GetKeyUp(KeyCode.W))
        {
            rigid.gravityScale = 1;
            animator.SetBool("isWall", false);
            isWall = false;
        }
    }

    public void GetItem(ItemType type)
    {
        switch(type)
        {
            case ItemType.SHOVEL:
                GetShovel = true;
                break;
            case ItemType.SPREADER:
                GetSpreader = true;
                break;
            case ItemType.AXE:
                GetAxe = true;
                break;
        }

        UIElement.Instance.itemcontainer.Add(type);

    }

    #region 읽기 전용 변수
    public bool Return_isGround { get { return isGround; } }

    public bool Return_isWall { get {return isWall; } }
    
    public bool Return_isStarPiece { get { return isStarPiece; } }
    public bool Return_isSit { get { return isSit; } }

    public int Return_HP { get { return HP; } }

    public bool Return_SpriteFlipX { get { return sprite.flipX; } }


    #endregion
}
