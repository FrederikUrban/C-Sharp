using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GollemMovement : MonoBehaviour
{
    /*[SerializeField]
    GameObject impactEffect;*/
    public float Speed;
    public Transform StrelaBod;
    public int damage = 40;
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
    public LineRenderer lineRenderer;
    
    void Start()

    {
        mustPatrol = true;
        nextFire = Time.time;

    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundDetection.position, 1f, zakladna);
        }

    }
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();

        }

        if (GetComponent<Enemy>().enabled==false)
        {
            this.enabled = false;
        }


        distance = Vector2.Distance(transform.position, hrac.position);


        if (Time.time > nextFire)
        {
            if (distance <= shootRange)
            {

                rb.velocity = Vector2.zero;

                if (hrac.position.x > transform.position.x && transform.localScale.x < 0 ||
                    hrac.position.x < transform.position.x && transform.localScale.x > 0)
                {
                    Flip();

                }




                mustPatrol = false;

                StartCoroutine(Shoot());
                
                nextFire = Time.time + fireRate;

            }
            else
            {
                mustPatrol = true;
            }

        }



    }



    IEnumerator Shoot()
    {
        animator.SetTrigger("Shoot");
        yield return new WaitForSeconds(1);
        
        RaycastHit2D hitInfo = Physics2D.Raycast(StrelaBod.position, StrelaBod.right);

       
         if (hitInfo)
        {
            PlayerHP Hrac = hitInfo.transform.GetComponent<PlayerHP>();
           
            if(Hrac != null)
            {
                Debug.Log("GolemStrelilHraca");
                Hrac.TakeDamage(damage);
            }
           // Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

            lineRenderer.SetPosition(0, StrelaBod.position);
            lineRenderer.SetPosition(1, hitInfo .point);

        }
        else
        {
            lineRenderer.SetPosition(0, StrelaBod.position);
            lineRenderer.SetPosition(1, StrelaBod.position + StrelaBod.right*100);
        }
        
  
        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.02f);
        lineRenderer.enabled = false;


    }
    void Patrol()
    {
        
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
        StrelaBod.right *= -1;
        Speed *= -1;
        mustPatrol = true;
    }


}
