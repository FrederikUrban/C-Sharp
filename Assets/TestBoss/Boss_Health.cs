using UnityEngine;

public class Boss_Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;
    public HPenemy healthBar;
    public int enrageHP = 50;
    public bool isInvulnerable = false;
    public GameObject CanvasObject;
    public float DieTime = 2f;
    public bool toStage2 = false;
    BoxCollider2D edge;

    private void Start()
    {
        edge = GetComponent<BoxCollider2D>();
        currentHealth = maxHealth;
        healthBar.SetmaxHealth(maxHealth);
    }

    private void Update()
    {
        if (isInvulnerable)
        {
            Vector2 newPos = healthBar.transform.parent.transform.position;
            newPos.y = 1.5f;
            healthBar.transform.parent.transform.position = newPos;
       //     Debug.Log("Parent" + healthBar.transform.parent.gameObject);
            Weapon1 a = GetComponent<Weapon1>();
            if (a==null)
            {
                return;
            }
            currentHealth += a.damage;
            //  isInvulnerable = false;
            return;
        }
    }



    public void TakeDamage(int damage)
    {
        /*  if (GetComponent<GollemMovement>())
          {
              FindObjectOfType<AudioManager>().Play("GolemHit");
          }
          */

        {
            FindObjectOfType<AudioManager>().Play("Boss_Hit");

            Debug.Log("TakeDamage");
            if (toStage2)
            {
                currentHealth += damage;

                healthBar.SetHealth(currentHealth);
            }
            else
            {

                currentHealth -= damage;

                healthBar.SetHealth(currentHealth);
                animator.SetTrigger("Hurt");
                Debug.Log("EnemyTakeDamege");

                if (currentHealth <= enrageHP)
                {

                    animator.SetBool("IsEnraged", true);
                    edge.enabled = true;
                    Debug.Log("IsEnraged");

                }

                if (currentHealth <= 0)
                {
                    //  StartCoroutine()
                    //  StartCoroutine(Die());
                    Die();
                }
            }
        }

    }

    private void Die()
    {
        FindObjectOfType<AudioManager>().Play("Boss_Death");
        ScoreCounter.ScoreVal += 10000;
        animator.SetBool("Dead",true);
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
}