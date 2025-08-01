using SimpleFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SceneHelper : MonoBehaviour
{
    public FirstPersonController fps;

    private void Start()
    {
        // Сделать курсор видимым
        Cursor.visible = true;
    }

    public static void RestartLevel()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Trigger.buttonWasPushedOnce = true;
    }
    public static void LoadLevel(int buildIndex)
    {
        //fps.m_MouseLook.SetCursorLock(true);
        //fps.enabled = true;
        //messageBox.SetActive(false);

        Time.timeScale = 1f;
        PauseMenu.isPaused = false;
        Cursor.visible = true;
        SceneManager.LoadScene(buildIndex);
        Trigger.buttonWasPushedOnce = true;
        Teleporter.threeButtonsPushed = false;
        Trigger2.secondButtonIsOn = false;
    }


    public static void Quit()
    {
        Application.Quit();
    }
}

