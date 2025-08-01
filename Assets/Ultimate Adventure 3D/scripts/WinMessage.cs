using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFPS;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System;

[RequireComponent(typeof(AudioSource))]

public class WinMessage : MonoBehaviour
{
    [SerializeField] private GameObject messageBox;
    [SerializeField] private UnityEvent Enter;
    [SerializeField] private UnityEvent Exit;
    private AudioSource audio;
    private bool showOneTine = false;
    private int one = 1;
    

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
       FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if (fps != null && showOneTine == false)
        {
            Enter.Invoke();
            ShowMessage();
            audio.Play();
            showOneTine = true;
            Time.timeScale = 0f;
            fps.enabled = false;
        }
    }

    private void ShowMessage()
    {
        messageBox.SetActive(true);
    }

    private void Update()
    {
        if(showOneTine == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneHelper.LoadLevel(one);
                Time.timeScale = 1;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneHelper.Quit();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if (fps != null)
        {
            Exit.Invoke();
        }
    }
}
