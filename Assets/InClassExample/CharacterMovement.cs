using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    /* 
        This script will control the movement of both characters
        The Character Manager will assign the value of the PlayerOne and PlayerTwo game objects 
    */


    public GameObject PlayerOne;
    public GameObject PlayerTwo;

    public Vector2 DirectionPlayerOne;
    public Vector2 DirectionPlayerTwo;

    public Rigidbody2D PlayerOneRB2D;
    public Rigidbody2D PlayerTwoRB2D;

    public float MoveSpeed = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // TODO:  Null check
        // Add bool Start that is true after player presses start button
        // Movement code should only works if start == true


        // First we'll do PlayerOne movement
        // PlayerOne will use the typical WASD keys
        // We need to modify the Horizontal and Vertical Ases in the Project Manager
        
        // First we will create the Vector2 for our AddForce()
        // DirectionPlayerOne.x = 0 means the first float in the Vector2 is 0.
        // Remember that this is a float: Input.GetAxisRaw("Horizontal")
        DirectionPlayerOne.x = Input.GetAxisRaw("Horizontal");
        DirectionPlayerTwo.y = Input.GetAxisRaw("Vertical");

        // We normalize the vector2 do we always move with the same speed even when moving diagonally
        // We can draw a picture in class
        DirectionPlayerOne = DirectionPlayerOne.normalized;

        // To use the Addforce() method we need a reference to the Rigidbody2D we want to move
        // The Addforce method is in the Rigidbody2D class, so every copy of Rigidbody2D will have the AddForce() method.  But to make PlayerOne move, we need to be sure we call the method in PlayerOne's Rigidbody2D !

        // We should assign this value (make this reference) when Start Button is pressed, we don;t want to make this assignment every frame.   
        PlayerOneRB2D = PlayerOne.GetComponent<Rigidbody2D>();

        PlayerOneRB2D.AddForce(DirectionPlayerOne * Time.deltaTime * MoveSpeed,ForceMode2D.Impulse);

        // Regulate Velocity if you want to
        // Becaude we are adding force, your characters will keep moving

        // the velocity of a rigidbody2D can be set to a maximum velocity  
        if (Mathf.Abs(PlayerOneRB2D.velocity.x) > (PlayerOneRB2D.velocity.x * MoveSpeed) || Mathf.Abs(PlayerOneRB2D.velocity.y) > PlayerOneRB2D.velocity.y * MoveSpeed)
        {
            // Set the velocity to the maximum here:  You can use MoveSpeed or you can use an additional float and call it MaximumVelocity if you want
            PlayerOneRB2D.velocity = DirectionPlayerOne * MoveSpeed; 
        }
    
    }
}


        // ---------------------------------------
        // Second we'll do PlayerTwo movement
        // PlayerTwo will use the Arrow Keys



    
