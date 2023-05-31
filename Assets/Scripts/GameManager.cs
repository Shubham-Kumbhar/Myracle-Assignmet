using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI dartText,scoreText,FinalScore;
    public GameObject[] GameOverDisableGameObjects,  GameOverEnableGameObjects;
    public Slider powerBar;
    public int score=0, noOfDarts=25;
    private void Update()
    {
        if (noOfDarts < 0)
        {
            gameEnd();
        }
        
    }
    private void FixedUpdate()
    {
        dartText.text = (noOfDarts+1).ToString();
        scoreText.text = score.ToString();
    }

    public void ScoreInc()
    {
        score+=10;
    }

    public void DartDec()
    {
        noOfDarts--;
    }
    void gameEnd()
    {
        Cursor.lockState = CursorLockMode.Confined;
        FinalScore.text = score.ToString();
        for (int i = 0; i < GameOverDisableGameObjects.Length; i++)
        {
            GameOverDisableGameObjects[i].SetActive(false);
        }
        for (int i = 0; i < GameOverEnableGameObjects.Length; i++)
        {
            GameOverEnableGameObjects[i].SetActive(true);
        } 
    }
    public void sceneLoader(int a)
    {
        SceneManager.LoadScene(a);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
