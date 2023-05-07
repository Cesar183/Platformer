using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickIzquierdo : MonoBehaviour
{
    public Joystick joystick;
    public int velocidad;
    public Rigidbody2D rb;
    public bool conFisicas;
    public Animator animator;
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(joystick.Horizontal, joystick.Vertical);
        if (conFisicas)
        {
            rb.MovePosition(rb.position + direction * velocidad * Time.fixedDeltaTime);
        }
        else
        {
            gameObject.transform.Translate(direction * velocidad * Time.deltaTime);
        }
        if(direction.magnitude == 0)
        {
            Debug.Log(direction.magnitude);
            animator.SetBool("isWalking", false);
        }
        else if(direction.magnitude != 0)
        {
            Debug.Log(direction.magnitude);
            animator.SetBool("isWalking", true);
        }
        
    }
}
