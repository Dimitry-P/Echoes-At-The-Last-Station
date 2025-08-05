using SimpleFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerForTeleport3 : MonoBehaviour
{
    public UnityEvent Enter;
    public UnityEvent Exit;
    public MeshRenderer meshRenderer;
    [SerializeField] private GameObject messageBox;
    private AudioSource audio;
    [SerializeField] private bool firstButtonWasPushed = false;
    public static bool thirdButtonIsOn = true;




    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if (fps != null && thirdButtonIsOn == false)
        {
            Enter.Invoke();
            meshRenderer.material.color = Color.blue;
            messageBox.SetActive(true);
            Invoke("DisableText", 5f);
            audio.Play();
            thirdButtonIsOn = true;
            Teleporter.threeButtonsPushed = true;
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





