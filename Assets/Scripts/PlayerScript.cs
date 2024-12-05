using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool isLeftPlayer;
    public float speed;
    public Rigidbody2D rb;
    public Vector2 StartPosition;

    private float movement;

    void Start()
    {
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeftPlayer)
        {
            movement = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement = Input.GetAxisRaw("Vertical2");
        }
    }

    // FixedUpdate는 물리 계산에 적합 / Just learned that FixedUpdate is ideal for physics calculations so decided use that thing
    void FixedUpdate()
    {
        // AddForce를 사용하여 플레이어에게 힘을 가함 / Applying force to the player using AddForce
        rb.AddForce(new Vector2(0, movement * speed), ForceMode2D.Force);

        // 최대 속도 제한 / Limiting the max speed
        if (rb.velocity.y > speed)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
        else if (rb.velocity.y < -speed)
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
        }
    }

    // Starting over: this is a game reset function
    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = StartPosition;
    }
}
