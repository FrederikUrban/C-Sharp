using UnityEngine;

public class Boss_run : StateMachineBehaviour
{
    public float swordAttackRange = 8f;
    public float fireRange = 10f;
    public float spellRange = 25f;
    public float speed = 2.5f;
    private Transform player;
    private Rigidbody2D rb;
    private Boss boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Vector2.Distance(rb.position, player.position) <= swordAttackRange)
        {
            animator.SetTrigger("SwordAttack");
        }
        else if (Vector2.Distance(rb.position, player.position) > swordAttackRange && Vector2.Distance(rb.position, player.position) <= fireRange)//&& Vector2.Distance(rb.position, player.position) < spellRange)
        {
            Debug.Log("Fire");
            animator.SetTrigger("Fire");
            return;
        }
        else if (Vector2.Distance(rb.position, player.position) > fireRange && Vector2.Distance(rb.position, player.position) <= spellRange)
        {
            //Debug.Log("Spell");
            animator.SetTrigger("Spell");
        }else
        {
            return;
        }
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("SwordAttack");
        animator.ResetTrigger("Fire");
        animator.ResetTrigger("Spell");
    }
}