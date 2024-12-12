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
        // 플레이어 구분에 따른 입력 처리 / Handle input based on player side
        if (isLeftPlayer)
        {
            movement = Input.GetAxisRaw("Vertical") + Input.GetAxis("joystick_1_Y");
        }
        else
        {
            movement = Input.GetAxisRaw("Vertical2") + Input.GetAxis("joystick_2_Y");
        }
    }

    // FixedUpdate는 물리 계산에 적합 / Ideal for physics calculations
    void FixedUpdate()
    {
        // AddForce를 사용하여 플레이어에게 힘을 가함 / Applying force to the player
        rb.AddForce(new Vector2(0, movement * speed), ForceMode2D.Force);

        // 속도 제한을 위해 Clamp 사용 / Limiting velocity using Clamp
        rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -speed, speed));
    }

    // Starting over: this is a game reset function
    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = StartPosition;
    }
}
