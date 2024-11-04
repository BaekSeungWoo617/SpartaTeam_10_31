using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building1 : MonoBehaviour
{
 float moveSpeed;
    Vector3 moveDirection = new Vector3(0,0,-1);
    private void Start()
    {
        moveSpeed = GameManager.Instance.roadMoveSpeed;
    }
    private void Update()
    {
    }
    void FixedUpdate()
    {
        BuildingMove(moveDirection);
    }
    void BuildingMove(Vector3 direction)
    {      
        transform.Translate(direction * moveSpeed * Time.deltaTime);   
        if(this.transform.position.z < -120)
        {
            this.transform.position += new Vector3(0,0,220);
        }
    }
    void BuildingSetFalse()
    {
        if (this.transform.position.z < -120)
        {
            gameObject.SetActive(false);
        }
    }
}
