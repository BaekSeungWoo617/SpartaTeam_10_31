using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huddle : MonoBehaviour
{
    // 장애물이 도로를 따라 움직이는 속도
    float moveSpeed;
    Vector3 moveDirection = new Vector3(0, 0, -1);
    
    private void Start()
    {
        moveSpeed = GameManager.Instance.roadMoveSpeed; // 도로 속도와 장애물 속도 동기화
    }

    private void FixedUpdate()
    {
        HuddleMove(moveDirection);
    }
    
    private void HuddleMove(Vector3 direction)
    {
        // moveSpeed에 따라 moveDirection 방향으로 장애물을 이동
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        
        // 일정 Z축 위치를 지나가면(카메라 촬영 범위 벗어나면) 위치 재설정
        if (this.transform.position.z < -120)
        {
            // 도로 상단의 시작 위치로 재배치, X축 위치는 랜덤으로 설정
            this.transform.position = new Vector3(Random.Range(-5f, 5f), 0, 100);
        }
    }
    
    // void HuddleSetFalse()
    // {
    //     gameObject.SetActive(false);
    // }
}