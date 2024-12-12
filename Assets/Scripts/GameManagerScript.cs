using TMPro;
using UnityEngine;
using System.Collections;

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

    [Header("Control Switch Timer UI")]
    public TextMeshProUGUI controlSwitchTimerText; // UI 텍스트 추가 / Added UI text for control switch timer

    private int LeftScore;
    private int RightScore;
    private bool isControlSwitched = false;
    private float controlSwitchCooldown = 60.0f; // 쿨타임 1분 / Cooldown time of 1 minute
    private float controlSwitchDuration = 10.0f; // 조작 변경 시간 10초 / Control switch duration of 10 seconds
    private float lastControlSwitchTime = -60.0f; // 마지막 스위치 시간 / Last switch time

    void Update()
    {
        // 조이스틱 버튼 또는 스페이스바를 누르면 컨트롤 스위치 시도 / Attempt control switch if any joystick button or spacebar is pressed
        if (Input.GetButtonDown("joystick button 0") || Input.GetButtonDown("joystick button 1") || Input.GetButtonDown("joystick button 2") || Input.GetButtonDown("joystick button 3") || Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastControlSwitchTime > controlSwitchCooldown && !isControlSwitched)
            {
                StartCoroutine(SwitchControls());
            }
        }
    }

    private IEnumerator SwitchControls()
    {
        Debug.Log("Switching controls between players");
        isControlSwitched = true;
        lastControlSwitchTime = Time.time;

        // 타이머 UI 표시 / Show timer UI
        StartCoroutine(DisplayControlSwitchTimer(controlSwitchDuration));

        // 플레이어 컨트롤 변경 / Switch player controls
       GoalScript leftPlayerScript = LeftPaddle.GetComponent<PlayerScript>();
        PlayerScript rightPlayerScript = RightPaddle.GetComponent<PlayerScript>();

        bool originalLeftPlayer = leftPlayerScript.isLeftPlayer;
        leftPlayerScript.isLeftPlayer = rightPlayerScript.isLeftPlayer;
        rightPlayerScript.isLeftPlayer = originalLeftPlayer;

        yield return new WaitForSeconds(controlSwitchDuration);

        // 컨트롤 원래대로 복구 / Restore original controls
        leftPlayerScript.isLeftPlayer = originalLeftPlayer;
        rightPlayerScript.isLeftPlayer = !originalLeftPlayer;
        isControlSwitched = false;

        Debug.Log("Control switch ended");
    }

    private IEnumerator DisplayControlSwitchTimer(float duration)
    {
        float remainingTime = duration;
        while (remainingTime > 0)
        {
            controlSwitchTimerText.text = "Control Switch: " + Mathf.CeilToInt(remainingTime).ToString() + "s";
            remainingTime -= Time.deltaTime;
            yield return null;
        }
        controlSwitchTimerText.text = ""; // 타이머가 끝나면 텍스트 지우기 / Clear the text after timer ends
    }

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