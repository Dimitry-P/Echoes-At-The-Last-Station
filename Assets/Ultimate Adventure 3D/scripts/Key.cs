using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Key : Pickup
{
    [SerializeField] private GameObject impactffect;
    
   
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        Bag bag = other.GetComponent<Bag>();

        if(bag != null)
        {
            bag.Add(1);
            Instantiate(impactffect);
        }
    }
}
