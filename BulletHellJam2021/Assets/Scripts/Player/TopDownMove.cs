using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMove : MonoBehaviour
{
    public CameraShake shake;
    public Transform weaponHolder;
    public Animator gunAnim;
    public Animator shotAnim;
    public Animator animator;
    public float moveSpeed = 15f;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;
    private bool facingRight = true;


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - rb.position;

        if(lookDir.x < 0) {
            FlipLeft();
        } else if(lookDir.x > 0) {
            FlipRight();
        }

        animator.SetFloat("DirectionX", lookDir.x);
        animator.SetFloat("DirectionY", lookDir.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        gunAnim.SetFloat("DirectionX", lookDir.x);
        gunAnim.SetFloat("DirectionY", lookDir.y);
        shotAnim.SetFloat("DirectionX", lookDir.x);
        shotAnim.SetFloat("DirectionY", lookDir.y);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void FlipRight() {
        facingRight = true;

        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    void FlipLeft() {
        facingRight = false;

        transform.rotation = Quaternion.Euler(0f, -180f, 0f);
    }

    public void Step() {
        FindObjectOfType<SoundManager>().Play("PlayerStep1");
        shake.ShakeCamera(2f, .1f);
    }
}