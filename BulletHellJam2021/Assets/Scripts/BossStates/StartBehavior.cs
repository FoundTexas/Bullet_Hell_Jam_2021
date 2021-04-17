using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBehavior : StateMachineBehaviour
{
    public string state1;
    public string state2;
    private int rand;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 2);

        if (rand == 0)
        {
            animator.SetTrigger(state1);
        }
        else
        {
            animator.SetTrigger(state2);
        }
    }

}
