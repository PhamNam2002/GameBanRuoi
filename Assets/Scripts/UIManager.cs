using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    public void SetScoreText(string txt)
    {
        if (scoreText)
        {
            scoreText.text = txt;
        }
    }
    public void ShowGameOverPanel(bool isShow)
    {
        if (gameOverPanel)
        {
            gameOverPanel.SetActive(isShow);
        }

    }
}
