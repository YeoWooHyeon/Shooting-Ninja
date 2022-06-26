using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaAttack : MonoBehaviour
{
    Animator animator;
    float curTime;
    public float coolTime;
    public Transform pos;
    public Vector2 boxSize;
    public float attackDelay;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if(curTime <= 0)
        {
            if(Input.GetKeyDown(KeyCode.D))
            {
                StartCoroutine(attack());

                animator.SetTrigger("atk");
                curTime = coolTime;
            }
        }
        else
        {
            curTime -= Time.deltaTime;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

    IEnumerator attack()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        foreach(Collider2D collider in collider2Ds)
        {
            if(collider.tag == "Enemy")
            {
                yield return new WaitForSeconds(attackDelay);
                collider.GetComponent<Slime>().SlimeTakeDamage(1);
            }
        }
    }
}
