using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyHealthBar healthBar;

    [Header("Options")]
    [SerializeField] private float speed;
    [SerializeField] private int attack;
    public float hp;
    [SerializeField] private float attackSpeed;

    [Header("States")]
    public bool isDie = false;

    private Animator animator;
    private Rigidbody rb;

    private bool isWalk = true;
    #region MonoBehaviour
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (isWalk)
        {
            Walk();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TouchPlayer();
        }
        if (other.gameObject.tag == "Bullet" && !isDie)
        {
            TouchBullet();
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isWalk = false;
        }
    }
    #endregion
    #region Walk
    void Walk()
    {
        animator.SetBool("Walk Forward", true);
        rb.velocity = new Vector3(0f, 0, -speed);
    }
    #endregion
    #region Touch
    void TouchPlayer()
    {
        isWalk = false;
        animator.SetBool("Walk Forward", false);
        StartCoroutine(AttackCorutine());
    }
    void TouchBullet()
    {
        hp -= PlayerController.instance.damage;
        healthBar.SetDamageText(PlayerController.instance.damage);
        isWalk = false;
        animator.SetBool("Walk Forward", false);
        if (hp <= 0)
        {
            isDie = true;
            animator.SetBool("Die", true);
            StartCoroutine(DieTimer());
        }
        else
        {
            animator.SetBool("Take Damage", true);
            StartCoroutine(TakeDamage());
        }
    }
    #endregion
    #region Timers
    IEnumerator DieTimer()
    {
        yield return new WaitForSeconds(1.7f);
        rb.constraints = RigidbodyConstraints.None;
        rb.useGravity = true;
        animator.enabled = false;
        yield return new WaitForSeconds(1);
        UpgradeSystem.instance.AddMoney(50);
        GameController.instance.countEnemy--;
        if (GameController.instance.countEnemy == 0)
        {
            GameController.instance.ChangeIsGo(true);
        }
        Destroy(healthBar);
        Destroy(gameObject);
    }
    IEnumerator TakeDamage()
    {
        yield return new WaitForSeconds(1f);
        if (!isDie)
        {
            isWalk = true;
        }
    }
    IEnumerator AttackCorutine()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(attackSpeed);
            var rand = Random.Range(0, 1);
            if (rand == 0 && !isDie)
            {
                animator.SetBool("Attack 01", true);
                yield return new WaitForSeconds(0.5f);
                PlayerController.instance.hp -= attack;
                PlayerController.instance.TakeDamage(25);

            }
            else if (!isDie)
            {
                animator.SetBool("Attack 02", true);
                yield return new WaitForSeconds(0.5f);
                PlayerController.instance.hp -= attack;
                PlayerController.instance.TakeDamage(25);
            }
        }
    }
    #endregion
}
