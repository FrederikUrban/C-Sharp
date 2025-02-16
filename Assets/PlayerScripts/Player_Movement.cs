using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public CharacterController2D controller; //referenica na CharacterController

    public Transform swordPoint; // referencia ma bod SwordPoint
    public float attackRange = 0.5f;
    public LayerMask enemyL; //vrstva nepriatelov

    public Animator animator;
    public float runSpeed = 40f;
    private float horizontalMove = 0f;
    private bool jump = false;

    // bool crouch = false;
    public int attackDamage = 80;

    private float nextAttack = 0f;
    public float attackRate = 2f;
    public float attackRate1 = 90f;

    private void Update()
    {
        if (Time.time >= nextAttack)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
        }

        void Shoot()
        {
            FindObjectOfType<AudioManager>().Play("PlayerShoot");
            animator.SetTrigger("Shooting");
            nextAttack = Time.time + 1f / attackRate1;
        }

        //vystup -1 alebo 1              * 40
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        // vzdy kladne cislo
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            FindObjectOfType<AudioManager>().Play("Jump");
            jump = true;
            animator.SetBool("Jumping", true);
        }

        //sleduje aktualny cas
        if (Time.time >= nextAttack)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Attack();
                nextAttack = Time.time + 1f / attackRate;
            }
        }
    }

    public void Landing()
    {
        animator.SetBool("Jumping", false);
    }

    private void FixedUpdate() //fixovany pocet
    {                                     // konsistentny pohyb,krcenie , skok        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        jump = false;
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
        FindObjectOfType<AudioManager>().Play("Swoosh");
        //vytvori oblast okolo Swordpoint a zisti ci su tam nepriatelia
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(swordPoint.position, attackRange, enemyL);

        foreach (Collider2D enemy in hitEnemy)
        {
            if (enemy.GetComponent<Enemy>())
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
            else
            {
                enemy.GetComponent<Boss_Health>().TakeDamage(attackDamage);
            }
        }

        /*  foreach (Collider2D boss in hitEnemy)
          {
          }
      */
    }
}