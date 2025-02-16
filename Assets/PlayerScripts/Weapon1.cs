using UnityEngine;

public class Weapon1 : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage;
    public GameObject Impact;

    //  public bool armor = false;

    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)

    {
        Boss_Health a = GetComponent<Boss_Health>();
        Debug.Log("Trigger");
        EnemyGhost enemy1 = hitInfo.GetComponent<EnemyGhost>();

        if (enemy1 = hitInfo.GetComponent<EnemyGhost>())

        {
            Debug.Log("enemy1");
            enemy1.TakeDamage(damage);
            Instantiate(Impact, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
        else
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy = hitInfo.GetComponent<Enemy>())
            {
                Debug.Log("enemy2");
                enemy.TakeDamage(damage);
            }
            else
            {
                Boss_Health enemy2 = hitInfo.GetComponent<Boss_Health>();
                if (enemy2 = hitInfo.GetComponent<Boss_Health>())

                {
                    /*if (armor)
                    {
                        Debug.Log("isInvulnerable");
                        return;
                        // enemy2.TakeDamage(damage * (-2));
                    }
                    else*/

                    Debug.Log("boss");
                    enemy2.TakeDamage(damage);
                }
            }
        }

        Instantiate(Impact, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
