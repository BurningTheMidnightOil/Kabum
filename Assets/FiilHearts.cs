using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiilHearts : MonoBehaviour
{
    [SerializeField] GameObject heartGameObject;

    Stack<GameObject> hearts = new Stack<GameObject>();
    void Start()
    {
        int numberOfLives = GameManager.Instance.GetLives();
        for(int i = 0; i < numberOfLives; i++){
            GameObject heart = Instantiate(heartGameObject, transform);
            hearts.Push(heart);
        }
        GameManager.Instance.call_OnLoseLife_Events += RemoveHeart;
    }

    void RemoveHeart(int numberOfLives){
        if(hearts.Count > 0) Destroy(hearts.Pop());
    }
}
