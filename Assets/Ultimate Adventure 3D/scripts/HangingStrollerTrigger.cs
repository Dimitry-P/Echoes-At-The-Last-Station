using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFPS;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

[RequireComponent(typeof(AudioSource))]

public class HangingStrollerTrigger : MonoBehaviour
{

    public UnityEvent Enter;
    public UnityEvent Exit;
    [SerializeField] private AudioSource audio;
    private bool onlyOneRide = true;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if (fps != null)
        {
            Enter.Invoke();
            if(onlyOneRide == true)
            {
                audio.Play();
            }
            onlyOneRide = false;
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



