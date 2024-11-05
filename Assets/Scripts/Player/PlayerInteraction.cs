using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    int gameScore;
    int gameLife;
    int gameHighScore;

    private void Start()
    {
        gameScore = GameManager.Instance.score;
        gameLife = GameManager.Instance.life;
        gameHighScore = GameManager.Instance.highScore;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Huddle1")|| other.CompareTag("Huddle2")|| other.CompareTag("Huddle3"))
        {
            gameLife -= 1;

            Vector3 newPosition = other.transform.position + new Vector3(Random.Range(-5f, 5f), 0, 100);
            other.transform.position = newPosition;
        }
        if(gameLife<=0)
        {
            GameManager.Instance.GameOver();
        }
    }
}

