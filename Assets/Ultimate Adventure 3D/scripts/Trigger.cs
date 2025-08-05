using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFPS;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

[RequireComponent(typeof(AudioSource))]

public class Trigger : MonoBehaviour
{

    public UnityEvent Enter;
    public UnityEvent Exit;
    public UnityEvent PlatformGoesDown;
    public MeshRenderer meshRenderer;
   [SerializeField] private GameObject messageBox;
    public static bool buttonWasPushedOnce = true;
    private AudioSource audio;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if (fps != null && buttonWasPushedOnce == true)
        {
            Enter.Invoke();
            meshRenderer.material.color = Color.blue;
            firstButtonIsOn();
            messageBox.SetActive(true);
            Invoke("DisableText", 5f);
            buttonWasPushedOnce = false;
            audio.Play();
        }
    }
    

    private void OnTriggerExit(Collider other)
    {

        FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if (fps != null)
        {
            Exit.Invoke();
            meshRenderer.material.color = Color.red;
        }
    }

    private void DisableText()
    {
        messageBox.SetActive(false);
    }

    public void firstButtonIsOn()
    {
        Trigger2.TurnOnSecondButton();
    }
}
    


