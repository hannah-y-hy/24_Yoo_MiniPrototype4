using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    // 2D Platformer movement code Modified by Melanie Stegman from this: 
    // https://stackoverflow.com/questions/62334560/how-do-i-keep-a-constant-velocity-in-unity-2d
    // Only running left and right and jumping up on Y, not ading any force on Y with AddForce
    // Maximum horizontal Velocity Management built in 

    private Rigidbody2D PlayerOneRB2D;
    public float MoveSpeed = 10f;
    public float MaximumVelocity = 10f;
    public float JumpVelocity = 10f;
    public bool isGrounded;
    
    void Start()
    {
        PlayerOneRB2D = GetComponent<Rigidbody2D>();// the RB2D on the attached GO
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal movement with max speed
        if(Input.GetAxisRaw("Horizontal") == 1 && PlayerOneRB2D.velocity.x <= MaximumVelocity)
        {
            PlayerOneRB2D.AddForce(Vector2.right * MoveSpeed, ForceMode2D.Force);
        }
        else if(Input.GetAxisRaw("Horizontal") == -1 && PlayerOneRB2D.velocity.x >= -MaximumVelocity)
        {
            PlayerOneRB2D.AddForce(Vector2.right * -MoveSpeed, ForceMode2D.Force);
        }

        // Jumping 
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            PlayerOneRB2D.velocity = Vector2.up * JumpVelocity;
        }
    }
}
