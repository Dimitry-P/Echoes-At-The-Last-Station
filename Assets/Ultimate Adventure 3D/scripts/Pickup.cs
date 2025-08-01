using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFPS;



public class Pickup : MonoBehaviour
{
   
    protected virtual void OnTriggerEnter(Collider other)
    {
        FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if(fps != null)
        {
            Destroy(gameObject);
        }
    }
}
