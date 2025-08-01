using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFPS;


public class Cure : Pickup
{
    [SerializeField] private GameObject impactffect;
    [SerializeField] private int curePower;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        Destructible destructible = other.GetComponent<Destructible>();

        if (destructible.GetHitPoints() != 0)
        {
            destructible.ChargeStrength(curePower);
            Instantiate(impactffect);
        }
    }
}
