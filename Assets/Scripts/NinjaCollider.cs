using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NinjaCollider : MonoBehaviour
{
    public float maxHp = 100;
    public float curHp;
    public HpBar hpBar;

    void Start()
    {
        curHp = maxHp;
        hpBar.SetMaxHp(maxHp);
    }

    void Update()
    {
        if(curHp <= 0)
        {
            SceneManager.LoadScene("FailScene");
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.tag == "Enemy")
        {
            TakeDamage(Random.Range(30,40));
        }
    }

    void TakeDamage(float damage)
    {
        curHp -= damage;

        hpBar.SetHp(curHp);
    }
}
