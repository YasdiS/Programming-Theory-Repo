using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject GameOverText;
    [SerializeField] GameObject HighScore;
    [SerializeField] TMP_InputField inputField;

    public int score;
    public string namePlayer;

    private bool gameOver = false;

    void Update()
    {
        if (gameOver)
        {
            if (score > LoadPoints())
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SavePoints();
                    SceneManager.LoadScene(0);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }

    public void GameOver()
    {
        gameOver = true;

        if (score > LoadPoints())
        {
            HighScore.SetActive(true);
        }
        else
        {
            GameOverText.SetActive(true);
        }
    }

    public void SavePoints()
    {
        if (score > LoadPoints())
        {
            namePlayer = inputField.text;

            GameManager.Instance.pointScore = score;
            GameManager.Instance.nameInput = namePlayer;
            GameManager.Instance.Save();
        }
    }

    public int LoadPoints()
    {
        GameManager.Instance.Load();
        int LoadPoints = GameManager.Instance.pointScore;

        return LoadPoints;
    }
}
