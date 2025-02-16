using UnityEngine;

public class Boss_IsInvulnerable : StateMachineBehaviour
{

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Boss_Health>().isInvulnerable = true;
        animator.GetComponent<Boss_Health>().toStage2 = true;
       // animator.GetComponent<Weapon1>().armor = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Boss_Health>().toStage2 = false;
        animator.GetComponent<Boss_Health>().isInvulnerable = false;
        //animator.GetComponent<Weapon1>().armor = false;
    }
}