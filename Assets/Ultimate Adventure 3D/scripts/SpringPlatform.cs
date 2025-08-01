using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFPS;
using UnityEngine.Events;
using System;
using UnityEngine.UI;
using System.Threading;
using Unity.VisualScripting;


[RequireComponent(typeof(AudioSource))]
public class SpringPlatform : MonoBehaviour
{
    [SerializeField] private int jumpForce;
    public static bool turnOn = true;
    private int amountOfJumps = 0;
    [SerializeField] private new AudioSource audio;
    private float previousJumpSpeed;
    [SerializeField] private GameObject messageBox;
    private MoveTo moveTo;






    private void Start()
    {
        audio = GetComponent<AudioSource>();
        //DontDestroyOnLoad(trigger.gameObject);
        //trigger.turnOnSpringPlatform.AddListener(PlayerTurnedOnTheButton);

        moveTo = GetComponent<MoveTo>();
    }




    //private void OnDestroy()
    //{
    //    DontDestroyOnLoad(trigger.gameObject);
    //    trigger.turnOnSpringPlatform.RemoveListener(PlayerTurnedOnTheButton);
    //}
    //private void PlayerTurnedOnTheButton()
    //{
    //    DontDestroyOnLoad(trigger.gameObject);
    //    int plusOne = trigger.GetTheButton();
    //}



  

    private void OnTriggerEnter(Collider other)
    {
    FirstPersonController fps = other.GetComponent<FirstPersonController>();
      

        if (fps != null && turnOn == true)
        {
                previousJumpSpeed = fps.m_JumpSpeed;
                fps.m_JumpSpeed += jumpForce;
                fps.m_Jump = true;
                audio.Play();

            moveTo.LowerSpring();
                amountOfJumps++;
           
                if (amountOfJumps == 5)
                {
                moveTo.DisableSpring2();
                messageBox.SetActive(true);
                Invoke("DisableText", 5f);
                fps.m_Jump = false;
                fps.m_JumpSpeed = previousJumpSpeed;
                turnOn = false;
                Trigger.buttonWasPushedOnce = true;
                Trigger2.secondButtonPush = true;
                Trigger2.secondButtonIsOn = false;
                amountOfJumps = 0;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        FirstPersonController fps = other.GetComponent<FirstPersonController>();
       
        if (fps != null)
        {
            fps.m_JumpSpeed = previousJumpSpeed;
        }
    }

    private void DisableText()
    {
        messageBox.SetActive(false);
    }
}
