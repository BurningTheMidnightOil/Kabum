using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float boundary = 0.1f;
    bool moveRight = false;
    bool moveLeft = false;
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) == true || moveLeft){
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            LimitPlayerMovement();
        } else if (Input.GetKey(KeyCode.RightArrow) == true || moveRight)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
            LimitPlayerMovement();
        }
    }

    public void MoveRight(){
        moveRight = true;
    }

    public void MoveLeft(){
        moveLeft = true;
    }

    public void StopMovement(){
        moveLeft = false;
        moveRight = false;
    }

    void LimitPlayerMovement(){
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, boundary, 1 - boundary);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
