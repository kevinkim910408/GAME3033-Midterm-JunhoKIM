using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{

    [SerializeField] GameObject losePanel = null;
    [SerializeField] GameObject winPanel = null;
    [SerializeField] GameObject pausePanel = null;
    [SerializeField] Text winScore = null;
    [SerializeField] Text loseScore = null;

    PlayerController playerController;

    // bgm
    [SerializeField] GameObject bgm = null;


    public bool isPause;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Start()
    {
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        pausePanel.SetActive(false);

        isPause = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void LoseCondition()
    {
        if (!isPause)
        {
            bgm.SetActive(false);
            playerController.PlaySound("DIE");
            loseScore.text = "Score: " + playerController.currentScore.ToString();
            isPause = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
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
            bgm.SetActive(false);
            playerController.PlaySound("WIN");
            winScore.text = "Score: " + playerController.currentScore.ToString();
            isPause = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
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
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
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

    // button pause
    public void OnPause()
    {
        if (!isPause)
        {
            isPause = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            pausePanel.gameObject.SetActive(true);
        }
    }

 

    public void OnResume()
    {
        if (isPause)
        {
            isPause = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            pausePanel.gameObject.SetActive(false);
        }
    }
}
