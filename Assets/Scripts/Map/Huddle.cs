using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuddleInteraction : MonoBehaviour
{
    float moveSpeed;
    Vector3 moveDirection = new Vector3(0, 0, -1);
    private void Start()
    {
        moveSpeed = GameManager.Instance.roadMoveSpeed;
    }
    private void Update()
    {
        HuddleSetFalse();
    }
    void FixedUpdate()
    {
        HuddleMove(moveDirection);
    }
    void HuddleMove(Vector3 direction)
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        if (this.transform.position.z < -120)
        {
            this.transform.position = new Vector3(Random.Range(-5f, 5f), 0, 100);
        }
    }
    void HuddleSetFalse()
    {
        gameObject.SetActive(false);
    }
}