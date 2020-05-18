using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int numberOfLives = 3;
    [SerializeField] GameObject gameStartScreen;
    [SerializeField] GameObject leftButton;
    [SerializeField] GameObject rightButton;
    int score = 0;

    public delegate void OnLoseLife(int numberOfLives);
    public event OnLoseLife call_OnLoseLife_Events;

    public delegate void OnChangeScore(int score);
    public event OnChangeScore call_OnChangeScore_Events;

    public delegate void OnStartGame();
    public event OnStartGame call_OnStartGame_Events;

    public delegate void OnGameOver();
    public event OnGameOver call_OnGameOver_Events;

    static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();

                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<GameManager>();
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //Setup initial conditions
        Time.timeScale = 0;
    }

    public void LoseLife(){
        if(numberOfLives > 0) numberOfLives--;
        if(call_OnLoseLife_Events != null){
            call_OnLoseLife_Events(numberOfLives);
        }
        if(CheckIfGameOver()){
            GameOver();
        }
    }

    public void AddScore(){
        score++;
        if(call_OnChangeScore_Events != null){
            call_OnChangeScore_Events(score);
        }
    }

    public int GetLives(){
        return numberOfLives;
    }

    public int GetScore(){
        return score;
    }

    bool CheckIfGameOver(){
        return numberOfLives == 0;
    }

    void GameOver(){
        Time.timeScale = 0;
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        if (call_OnGameOver_Events != null)
        {
            call_OnGameOver_Events();
        }
    }

    public void Retry(){        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame(){
        Time.timeScale = 1;
        gameStartScreen.SetActive(false);
        leftButton.SetActive(true);
        rightButton.SetActive(true);
        if (call_OnStartGame_Events != null)
        {
            call_OnStartGame_Events();
        }
    }

    public void QuitGame(){
        Application.Quit();
    }
}
