using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFPS;

[RequireComponent(typeof(AudioSource))]
public class Teleporter : MonoBehaviour
{
    [SerializeField] private Teleporter target;
    [SerializeField] private AudioSource audio;
    public static bool threeButtonsPushed = false;
    [SerializeField] private GameObject messageBox;

    [HideInInspector] public bool IsRecieve;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (IsRecieve == true) return;
        FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if (fps != null && threeButtonsPushed == true)
        {
            target.IsRecieve = true;
            fps.transform.position = target.transform.position;
            audio.Play();
        }
        if(fps != null && threeButtonsPushed == false)
        {
            messageBox.SetActive(true);
            Invoke("DisableText", 5f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if (fps != null)
        {

            IsRecieve = false;

        }
    }
    private void DisableText()
    {
        messageBox.SetActive(false);
    }

}
