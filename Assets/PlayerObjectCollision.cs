using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        GameObject other = collider.gameObject;
        GameManager.Instance.AddScore();
        Destroy(other);
    }
}
