using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " Tokens";
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Exit()
    {
        SceneManager.LoadScene("Start");
    }
}
