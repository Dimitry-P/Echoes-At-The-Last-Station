using UnityEngine;

public class RotatorKey : MonoBehaviour
{
    private Transform targetTransform; // Объект для вращения
    [SerializeField] private float speed; // Скорость вращения
    [SerializeField] private Vector3 rotationAxis = Vector3.up; // Ось вращения

    void Start()
    {
        targetTransform = transform.GetChild(0).transform;
    }


    void Update()
    {
        // Вращаем объект постоянно вокруг указанной оси
        targetTransform.Rotate(rotationAxis, speed * Time.deltaTime);
    }
}