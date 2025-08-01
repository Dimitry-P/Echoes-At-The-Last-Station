using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent Enter;
    [SerializeField] private GameObject messageBox;
    [SerializeField] private int amountKeyActive;

    private bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isActive == true) return;
        Bag bag = other.GetComponent<Bag>();

        if(bag != null)
        {
            if(bag.DrawKey(amountKeyActive)  == true)
            {
                
                Enter.Invoke();
                isActive = true;
            }
            else
            {
                messageBox.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        messageBox.SetActive(false);
    }
}
