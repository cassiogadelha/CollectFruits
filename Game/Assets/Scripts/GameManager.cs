using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameNameTxt;
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI pressToStartTxt;

    public float score;
    public bool startGame;

    void Start()
    {
        scoreTxt.gameObject.SetActive(false);
        startGame = false;
    }

    public void StartGame()
    {
        startGame = true;
        score = 0f;
        scoreTxt.gameObject.SetActive(true);
        gameNameTxt.gameObject.SetActive(false);
        pressToStartTxt.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameNameTxt.gameObject.SetActive(true);
        gameNameTxt.text = "GAME OVER!";
        Invoke("RestartGame", 5f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && startGame == false)
        {
            StartGame();
        }

        if(startGame)
        {
            scoreTxt.text = "PONTOS: " + score; 
        }
    }
}
