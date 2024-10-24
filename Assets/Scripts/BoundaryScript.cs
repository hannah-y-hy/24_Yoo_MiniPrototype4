using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // 공이 화면 경계 밖으로 나가면 리셋 / Resetting the position of the ball gameobject if it collides with left or right boundaries
            collision.gameObject.GetComponent<BallScript>().Reset();
        }
    }
}
