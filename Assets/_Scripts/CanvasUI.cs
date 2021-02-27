using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasUI : MonoBehaviour
{

    [SerializeField] GameObject losePanel = null;
    [SerializeField] GameObject winPanel = null;
    [SerializeField] GameObject pausePanel = null;

    public bool isPause;

    private void Start()
    {
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        pausePanel.SetActive(false);

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
        if (isPause)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MenuScene");
        }
        if (!isPause)
        {
            SceneManager.LoadScene("MenuScene");
        }
    }

    public void OnPause()
    {
        if (!isPause)
        {
            isPause = true;
            Time.timeScale = 0;
            pausePanel.gameObject.SetActive(true);
        }
    }

    public void OnResume()
    {
        if (isPause)
        {
            isPause = false;
            Time.timeScale = 1;
            pausePanel.gameObject.SetActive(false);
        }
    }
}
