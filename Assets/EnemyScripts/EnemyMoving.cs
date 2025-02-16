using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{

    [SerializeField]
    GameObject bullet;
    public float Speed;
    public Transform StrelaBod;
    public float kickRange;
    public Animator animator;
    public Collider2D colider;
    public LayerMask zakladna;
    public float shootRange;
    private float distance;
    public Transform hrac;
    public Transform groundDetection;
    public float fireRate;
    float nextFire;
    public bool mustPatrol;
    public Rigidbody2D rb;
    private bool mustTurn;
    void Start()
  
    {
        mustPatrol = true;
        nextFire = Time.time; 
        
    }

     private void FixedUpdate()
     {
        if (mustPatrol)
        {
            mustTurn =!Physics2D.OverlapCircle(groundDetection.position, 0.1f, zakladna);
        }
        
     }
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
         
       

        }

        distance = Vector2.Distance(transform.position, hrac.position);


        if (Time.time > nextFire )
        {
            if (distance <= shootRange) {
               
                rb.velocity = Vector2.zero;

                if (hrac.position.x > transform.position.x && transform.localScale.x < 0 ||
                    hrac.position.x < transform.position.x && transform.localScale.x > 0)
                {
                    Flip();
                   
                }




                mustPatrol = false;
                
               
                Shoot();
                nextFire = Time.time + fireRate;

            }   else
            {
            mustPatrol = true;
            }

        }
    




    }



    private void Shoot()
    {
        animator.SetTrigger("Shoot"); 
        Instantiate(bullet, StrelaBod.position, StrelaBod.rotation);
    }
    void Patrol()
    {
        animator.SetTrigger("Run");
        if (mustTurn || colider.IsTouchingLayers(zakladna))
        {
            Flip();
        }
        rb.velocity = new Vector2(Speed * Time.fixedDeltaTime, rb.velocity.y);
        
      
        
    }
   void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        Speed *= -1;
        mustPatrol = true;
    }
   
   
}
