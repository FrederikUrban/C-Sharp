using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMoving : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    public float Speed;
    public Transform StrelaBod;
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
    public Transform kickPoint;
   // public float kickRange = 0.5f;
    public LayerMask hracc;
    public int kickDamage=100;
    //GameObject Player;
    public float kickRate;
    float nextKick;
    PlayerHP target;
  //  public bool attack;
    public Transform KickBod;
    public float Range;
    void Start()

    {
        mustPatrol = true;
        nextFire = Time.time;
        nextKick = Time.time;

        rb = GetComponent<Rigidbody2D>();
       // target = GameObject.FindObjectOfType<PlayerHP>();

    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundDetection.position, 0.1f, zakladna);
        }

    }
    void Update()

    {

        distance = Vector2.Distance(transform.position, hrac.position);

        if (Time.time > nextKick)
        {
            Kickkk();
        }
        if (hrac.position.x > transform.position.x && transform.localScale.x < 0 ||
                    hrac.position.x < transform.position.x && transform.localScale.x > 0)
        {
            Flip();

        }

        if (mustPatrol)
        {
            Patrol();



        }



        // Kick();

        if (Time.time > nextFire)
        {
            if (distance <= shootRange && distance > Range)
            {

                //rb.velocity = Vector2.zero;


                //mustPatrol = false;

                Shoot();
                nextFire = Time.time + fireRate;

            }
            else
            {
                mustPatrol = true;
            }

        }





    }
    /* void Kick()
     {

         if (distance <= kickRange)
         {
             Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(kickPoint.position, kickRange, hracc);

             foreach (Collider2D aaa in hitPlayer)
             {
                 PlayerHP a = aaa.GetComponent<PlayerHP>();
                 a.TakeDamage(kickDamage);
                 Debug.Log("Kickkk");
                 animator.ResetTrigger("Run");
                 animator.SetTrigger("JeBlizko");
                 // PlayerHP aaa = hitPlayer.GetComponent<PlayerHP>();
                 // aaa.TakeDamage(kickDamage);
                 animator.ResetTrigger("JeBlizko");





             }
         }
     }
    */


    /*   private void OnTriggerEnter2D(Collider2D hitInfo)

       {
           PlayerHP enemy1 = hitInfo.GetComponent<PlayerHP>();
           enemy1.TakeDamage(kickDamage);
           Debug.Log("KICKCKCK");
       }*/



    private void Shoot()
    {

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

    /* private void OnTriggerEnter2D(Collider2D collision)
      {


          if (collision.gameObject.name.Equals("Hrac"))
          {
              //target.TakeDamage(kickDamage);
              Debug.Log("Playerkick");
              animator.SetTrigger("JeBlizko");
             Kick();
          }




      }*/
   /* void Kickkk()
    {
        attack = Physics2D.OverlapCircle(KickBod.position, Range, hracc);
        animator.ResetTrigger("Run");
        Debug.Log("FAchCi TO");

        if (attack && Time.time > nextKick )
            {
                   Debug.Log("IDIDIT");
                  animator.SetTrigger("JeBlizko");
                target.TakeDamage(kickDamage);
                Debug.Log("IDIDIT");
                nextKick = Time.time + kickRate;
            }
            if (mustTurn || colider.IsTouchingLayers(zakladna))
            {
                Flip();
            }
        

    }*/


    void Kickkk()
    {
        Collider2D[] janeviem = Physics2D.OverlapCircleAll(KickBod.position, Range, hracc);
        animator.ResetTrigger("Run");
        

        foreach(Collider2D a in janeviem)
        {
                PlayerHP aa=a.GetComponent<PlayerHP>();
                NewMethod(aa);
                Debug.Log("hp--");
                animator.SetTrigger("JeBlizko");
               // target.TakeDamage(kickDamage);
                Debug.Log("nextkIck");
                nextKick = Time.time + kickRate;
            
        }

       
      /*  if (mustTurn || colider.IsTouchingLayers(zakladna))
        {
            Flip();
        }
      */

    }

    public void NewMethod(PlayerHP aa)
    {
        
        aa.TakeDamage(kickDamage);
    }
}
