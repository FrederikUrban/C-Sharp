using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage;
    public GameObject Impact;
    private PlayerHP target;
    private Vector2 moveDirection;
    public float moveSpeed = 15f;
    public GameObject bossBullet;


    private void Start()
    {
        target = GameObject.FindObjectOfType<PlayerHP>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)

    {
        if (hitInfo.gameObject.name.Equals("Hrac"))
        {
            target.TakeDamage(damage);
            Debug.Log("PlayerHit");
            
            Instantiate(Impact, transform.position, Quaternion.identity);
            Destroy(bossBullet);
        }

        //   Destroy(gameObject);
    }
}