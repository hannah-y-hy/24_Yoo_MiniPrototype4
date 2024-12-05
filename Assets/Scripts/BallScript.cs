using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector2 StartPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
        Launch();
    }

    // Starting over: this is a game reset function
    public void Reset()
    {
        Debug.Log("Ball is resetting...");  // 디버깅 메시지 추가
        rb.velocity = Vector2.zero;
        transform.position = StartPosition;
        Launch();
    }

    private void Launch()
    {
        float x = Random.Range(0.5f, 1f) == 0 ? -1 : 1;
        float y = Random.Range(0.5f, 1f) == 0 ? -1 : 1;

        // AddForce를 사용하여 공을 발사 / Apply force to launch the ball
        rb.AddForce(new Vector2(speed * x, speed * y), ForceMode2D.Impulse);
    }

    // 공이 플레이어 패들과 충돌했을 때 반사각 조정 / Adjust reflection angle when the ball hits a player paddle
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 패들에 맞은 위치에 따른 반사 각도 조정 / Adjust reflection angle based on where the ball hits the paddle
            float hitPoint = transform.position.y - collision.transform.position.y;
            float paddleHeight = collision.collider.bounds.size.y;

            // hitPoint를 사용해 공의 수직 반사각을 계산 / Calculate the vertical reflection angle based on hit point
            float reflectAngle = hitPoint / paddleHeight;

            // 수평 속도를 유지하면서 수직 속도를 반사 각도에 따라 조정 / Adjust vertical velocity while keeping horizontal velocity
            Vector2 newVelocity = new Vector2(rb.velocity.x, reflectAngle * speed);
            rb.velocity = newVelocity.normalized * speed;
        }
    }

    // 공이 화면 밖으로 나갔을 때 리스폰
    private void OnBecameInvisible()
    {
        Reset(); // 공을 다시 중앙으로 리스폰
    }
}