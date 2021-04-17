using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBehavior : StateMachineBehaviour
{
    public float minHeight, maxHeight;
    public int team;

    public string[] state;

    public float minTime;
    public float maxTime;

    private Transform playerPos;
    private float timer;

    Vector3 target;
    public Vector3 targetDitance;

    bool nullenemy;
    Transform FindClosestEnemy(Animator animator)
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Transform closestEnemy = null;
        NeutralTracker[] allEnemies = GameObject.FindObjectsOfType<NeutralTracker>();

        foreach (NeutralTracker currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - animator.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy && currentEnemy.team != team)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy.transform;
            }
        }
        nullenemy = closestEnemy == null;
        if (closestEnemy == null)
        {
            NeutralTracker[] Enemies = GameObject.FindObjectsOfType<NeutralTracker>();
            foreach (NeutralTracker currentEnemy in Enemies)
            {
                float distanceToEnemy = (currentEnemy.transform.position - animator.transform.position).sqrMagnitude;
                if (distanceToEnemy < distanceToClosestEnemy && distanceToEnemy > 0)
                {
                    distanceToClosestEnemy = distanceToEnemy;
                    closestEnemy = currentEnemy.transform;
                }
            }
        }

        return closestEnemy;
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = FindClosestEnemy(animator);
        int rx = Random.Range(-2, 2);

        if(rx > 0)
        {
            target = new Vector3(playerPos.position.x +rx, animator.transform.position.y, playerPos.transform.position.z + 1.5f);
        }
        else if(rx <= 0)
        {
            target = new Vector3(playerPos.position.x +rx, animator.transform.position.y, playerPos.transform.position.z - 1.5f);
        }

        animator.transform.position = target;
        animator.SetTrigger(state[Random.Range(0, state.Length)]);
        float minWidth = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)).x;
        float maxWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 10)).x;
        animator.transform.position = new Vector3(animator.transform.position.x,
            animator.transform.position.y,
            Mathf.Clamp(animator.transform.position.z, minHeight, maxHeight));

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
