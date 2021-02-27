using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasUI : MonoBehaviour
{

    [SerializeField] GameObject losePanel = null;
    [SerializeField] GameObject winPanel = null;

    bool isPause;

    private void Start()
    {
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        isPause = false;
    }


    public void LoseCondition()
    {
        if (!isPause)
        {
            isPause = true;
            Time.timeScale = 0;
            losePanel.gameObject.SetActive(true);
        }
        else
        {
            isPause = false;
            Time.timeScale = 1;
            losePanel.gameObject.SetActive(false);
        }
    }

    public void WinCondition()
    {
        if (!isPause)
        {
            isPause = true;
            Time.timeScale = 0;
            winPanel.gameObject.SetActive(true);
        }
        else
        {
            isPause = false;
            Time.timeScale = 1;
            winPanel.gameObject.SetActive(false);
        }
    }

    public void RetryButton()
    {
        if (isPause)
        {
            isPause = false;
            Time.timeScale = 1;
            SceneManager.LoadScene("GameScene");
            losePanel.gameObject.SetActive(false);
        }
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
