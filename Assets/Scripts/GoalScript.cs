using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
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

            collision.gameObject.GetComponent<BallScript>().Reset();
        }
    }
}