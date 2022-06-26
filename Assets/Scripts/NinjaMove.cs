using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NinjaMove : MonoBehaviour
{
    Rigidbody2D mrb;
    public float speedPower;
    public float jumpPower;
    float h;
    bool isGround;
    public Transform pos;
    public float checkRadius;
    public LayerMask islayer;
    int JumpCount;
    public int JumpCount2;
    public Animator animator;
    public int slimeCount = 8;


    void Awake()
    {
        mrb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        JumpCount = JumpCount2;
    }

    void Update()
    {
        isGround = Physics2D.OverlapCircle(pos.position, checkRadius, islayer);

        if(slimeCount <= 0)
        {
            SceneManager.LoadScene("ClearScene");
        }


        if(isGround == true && Input.GetKeyDown(KeyCode.F) && JumpCount > 0)
        {
            mrb.velocity = Vector2.up * jumpPower; 
            animator.SetBool("jump", true);
        }
        if(isGround == false && Input.GetKeyDown(KeyCode.F) && JumpCount > 0)
        {
            mrb.velocity = Vector2.up * jumpPower;
        }
        if(isGround && JumpCount != JumpCount2)
        {
            mrb.velocity = Vector2.zero;
            animator.SetBool("jump", false);
        }
        if(Input.GetKeyUp(KeyCode.F))
        {
            JumpCount--;
        }
        if(isGround)
        {
            JumpCount = JumpCount2;
        }
    }

    void FixedUpdate()
    {
        h = Input.GetAxisRaw("Horizontal");
        mrb.velocity = new Vector2(h * speedPower, mrb.velocity.y);

        if(h > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
            animator.SetBool("run", true);
        } else if(h < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
            animator.SetBool("run", true);
        } else
        {
            animator.SetBool("run", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.name == "Floor")
        {
            SceneManager.LoadScene("FailScene");
        }
    }
}
