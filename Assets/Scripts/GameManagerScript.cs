using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [Header("Ball")]
    public GameObject Ball;

    [Header("LeftPlayer")]
    public GameObject LeftPaddle;
    public GameObject LeftGoal;

    [Header("RightPlayer")]
    public GameObject RightPaddle;
    public GameObject RightGoal;

    [Header("ScoreUI")]
    public GameObject LeftText;
    public GameObject RightText;

    private int LeftScore;
    private int RightScore;
    
    private bool EventTriggered = false; // 특수 이벤트 발생 여부 / Whether the special event has triggered
    private GameObject EventPlayer; // 이벤트가 발생 중인 플레이어 / The player triggering the event
                                                            //* this player gets priority if the appearance swappping event is about to happen to both left & right players 

    public void LeftScored()
    {
        LeftScore++;
        LeftText.GetComponent<TextMeshProUGUI>().text = LeftScore.ToString();
        Ball.GetComponent<BallScript>().AddScore(); // It changes appearance and animation of the ball gameobject
        
        // 3점마다 특수 이벤트를 체크 / Checking the planned event every 3 points
        CheckForSpecialEvent(LeftPaddle);
    }

    public void RightScored()
    {
        RightScore++;
        RightText.GetComponent<TextMeshProUGUI>().text = RightScore.ToString();
        Ball.GetComponent<BallScript>().AddScore(); // It changes appearance and animation of the ball gameobject

        // 3점마다 특수 이벤트를 체크 / Checking the planned event every 3 points
        CheckForSpecialEvent(RightPaddle);
    }

    // 이벤트 확인 메서드 / Method to check for special event
    private void CheckForSpecialEvent(GameObject player)
    {
        // 다른 플레이어가 이미 이벤트를 진행 중이면 무시 / Ignore if another player is triggering the event
        if (EventTriggered && EventPlayer != player)
        {
            return;
        }

        int playerScore = player == LeftPaddle ? LeftScore : RightScore;

        // 점수가 3의 배수일 때 이벤트 발생 / Trigger event on multiples of 3
        if (playerScore % 3 == 0 && !EventTriggered)
        {
            EventTriggered = true;
            EventPlayer = player; // 이벤트 발생 플레이어 지정 / Set the player triggering the event
            SwapBallAndPaddle(player); // 공과 패들 교체 / Swap appearance between ball and paddle
        }
        else if (playerScore % 3 != 0 && EventTriggered && EventPlayer == player)
        {
            // 플레이어가 이벤트 범위를 벗어나면 이벤트 종료 / End event when player score is no longer a range of event trigger
            //* I might wanna go through UX flowchart page 2 for clarification
            ResetBallAndPaddle(player); 
            EventTriggered = false;
            EventPlayer = null; // 이벤트 플레이어 초기화 / Reset event player
        }
    }

    // 공과 패들의 외형 교체 (이벤트 플레이어 기준) / Swap appearance of ball and paddle based on the event player
    public void SwapBallAndPaddle(GameObject player)
    {
        Debug.Log("Special Event Triggered! Event player: " + player.name); // 디버깅 메시지 / Debugging message

        // 공의 스프라이트 및 크기 저장 / Store ball's sprite and size
        Sprite ballSprite = Ball.GetComponent<SpriteRenderer>().sprite;
        Vector2 ballScale = Ball.transform.localScale;

        // 패들의 스프라이트 및 크기 저장 / Store paddle's sprite and size
        Sprite paddleSprite = player.GetComponent<SpriteRenderer>().sprite;
        Vector2 paddleScale = player.transform.localScale;

        // 스프라이트 및 크기 교체 / Swap sprites' and size (ball gameobject and left/right paddle)
        Ball.GetComponent<SpriteRenderer>().sprite = paddleSprite;
        Ball.transform.localScale = paddleScale;

        player.GetComponent<SpriteRenderer>().sprite = ballSprite;
        player.transform.localScale = ballScale;

        ResetPositionsForEvent();
    }

    // 이벤트 종료 후 공과 패들 원래대로 복구 / Reset ball and paddle after event
    public void ResetBallAndPaddle(GameObject player)
    {
        Debug.Log("Resetting ball and paddle after event. Player: " + player.name); // 디버깅 메시지 / Debugging message

        // 공과 패들의 원래 스프라이트 복원 / Restore original sprites
        Ball.GetComponent<SpriteRenderer>().sprite = Ball.GetComponent<BallScript>().OriginalSprite;
        Ball.transform.localScale = Ball.GetComponent<BallScript>().OriginalScale;

        player.GetComponent<SpriteRenderer>().sprite = player.GetComponent<PlayerScript>().OriginalSprite;
        player.transform.localScale = player.GetComponent<PlayerScript>().OriginalScale;
    }


    // 이벤트 이후 리셋 메서드 / Reset positions after event
    public void ResetPositionsForEvent()
    {
        Ball.GetComponent<BallScript>().Reset(); // 공의 위치 리셋 / Reset ball position
        LeftPaddle.GetComponent<PlayerScript>().Reset(); // 왼쪽 패들 위치 리셋 / Reset left paddle position
        RightPaddle.GetComponent<PlayerScript>().Reset(); // 오른쪽 패들 위치 리셋 / Reset right paddle position

        EventTriggered = false; // 이벤트 상태 초기화 / Reset event state
    }

//Starting over: this is a game reset function 
    public void ResetPosition()
    {
        Debug.Log("Resetting ball and paddles");  // 디버깅 메시지 / Debug message about resetting position of the moving gameobjects
        Ball.GetComponent<BallScript>().Reset();
        LeftPaddle.GetComponent<PlayerScript>().Reset();
        RightPaddle.GetComponent<PlayerScript>().Reset();
    }

    }



