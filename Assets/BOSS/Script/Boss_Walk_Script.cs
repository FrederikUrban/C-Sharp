using UnityEngine;

public class Boss_Walk_Script : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 3f;
    private Transform player;
    private Rigidbody2D rb;
    private Boss_Flip boss;
    private Boss_Weapon weapon;
    private float distance;
    public Transform hrac;
   // public float swordAttackRange = 8f;
    //public float spellRange = 25f;
    //public float fireRange = 10f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss_Flip>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

      /* if (Vector2.Distance(rb.position, player.position) <= spellRange && Vector2.Distance(rb.position, player.position) >= fireRange)
        {
            animator.SetTrigger("Spell");
                
        }
       else if (Vector2.Distance(rb.position, player.position) <= fireRange && Vector2.Distance(rb.position, player.position) >= spellRange)
        {
            animator.SetTrigger("Fire");
        }
        else if (Vector2.Distance(rb.position, player.position) <= swordAttackRange)
        {
            animator.SetTrigger("SwordAttack");
        }

        else if (Vector2.Distance(rb.position, player.position) <= attackRange  )
        {
            animator.SetTrigger("Attack");
        }
      */
      

        /* distance = Vector2.Distance(rb.position, hrac.position);
         if (distance <= attackRange)
         {
             animator.SetTrigger("Attack");
         }*/
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.ResetTrigger("Attack");
    }
}