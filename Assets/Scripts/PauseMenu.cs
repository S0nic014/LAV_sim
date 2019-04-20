using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public static bool isPaused;
    public GameObject pauseMenuUI;
    public GameObject LAV;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused){
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
        Time.timeScale=1f;
        isPaused=false;
        EditScriptsState(true);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Cursor.lockState=CursorLockMode.None;
        Cursor.visible=true;
        Time.timeScale=0f;
        EditScriptsState(false);
        isPaused=true;
    }

    public void LoadMenu()
    {   
        isPaused=false;
        Time.timeScale=1f;
        Debug.Log("Main Menu...");
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    void EditScriptsState(bool state)
    {
        MonoBehaviour[] scripts = LAV.GetComponents<MonoBehaviour>();

        if (state){
            
            foreach(MonoBehaviour script in scripts)
            {
            script.enabled = true;
            }
        }

        if (!state)
        {
            foreach(MonoBehaviour script in scripts)
            {
            script.enabled = false;
            }
        }
        
    }

    
}
