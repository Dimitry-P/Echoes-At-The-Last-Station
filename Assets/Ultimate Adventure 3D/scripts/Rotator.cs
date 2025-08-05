using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Transform targetTransform; // ������ ��� ��������
    [SerializeField] private float speed; // �������� ��������
    [SerializeField] private Vector3 rotationAxis = Vector3.up; // ��� ��������
    public static AudioSource audio;

    void Start()
    {
        targetTransform = transform.GetChild(0).GetChild(0).transform;
        audio = GetComponent<AudioSource>();
        audio.Play();
    }


    void Update()
    {
        // ������� ������ ��������� ������ ��������� ���
        targetTransform.Rotate(rotationAxis, speed * Time.deltaTime);
    }
}