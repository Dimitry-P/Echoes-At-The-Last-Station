using UnityEngine;

public class DoorWithHandle : MonoBehaviour
{
    public Transform door;            // ��� ����� (�����������)
    public Transform handleLever;     // ��������� ����� ����� (����������)

    public Vector3 doorOpenRotation = new Vector3(0, 90, 0);       // ������� �����
    public Vector3 handlePressRotation = new Vector3(-30, 0, 0);   // ������� ����� ����

    public float openSpeed = 2f;

    private Quaternion doorClosedRot;
    private Quaternion doorOpenRot;
    private Quaternion handleDefaultRot;
    private Quaternion handlePressedRot;

    private bool isOpen = false;

    void Start()
    {
        doorClosedRot = door.localRotation;
        doorOpenRot = Quaternion.Euler(doorOpenRotation) * doorClosedRot;

        handleDefaultRot = handleLever.localRotation;
        handlePressedRot = Quaternion.Euler(handlePressRotation) * handleDefaultRot;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen;
        }

        // �������� �����
        Quaternion targetDoorRot = isOpen ? doorOpenRot : doorClosedRot;
        door.localRotation = Quaternion.Slerp(door.localRotation, targetDoorRot, Time.deltaTime * openSpeed);

        // �������� �����
        Quaternion targetHandleRot = isOpen ? handlePressedRot : handleDefaultRot;
        handleLever.localRotation = Quaternion.Slerp(handleLever.localRotation, targetHandleRot, Time.deltaTime * openSpeed);
    }
}
