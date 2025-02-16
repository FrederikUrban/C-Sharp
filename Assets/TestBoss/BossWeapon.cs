using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public int trigerDamage = 20;
    public int swordDamage = 40;
    private Animator animator;
    public Transform swordPoint;
    public Vector3 attackOffset;
    public float hitRange = 1f;
    public LayerMask hrac;
    public Collider2D playerCollider;

    /*	public void Start()
    {
		Collider2D playerCollider = GetComponent<PolygonCollider2D>();
    }

    public void Update()
    {
		if (playerCollider.isTrigger)
        {
			Debug.Log("PlayerCollider:" + playerCollider.isTrigger);
			Attack();
        }
    }*/

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHP player = hitInfo.GetComponent<PlayerHP>();
        //Debug.Log("OnTriggerEnter2D" + hitInfo.GetComponent<PlayerHP>());
        if (player == null)
        {
            return;
        }
        player.TakeDamage(trigerDamage);
    }

    public void Attack()
    {
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(swordPoint.position, hitRange, hrac);
        FindObjectOfType<AudioManager>().Play("SwAttack");
        foreach (Collider2D enemy in hitEnemy)
        {
            Debug.Log("Foreach"+enemy.name);

            if (enemy == null)
            {
                return;
            }
				enemy.GetComponent<PlayerHP>().TakeDamage(swordDamage);
			
		
        }

        if (animator == null)
        {
            return;
        }
      //  animator.SetTrigger("Attack");
      //  FindObjectOfType<AudioManager>().Play("Swoosh");
        //vytvori oblast okolo Swordpoint a zisti ci su tam nepriatelia

        /*  foreach (Collider2D boss in hitEnemy)
          {
          }
      */
    }

    public void SpellCast()
    {

    }
    /* public void Attack()
	  {
		  PlayerHP a =GetComponent<PlayerHP>();
		  a.TakeDamage(attackDamage);

		  Vector3 pos = transform.position;
		  pos += transform.right * attackOffset.x;
		  pos += transform.up * attackOffset.y;

		  Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, hrac);
		  if (colInfo != null)
		  {
			  colInfo.GetComponent<PlayerHP>().TakeDamage(attackDamage);
		  }
	  }

	  public void EnragedAttack()
	  {
		  Vector3 pos = transform.position;
		  pos += transform.right * attackOffset.x;
		  pos += transform.up * attackOffset.y;

		  Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, hrac);
		  if (colInfo != null)
		  {
			  colInfo.GetComponent<PlayerHP>().TakeDamage(enragedAttackDamage);
		  }
	  }*/

    private void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, hitRange);
    }
}