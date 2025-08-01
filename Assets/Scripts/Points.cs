using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Echoes_At_The_Last_Station
{
    public class Points : MonoBehaviour
    {
        [SerializeField] private Text text;
        private FPSInput player;
        private int counter = 0;

        private void Start()
        {
            player = FindObjectOfType<FPSInput>();
            if (player != null)
            {
                player.OnItemPickedUp += PlusOnePoint;
            }
            else
            {
                Debug.LogWarning("FPSInput (player) не найден на сцене.");
            }
        }
        private void PlusOnePoint()
        {
            counter++;
            UpdateText();
        }

        private void UpdateText()
        {
            text.text = "Очки: " + counter;
        }
    }
}

