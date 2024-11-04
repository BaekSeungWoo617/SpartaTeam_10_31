using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    int gamescore;
    int gameHuddleCount;
    int gameLife;
    private void Start()
    {
        gamescore = GameManager.Instance.score;
        gameHuddleCount = GameManager.Instance.huddleCount;
        gameLife = GameManager.Instance.life;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Huddle1"))
        {
            gamescore += 1;
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Huddle2"))
        {
            gamescore += 2;
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Huddle3"))
        {
            gamescore += 3;
            collision.gameObject.SetActive(false);
        }
    }
}
