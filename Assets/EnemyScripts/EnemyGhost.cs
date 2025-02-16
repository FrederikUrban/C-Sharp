using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhost : MonoBehaviour
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
        Destroy(GetComponent<EnemyMoving>());
        yield return new WaitForSeconds(1);
        GetComponent<Collider2D>().enabled = false; // vypne collider
        Destroy(gameObject);
        this.enabled = false; // vypne tento script
    }


}
