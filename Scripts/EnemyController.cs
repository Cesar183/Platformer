using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D enemyRB;
    SpriteRenderer enemySpriteRenderer;
    Animator enemyAnimator;
    [SerializeField] float timeBeforeChange;
    [SerializeField] float delay = 0.5f;
    [SerializeField] float speed = 3f;
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRB.velocity = Vector2.right * speed;
        if(speed > 0)
            enemySpriteRenderer.flipX = false;
        else if(speed < 0)
            enemySpriteRenderer.flipX = true;
        if(timeBeforeChange < Time.time)
        {
            speed *= -1;
            timeBeforeChange = Time.time + delay;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(transform.position.y + 0.3f < collision.transform.position.y)
            {
                enemyAnimator.SetBool("isDead", true);
                Invoke("DisableEnemy", 1f);
            }
        }
    }
    public void DisableEnemy()
    {
        gameObject.SetActive(false);
    }
}
