using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
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
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 2f);
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.name.Equals("Hrac"))
        {
             target.TakeDamage(damage);
             Debug.Log("PlayerHit");
             Destroy(EnemyBullet);

           

          
        }
     
        
            
        
    }
        

}  

