using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform target;
    bool isGround;
    public int SlimeHp;
    public GameObject player;
    public Vector2 home;

    [SerializeField]
    [Header("추격속도")] [Range(0f,10f)] float speed;

    [SerializeField]
    [Header("근접거리")] [Range(0f,10f)] float contactDistance = 1f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        home = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        FollowTarget();
        LookAtTarget();

        if(SlimeHp <= 0)
        {
            GameObject.Find("Player").GetComponent<NinjaMove>().slimeCount -= 1;
            DestroySlime();
        }
    }

    void FollowTarget()
    {
        if(Vector2.Distance(transform.position, target.position) < contactDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.position = new Vector2(transform.position.x, home.y);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, home, speed * Time.deltaTime);
        }
    }


    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<NinjaMove>().slimeCount -= 1;
            DestroySlime();
        }
    }


    void LookAtTarget()
    {
        if(transform.position.x > target.position.x)
        {
            transform.eulerAngles = new Vector2(0,0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0,180);
        }
    }

    void DestroySlime()
    {
        Destroy(gameObject);
    }

    public void SlimeTakeDamage(int damage)
    {
        SlimeHp -= 1;
    }
}
