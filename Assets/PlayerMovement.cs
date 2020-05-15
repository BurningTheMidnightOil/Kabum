using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float boundary = 0.1f;
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) == true){
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            MoveRight();
        }
    }

    void MoveRight(){
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        LimitPlayerMovement();
    }

    void MoveLeft(){
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        LimitPlayerMovement();
    }

    void LimitPlayerMovement(){
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, boundary, 1 - boundary);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
