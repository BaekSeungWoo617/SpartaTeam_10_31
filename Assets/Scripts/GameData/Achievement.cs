using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement : MonoBehaviour
{
GameManager gameManager;
    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }

}
