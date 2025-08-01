using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Transform targetTransform; // Объект для вращения
    [SerializeField] private float speed; // Скорость вращения
    [SerializeField] private Vector3 rotationAxis = Vector3.up; // Ось вращения
    public static AudioSource audio;

    void Start()
    {
        targetTransform = transform.GetChild(0).GetChild(0).transform;
        audio = GetComponent<AudioSource>();
        audio.Play();
    }


    void Update()
    {
        // Вращаем объект постоянно вокруг указанной оси
        targetTransform.Rotate(rotationAxis, speed * Time.deltaTime);
    }
}