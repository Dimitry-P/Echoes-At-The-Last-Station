using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Echoes_At_The_Last_Station
{
    public class FPSInput : MonoBehaviour
    {
        public float speed = 6.0f;
        public float gravity = -9.8f;
        private CharacterController _charController;
        private float verticalVelocity = 0f;

        void Start()
        {
            _charController = GetComponent<CharacterController>();
        }

        void Update()
        {
            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;
            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, speed);
            movement = transform.TransformDirection(movement);

            // Обработка гравитации
            if (_charController.isGrounded)
            {
                verticalVelocity = 0; // на земле — вертикальная скорость 0
            }
            else
            {
                verticalVelocity += gravity * Time.deltaTime; // падаем вниз с ускорением
            }

            movement.y = verticalVelocity;

            movement *= Time.deltaTime;

            _charController.Move(movement);
        }
    }
}

