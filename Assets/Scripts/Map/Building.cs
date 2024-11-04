using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building1 : MonoBehaviour
{
 float moveSpeed;
    private void Start()
    {
        moveSpeed = GameManager.Instance.roadMoveSpeed;
    }
    private void Update()
    {
    }
    void FixedUpdate()
    {
        BuildingMove();
    }
    void BuildingMove()
    {
        Vector3 direction = Vector3.zero;
        if (this.CompareTag("LeftBuilding"))
        {
            direction = new Vector3(1, 0, 0);  
        }
        else if(this.CompareTag("RightBuilding"))
        {
            direction = new Vector3(-1, 0, 0);
        }
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        if (this.transform.position.z < -120)
        {
            this.transform.position += new Vector3(0,0,220);
        }
    }
    void BuildingSetFalse()
    {
            gameObject.SetActive(false);
    }
}
