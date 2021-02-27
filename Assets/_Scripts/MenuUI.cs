using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] string StartScene = "";
    [SerializeField] GameObject instructorPanel = null;
    [SerializeField] GameObject creditsPanel = null;



    private void Start()
    {
        instructorPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void GoStart()
    {
        SceneManager.LoadScene(StartScene);
    }

    public void GoInstructor()
    {
        instructorPanel.SetActive(true);
    }
    public void GoCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void GoBack()
    {
        instructorPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }


    public void GoExit()
    {
        Application.Quit();
    }




}
