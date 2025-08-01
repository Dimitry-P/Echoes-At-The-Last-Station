using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFPS;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

[RequireComponent(typeof(AudioSource))]

public class GoalMessage : MonoBehaviour
{
    [SerializeField] private GameObject messageBox;
    [SerializeField] private UnityEvent Enter;
    [SerializeField] private UnityEvent Exit;
    private bool showOneTine = false;

    private void OnTriggerEnter(Collider other)
    {
        FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if (fps != null && showOneTine == false)
        {
            Enter.Invoke();
            ShowMessage();
            showOneTine = true;
        }
    }

    private void ShowMessage()
    {
        messageBox.SetActive(true);
        Invoke("DisableText", 7f);
    }


    private void OnTriggerExit(Collider other)
    {

        FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if (fps != null)
        {
            Exit.Invoke();
        }
    }


    private void DisableText()
    {
        messageBox.SetActive(false);
    }

    
}
