using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector2 StartPosition;
    public Animator ani; // 애니메이터 추가 / this is animator

    public Sprite OriginalSprite; // 초기 스프라이트 / Original sprite
    public Vector2 OriginalScale; // 초기 크기 / Original scale
    
    private int score; // 득점 관리 / managing score addings

    // Start is called before the first frame update
    void Start()
    {
       // 초기 스프라이트 및 크기 저장 / Save the original sprite and scale
        OriginalSprite = GetComponent<SpriteRenderer>().sprite;
        OriginalScale = transform.localScale;

        StartPosition = transform.position;
        Launch();
    }

    //Starting over: this is a game reset function
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

    public void AddScore() // This method is called when getting score in order to change appearance and animation of the ball gameobject
    {
        score++;

        if (score == 1)
        {
            ani.SetTrigger("Chicken"); //Changes to chicken
        }
        else if (score == 2)
        {
            ani.SetTrigger("Cow"); //Changes to cow
        }
        else if (score >= 3)
        {
            score = 0; // If the score is 3 or higher, the sprite resets back to the hamster
            ani.SetTrigger("HamsterFront"); //Changes to Hamster
        }
    }

    // 공이 화면 밖으로 나갔을 때 리스폰
    private void OnBecameInvisible()
    {
        Reset(); // 공을 다시 중앙으로 리스폰
    }
}