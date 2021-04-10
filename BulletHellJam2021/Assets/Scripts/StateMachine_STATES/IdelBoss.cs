using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdelBoss : StateMachineBehaviour
{
    private int rand;
    private Transform playerPos;
    private float timer;
    public float minTime;
    public float maxTime;
    public string[] state;
    public bool isHunter;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        //playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rand = Random.Range(0, state.Length);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Vector3 targetDitance = playerPos.position - animator.transform.position;

        if (timer <= 0)
        {

            animator.SetTrigger(state[Random.Range(0, state.Length)]);

        }
        else
        {
            timer -= Time.deltaTime;
        }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}