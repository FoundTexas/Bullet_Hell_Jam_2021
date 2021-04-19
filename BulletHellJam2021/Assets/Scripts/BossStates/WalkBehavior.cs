using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkBehavior : StateMachineBehaviour
{
    public bool ActiveTracking;
    public float minHeight, maxHeight;
    public float LeftLimit, RightLimit;

    public string[] state;

    public float minTime;
    public float maxTime;

    private Transform playerPos;
    private float timer;
    public float speed;

    Vector2 target;
    Vector2 targetDitance;

    float hForce;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = FindObjectOfType<Player>().transform;
        
        timer = Random.Range(minTime, maxTime);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer -= Time.deltaTime;

        if (ActiveTracking)
        {
            playerPos = FindObjectOfType<Player>().transform;

        }
        targetDitance = playerPos.position - animator.transform.position;
        hForce = targetDitance.x / Mathf.Abs(targetDitance.x);
        float zForce = Random.Range(-5, 5);

        if (Mathf.Abs(targetDitance.x) < 0.5f)
        {
            zForce = 0;
        }
        if (Mathf.Abs(targetDitance.y) < 0.5f)
        {
            zForce = 0;
        }

        target = new Vector2(playerPos.position.x, playerPos.transform.position.y + zForce);

        animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);

        //float minWidth = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)).x;
        //float maxWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 10)).x;
        animator.transform.position = new Vector2(animator.transform.position.x,
            Mathf.Clamp(animator.transform.position.y, minHeight, maxHeight));

        /*if (Vector2.Distance(animator.transform.position, target) < 0.01f)
        {
            animator.SetTrigger(state[Random.Range(0, state.Length)]);
        }*/

        if (timer <= 0)
        {
            animator.SetTrigger(state[Random.Range(0,state.Length)]);

        }
    }


}