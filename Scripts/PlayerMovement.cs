using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] float speed = 2f;
    [SerializeField] float jump = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRb.velocity.y);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        
    }
    public void Jump()
    {
        playerRb.AddForce(Vector2.up * jump);
    }
}
