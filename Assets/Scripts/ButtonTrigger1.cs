using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFPS;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

[RequireComponent(typeof(AudioSource))]

public class ButtonTrigger : MonoBehaviour
{

    public UnityEvent Enter;
    public UnityEvent Exit;
    public UnityEvent PlatformGoesDown;
    public MeshRenderer meshRenderer;
    public AudioSource audio;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterController fps = other.GetComponent<CharacterController>();

        if (fps != null)
        {
            Enter.Invoke();
            audio.Play();
        }
    }


    private void OnTriggerExit(Collider other)
    {

        CharacterController fps = other.GetComponent<CharacterController>();

        if (fps != null)
        {
            Exit.Invoke();
        }
    }
}



