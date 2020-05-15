using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLifeText : MonoBehaviour
{
    [SerializeField] Text lifeText;
    void Start(){
        UpdateText(GameManager.Instance.GetLives());
        GameManager.Instance.call_OnLoseLife_Events += UpdateText;
    }

    void UpdateText(int numberOfLives){
        lifeText.text = "Lives: " + numberOfLives.ToString();
    }
}
