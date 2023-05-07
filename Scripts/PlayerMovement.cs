using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] float speed = 2f;
    [SerializeField] float jump = 10f;
    [SerializeField] bool isGrounded = true;
    [SerializeField] Animator playerAnimator; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRb.velocity.y);
        if(Input.GetAxis("Horizontal") == 0)
        {
            playerAnimator.SetBool("isWalking", false);
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            playerAnimator.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            playerAnimator.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if(Input.GetKeyDown(KeyCode.Space)) // (Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        
    }
    public void Jump()
    {
        if(isGrounded)
        {
            playerRb.AddForce(Vector2.up * jump);
            isGrounded = false;
            playerAnimator.SetTrigger("Jump");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
