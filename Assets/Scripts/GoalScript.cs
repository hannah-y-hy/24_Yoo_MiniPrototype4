using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    //How to set true or false for this bool: checkbox on the inspector panel
    public bool isLeftGoal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (isLeftGoal)
            {
                Debug.Log("Right player scored");
                GameObject.Find("GameManager").GetComponent<GameManagerScript>().RightScored();
            }
            else
            {
                Debug.Log("Left player scored");
                GameObject.Find("GameManager").GetComponent<GameManagerScript>().LeftScored();
            }

        // 득점 후 공을 리셋 / Resetting the position of the ball gameobject
        collision.gameObject.GetComponent<BallScript>().Reset();
        }
    }

}

