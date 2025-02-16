using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Boss_Weapon : MonoBehaviour
{
    public int damage = 200;
    public int enragedAttackDamage = 40;
    public Transform attackPoint;
    public Vector3 attackOffset;
    public float attackRange = 20f;
    public LayerMask hráč;
    public Animator animator;
    Rigidbody rb;
    public Collider2D playerCollider;
    Transform player;


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        PlayerHP player = hitInfo.GetComponent<PlayerHP>();
        Debug.Log("OnTriggerEnter2D" + hitInfo.GetComponent<PlayerHP>());

        player.TakeDamage(damage);

    }

   /*public void Attack()
    {
        Debug.Log("Atack");
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, hráč);

        Debug.Log("aa" + colInfo);
        if (colInfo != null)

        {
            colInfo.GetComponent<PlayerHP>().TakeDamage(damage);
        }

    }

        public void SwordAttack()
        {
        Debug.Log("swordAtack");
            Vector3 pos = transform.position;
            pos += transform.right * attackOffset.x;
            pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, swordAttackRange, hráč);

        Debug.Log("aa" + colInfo);
        if (colInfo != null)

        {
            colInfo.GetComponent<PlayerHP>().TakeDamage(damage);
        }*/
        // animator.SetTrigger("Attack");
        //  FindObjectOfType<AudioManager>().Play("Swoosh");
        //vytvori oblast okolo Swordpoint a zisti ci su tam nepriatelia
        /* Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, hráč);

          foreach (Collider2D enemy in hitPlayer)
          {
              enemy.GetComponent<PlayerHP>().TakeDamage(damage);
           }*/
    /*}

   void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
        Gizmos.DrawWireSphere(pos, swordAttackRange);
        Gizmos.DrawWireSphere(pos, spellRange);
        Gizmos.DrawWireSphere(pos, fireRange);

    }*/
}