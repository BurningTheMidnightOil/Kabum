using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 0.03f;
    [SerializeField] float yLimit = -7f;
    void Update()
    {
        gameObject.transform.position += new Vector3(0, -movementSpeed, 0);

        if(gameObject.transform.position.y < yLimit){
            GameManager.Instance.LoseLife();
            Destroy(gameObject);
        }
    }
}
