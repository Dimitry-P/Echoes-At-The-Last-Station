using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Echoes_At_The_Last_Station
{
    public class FPSInput : MonoBehaviour
    {
        [Header("Movement")]
        public float moveSpeed = 5f;
        public float gravity = -9.81f;

        [Header("Crouch Settings")]
        public Transform cameraHolder; // Перетащи сюда CameraHolder из инспектора
        public float standHeight = 1.8f;
        public float crouchHeight = 0.5f;
        public float crouchSpeed = 6f;

        private CharacterController controller;
        private Vector3 velocity;
        private float targetCamY;
        private bool isCrouching = false;

        public Transform holdPoint;  // Точка, куда игрок "держит" предмет (поставить пустой объект в руках камеры или модели)
        public float pickupRange = 2f;  // Максимальная дистанция для поднятия
        private GameObject heldObject = null;  // Текущий поднимаемый объект

        public event Action OnItemPickedUp;


        void Start()
        {
            controller = GetComponent<CharacterController>();
            targetCamY = standHeight;

            // Устанавливаем начальные параметры CharacterController
            controller.height = standHeight;
            controller.center = new Vector3(0, standHeight / 2f, 0);
        }

        void Update()
        {
            HandleMovement();
            HandleCrouch();
            HandlePickup();
        }

        void HandleMovement()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 move = transform.right * h + transform.forward * v;
            controller.Move(move * moveSpeed * Time.deltaTime);

            // Применение гравитации
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            if (controller.isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
        }

        void HandleCrouch()
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                isCrouching = true;
                targetCamY = crouchHeight;
                controller.height = crouchHeight;
                controller.center = new Vector3(0, crouchHeight / 2f, 0);
            }

            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                if (CanStandUp())
                {
                    isCrouching = false;
                    targetCamY = standHeight;
                    controller.height = standHeight;
                    controller.center = new Vector3(0, standHeight / 2f, 0);
                }
            }

            // Плавное движение камеры вверх-вниз
            Vector3 localPos = cameraHolder.localPosition;
            localPos.y = Mathf.Lerp(localPos.y, targetCamY, Time.deltaTime * crouchSpeed);
            cameraHolder.localPosition = localPos;
        }

        bool CanStandUp()
        {
            float headRoom = 0.1f;
            Vector3 start = transform.position + Vector3.up * crouchHeight;
            float distance = standHeight - crouchHeight + headRoom;

            return !Physics.Raycast(start, Vector3.up, distance);
        }

        void HandlePickup()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (heldObject == null)
                {
                    TryPickup();
                }
                else
                {
                    DropObject();
                }
            }
        }

        void TryPickup()
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, pickupRange))
            {
                if (hit.collider.CompareTag("Pickup"))
                {
                    PickupObject(hit.collider.gameObject);
                }
            }
        }


        void PickupObject(GameObject obj)
        {
            heldObject = obj;

            // Отключаем физику объекта, чтобы он не падал
            Rigidbody rb = heldObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
                OnItemPickedUp?.Invoke();
            }

            // Прикрепляем к точке удержания
            heldObject.transform.SetParent(holdPoint);
            heldObject.transform.localPosition = Vector3.zero;
            heldObject.transform.localRotation = Quaternion.identity;
        }

        void DropObject()
        {
            if (heldObject != null)
            {
                Rigidbody rb = heldObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                }

                heldObject.transform.SetParent(null);
                heldObject = null;
            }
        }
    }
}

