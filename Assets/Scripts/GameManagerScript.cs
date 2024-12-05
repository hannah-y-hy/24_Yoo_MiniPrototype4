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

    public void LeftScored()
    {
        LeftScore++;
        LeftText.GetComponent<TextMeshProUGUI>().text = LeftScore.ToString();
        Ball.GetComponent<BallScript>().Reset();
    }

    public void RightScored()
    {
        RightScore++;
        RightText.GetComponent<TextMeshProUGUI>().text = RightScore.ToString();
        Ball.GetComponent<BallScript>().Reset();
    }
}

