using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowGameOverScreen : MonoBehaviour
{
    [SerializeField] Text scoreText;
    void Start()
    {
        GameManager.Instance.call_OnGameOver_Events += Show;
        gameObject.SetActive(false);
    }

    void Show(){
        gameObject.SetActive(true);
        scoreText.text = "Your Score: " + GameManager.Instance.GetScore().ToString();
    }
}
