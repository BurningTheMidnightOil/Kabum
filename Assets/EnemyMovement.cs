using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float changeDirectionTime = 1.0f;
    [SerializeField] float enemyProbabilityToChange = 0.5f;
    [SerializeField] float boundary = 0.1f;

    enum Direction {Right, Left};

    Direction direction = Direction.Right;

    void Start(){
        StartCoroutine(ChangeDirection());
    }

    void Update(){
        if(direction == Direction.Right){
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
            LimitEnemyMovement();
        } else {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            LimitEnemyMovement();
        }
    }

    IEnumerator ChangeDirection(){
        while(true){
            yield return new WaitForSeconds(changeDirectionTime);
            if(Random.Range(0.0f, 1.0f) > enemyProbabilityToChange){
                if(direction == Direction.Right){
                    direction = Direction.Left;
                } else {
                    direction = Direction.Right;
                }
            }
        }
    }

    void LimitEnemyMovement()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, boundary, 1 - boundary);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
        if(pos.x == boundary || pos.x == (1 - boundary)){
            ChangeDirection();
        }
    }
}
