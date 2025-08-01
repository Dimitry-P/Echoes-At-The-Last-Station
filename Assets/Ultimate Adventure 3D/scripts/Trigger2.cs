using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using SimpleFPS;
using UnityEngine.Events;

public class Trigger2 : MonoBehaviour
{

    public UnityEvent Enter;
    public UnityEvent Exit;
    public MeshRenderer meshRenderer;
    private static bool TheFirstButtonWasPushed = false;
    [SerializeField] private GameObject messageBox;
    public static bool secondButtonPush = true;
    private AudioSource audio;
    private int timesOfPushing = 0;
    public static bool secondButtonIsOn = false;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }


    public static void TurnOnSecondButton()
    {
        TheFirstButtonWasPushed = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if (fps != null && TheFirstButtonWasPushed == true && Trigger.buttonWasPushedOnce == false
            && secondButtonIsOn == false)
        {
            secondButtonIsOn = true;
            Enter.Invoke();
            meshRenderer.material.color = Color.blue;
            messageBox.SetActive(true);
            Invoke("DisableText", 7f);
            SpringPlatform.turnOn = true;
            audio.Play();
            timesOfPushing++;
            if(timesOfPushing > 1){
                MoveTo.disabled = false;
                MoveTo.isLowering = false;
                
            }
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
}
