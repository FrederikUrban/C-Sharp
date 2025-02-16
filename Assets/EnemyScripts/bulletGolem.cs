using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletGolem : MonoBehaviour
{
    public float moveSpeed = 15f;

    public Rigidbody2D rb;

    PlayerHP target;

    Vector2 moveDirection;

    public int damage = 25;

    public GameObject EnemyBullet;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerHP>();
        
        
       


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.name.Equals("Hrac"))
        {
            target.TakeDamage(damage);
            Debug.Log("PlayerHit");
            Destroy(EnemyBullet);




        }
        else
        {
            Destroy(EnemyBullet);
        }
    }


}

