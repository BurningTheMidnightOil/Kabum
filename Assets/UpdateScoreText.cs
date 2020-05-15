using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScoreText : MonoBehaviour
{
    [SerializeField] Text scoreText;
    void Start()
    {
        UpdateText(GameManager.Instance.GetScore());
        GameManager.Instance.call_OnChangeScore_Events += UpdateText;
    }

    void UpdateText(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
