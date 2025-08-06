using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public Transform doorTransform;     // ������ �����
    public Handle handleScript;         // ������ �� ������ �����
    public float openAngle = 90f;
    public float openSpeed = 2f;

    private bool isPlayerInTrigger = false;
    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;
    private bool isRotating = false;
    private bool hasRotatedHandle = false;

    void Start()
    {
        closedRotation = doorTransform.rotation;
        openRotation = closedRotation * Quaternion.Euler(0f, openAngle, 0f);
    }

    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E) && !isRotating)
        {
            isRotating = true;
            isOpen = !isOpen;
            hasRotatedHandle = false; // ����� ����� ����� ���������
        }

        if (isRotating)
        {
            Quaternion targetRotation = isOpen ? openRotation : closedRotation;
            doorTransform.rotation = Quaternion.RotateTowards(doorTransform.rotation, targetRotation, openSpeed * Time.deltaTime * 100f);

            // ����� ��������� ������ ���� ���
            if (!hasRotatedHandle)
            {
                handleScript.RotateHandle(isOpen);  // ������������ �����
                hasRotatedHandle = true;
            }

            if (Quaternion.Angle(doorTransform.rotation, targetRotation) < 0.1f)
            {
                doorTransform.rotation = targetRotation;
                isRotating = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerInTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerInTrigger = false;
    }
}
