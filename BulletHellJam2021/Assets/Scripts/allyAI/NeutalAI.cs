using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutalAI : MonoBehaviour
{
    public int team;
    public float maxSpeed;
    public float minHeight, maxHeight;
    public float damageTime = 0.5f;
    public int maxHealth;
    public float attackRate = 1f;
    public string enemyName;
    public Sprite enemyImage;
    public AudioClip collisionSound, deathSound;

    private int currentHealth;
    private float currentSpeed;
    private Rigidbody rb;
    protected Animator anim;
    private Transform groundCheck;
    private bool onGround;
    protected bool facingRight = false;
    private Transform target;
    protected bool isDead = false;
    private float zForce;
    private float walkTimer;
    private bool damaged = false;
    private float damageTimer;
    private float nextAttack;
    private AudioSource audioS;

    bool nullenemy;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        groundCheck = transform.Find("GroundCheck");
        target = FindClosestEnemy();
        //target = FindObjectOfType<EnemyTracker>().transform;
        currentHealth = maxHealth;
        audioS = GetComponent<AudioSource>();
    }

    Transform FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Transform closestEnemy = null;
        NeutralTracker[] allEnemies = GameObject.FindObjectsOfType<NeutralTracker>();

        foreach (NeutralTracker currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy && currentEnemy.team != team)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy.transform;
            }
        }

        nullenemy = closestEnemy == null;

        if (nullenemy)
        {
            //return GameObject.FindObjectOfType<Player>().transform;
        }
        else if (!nullenemy)
        {
            return closestEnemy.transform;
        }

        return closestEnemy;
    }

    void Update()
    {

        target = FindClosestEnemy();

        Debug.DrawLine(this.transform.position, target.position,Color.red);

        onGround = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        anim.SetBool("Grounded", onGround);
        anim.SetBool("Dead", isDead);

        if (!isDead)
        {
            facingRight = (target.position.x < transform.position.x) ? false : true;
            if (facingRight)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }


        if (damaged && !isDead)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageTime)
            {
                damaged = false;
                damageTimer = 0;
            }
        }

        walkTimer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            Vector3 targetDitance = target.position - transform.position;
            float hForce = targetDitance.x / Mathf.Abs(targetDitance.x);

            if (walkTimer >= Random.Range(1f, 2f))
            {
                zForce = Random.Range(-1, 2);
                walkTimer = 0;
            }

            if (Mathf.Abs(targetDitance.x) < 1.3f)
            {
                zForce = targetDitance.z / Mathf.Abs(targetDitance.z);
            }
            if (Mathf.Abs(targetDitance.x) < 0.4f)
            {
                hForce = 0;
            }
            if (Mathf.Abs(targetDitance.z) < 0.4f)
            {
                zForce = 0;
            }

            if (!damaged)
                rb.velocity = new Vector3(hForce * currentSpeed, 0, zForce * currentSpeed);

            anim.SetFloat("Speed", Mathf.Abs(currentSpeed));

            if (!nullenemy)
            {
                if (Mathf.Abs(targetDitance.x) < 0.4f && Mathf.Abs(targetDitance.z) < 0.4f && Time.time > nextAttack)
                {
                    anim.SetTrigger("Attack");
                    currentSpeed = 0;
                    nextAttack = Time.time + attackRate;
                }
            }
        }

        rb.position = new Vector3
            (
                rb.position.x,
                rb.position.y,
                Mathf.Clamp(rb.position.z, minHeight, maxHeight));
    }

    public void TookDamage(int damage, int kb)
    {
        if (!isDead)
        {
            rb.velocity = Vector3.zero;
            damaged = true;
            currentHealth -= damage;
            anim.SetTrigger("HitDamage");
            PlaySong(collisionSound);
            FindObjectOfType<UIManager>().UpdateEnemyUI(maxHealth, currentHealth, enemyName, enemyImage);
            rb.AddRelativeForce(new Vector3(1*kb, 2*kb, 0), ForceMode.Impulse);
            if (currentHealth <= 0)
            {
                isDead = true;
                rb.AddRelativeForce(new Vector3(3, 5, 0), ForceMode.Impulse);
                PlaySong(deathSound);
            }
        }
    }

    public void DisableEnemy()
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    void ResetSpeed()
    {
        currentSpeed = maxSpeed;
    }

    public void PlaySong(AudioClip clip)
    {
        audioS.clip = clip;
        audioS.Play();
    }
}
