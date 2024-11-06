using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    float moveSpeed;
    Vector3 moveDirection = new Vector3(0,0,-1);
    private void Start()
    {
        moveSpeed = GameManager.Instance.roadMoveSpeed;
    }
    private void Update()
    {
        RoadSetFalse();
    }
    void FixedUpdate()
    {
        RoadMove(moveDirection);
    }
    void RoadMove(Vector3 direction)
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);   
    }
    void RoadSetFalse()
    {
        if (this.transform.position.z < -120)
        {
            gameObject.SetActive(false);
        }
    }
}
