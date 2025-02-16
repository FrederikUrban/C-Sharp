using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth;
    public HP healthBar;
    public Animator animator;
    //public int frame;
    /* public Rigidbody2D Rb;
     public PolygonCollider2D Pc;
    public GameObject nohy;*/
  
    public GameObject Score;
    void Start()

    {
        Score.SetActive(false);
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }



        void FixedUpdate()
        {
             healthBar.SetHealth(CurrentHealth);
        }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        healthBar.SetHealth(CurrentHealth);

        animator.SetTrigger("Hurt");
        FindObjectOfType<AudioManager>().Play("PlayerHit");

        if (CurrentHealth <= 0)
        {

            Die();
        }
    }
    public void Die()
    {

        //StartCoroutine(Casovac());


        Debug.Log("died");
        animator.SetBool("Dead", true);
        FindObjectOfType<AudioManager>().Play("PlayerDead");
        GetComponent<Collider2D>().enabled = false;
        Destroy(GetComponent<Player_Movement>());
        Score.SetActive(true);
    







        /*{
            aktualnyCas = aktualnyCas* 2 * Time.deltaTime;
        }
 
        if (casSmrti >= 4) 
        {
            
        }*/



        this.enabled = false; // vypne tento script

        /*Destroy(Pc);
        Destroy(Rb);
        Destroy(nohy);*/
    }

    /*IEnumerator Casovac()

   {


       yield return new WaitUntil(() => frame >= 60);


         }
  */

}
