using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFPS;

public class Acceleration : MonoBehaviour
{
    [SerializeField] private int bonus;
    private void OnTriggerEnter(Collider other)
    {
        FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if (fps != null)
        {
            fps.m_JumpSpeed += bonus;
            fps.m_RunSpeed += bonus;
            fps.m_WalkSpeed += bonus;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if (fps != null)
        {
            fps.m_JumpSpeed -= bonus;
            fps.m_RunSpeed -= bonus;
            fps.m_WalkSpeed -= bonus;
        }
    }
}
