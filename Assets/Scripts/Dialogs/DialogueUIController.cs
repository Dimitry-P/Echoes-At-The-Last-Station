using UnityEngine;
using TMPro;

public class DialogueUIController : MonoBehaviour
{
    public Canvas canvas;                 // Canvas � ������ World Space
    public RectTransform uiRoot;         // ������ UI ������
    public TextMeshProUGUI nameText;     // ����� �����
    public TextMeshProUGUI contentText;  // ����� �������
    public Camera mainCamera;             // ������ ��� ���������� UI

    private Transform lookTarget;        // � ���� ��������� UI

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        HideDialogue();
    }

    void LateUpdate()
    {
        if (lookTarget != null && uiRoot != null)
        {
            Vector3 lookDirection = uiRoot.position - mainCamera.transform.position;
            uiRoot.rotation = Quaternion.LookRotation(lookDirection.normalized, Vector3.up);
            Vector3 euler = uiRoot.rotation.eulerAngles;

            euler.x = 0;
            euler.z = 0;

            uiRoot.rotation = Quaternion.Euler(euler);
        }
    }

    public void ShowDialogue(string name, string content, Transform target)
    {
        lookTarget = target;
        nameText.text = name;
        contentText.text = content;
        canvas.enabled = true;
    }

    public void HideDialogue()
    {
        lookTarget = null;
        mainCamera.transform.localRotation = Quaternion.identity;
        canvas.enabled = false;
    }
}

