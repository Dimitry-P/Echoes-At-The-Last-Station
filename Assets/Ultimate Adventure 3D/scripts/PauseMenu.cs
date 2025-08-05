using SimpleFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;



public class PauseMenu : MonoBehaviour
{
    
    public FirstPersonController fps;
    public GameObject messageBox;
    public static bool isPaused = false;
    

    private void Start()
    {
        // Сделать курсор видимым
        Cursor.visible = true;
    }

    private void Update()
    {
        
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                
                if (isPaused)
                {
                ResumeGame();
               
            }
                else
                {
                PauseGame();
            }
            }
    }
    
    public void PauseGame()
    {
        messageBox.SetActive(true);
        Time.timeScale = 0.001f;
        fps.m_MouseLook.SetCursorLock(false);
        fps.enabled = false;
        isPaused = true;
        
    }

    public void EnableResumeButton()
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject;
        obj.GetComponent<Button>().interactable = false;
        obj.GetComponent<Button>().interactable = true;
    }




    public void ResumeGame()
    {
        Time.timeScale = 1f;
        fps.m_MouseLook.SetCursorLock(true);
        fps.enabled = true;
        messageBox.SetActive(false);
        isPaused = false;
    }


    public void Quit()
    {
        Application.Quit();
    }
}  

