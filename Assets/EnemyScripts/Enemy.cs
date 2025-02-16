using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;
    public HPenemy healthBar;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetmaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (GetComponent<GollemMovement>())
        {
            FindObjectOfType<AudioManager>().Play("GolemHit");
        }
        else if (GetComponent<EnemyGhost>())
        {
            FindObjectOfType<AudioManager>().Play("GhostHit");
        }

        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        Debug.Log("EnemyTakeDamege");

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            /* StartCoroutine(*/
            StartCoroutine(Die());
        }
    }



    IEnumerator Die()
    {
        Debug.Log("enemy died");
        
        animator.SetBool("Dead", true);
        Destroy(GetComponent<GollemMovement>());
        Destroy(GetComponent<EnemyMoving>());
        if (GetComponent<GollemMovement>())
        {
            FindObjectOfType<AudioManager>().Play("GolemDead");
            yield return new WaitForSeconds(2);
            ScoreCounter.ScoreVal += 100;
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("GhostDead");
            yield return new WaitForSeconds(1);
            ScoreCounter.ScoreVal += 50;
        }


        GetComponent<Collider2D>().enabled = false; // vypne collider
        Destroy(gameObject);
        this.enabled = false; // vypne tento script
    }


}
