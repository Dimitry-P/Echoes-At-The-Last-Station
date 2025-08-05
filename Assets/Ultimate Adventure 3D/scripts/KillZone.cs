using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destructible destructible = other.GetComponent<Destructible>();

        if (destructible != null)
        {
            destructible.Kill();
        }
    }
}
