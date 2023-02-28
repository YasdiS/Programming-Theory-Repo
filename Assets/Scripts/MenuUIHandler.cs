using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highscore;

    private void Start()
    {
        GameManager.Instance.Load();
    }

    private void Update()
    {
        highscore.text = "Highscore : " + GameManager.Instance.nameInput + " " + GameManager.Instance.pointScore;
    }

    public void StartNew()
    {

        GameManager.Instance.playerHealth = new UnitHealth(100, 100);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ResetGame()
    {
        GameManager.Instance.ResetData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
