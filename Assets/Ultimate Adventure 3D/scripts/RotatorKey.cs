using UnityEngine;

public class RotatorKey : MonoBehaviour
{
    private Transform targetTransform; // ������ ��� ��������
    [SerializeField] private float speed; // �������� ��������
    [SerializeField] private Vector3 rotationAxis = Vector3.up; // ��� ��������

    void Start()
    {
        targetTransform = transform.GetChild(0).transform;
    }


    void Update()
    {
        // ������� ������ ��������� ������ ��������� ���
        targetTransform.Rotate(rotationAxis, speed * Time.deltaTime);
    }
}