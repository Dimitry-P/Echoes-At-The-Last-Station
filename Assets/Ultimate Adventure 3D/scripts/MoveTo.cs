using System.Collections;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public float speed;
    public Transform target;
    public GameObject parent;
    public Transform target2;

    public static bool isLowering = false;

    // ����� ���������� ��� ��������, ��������� �� ��������
    public static bool disabled = false;

    private void Update()
    {
        // ���� ������ �������� �� ���������� � �� ���������, �� ��������� �
        if (!isLowering && !disabled)
        {
            parent.transform.GetChild(0).GetChild(0).position = Vector3.MoveTowards(
            parent.transform.GetChild(0).GetChild(0).position, target.position, speed * Time.deltaTime);
        }
    }

    public void LowerSpring()
    {
        if (!isLowering)
        {
            StartCoroutine(LowerSpringCoroutine());
        }
    }

    // ����� ����� ��� "����������" ��������
    public void DisableSpring()
    {
        StartCoroutine(LowerSpringCoroutine());
        disabled = true;
    }
    public void DisableSpring2()
    {
        disabled = true;

    }

    public void EnableSpring()
    {
        disabled = false;
    }

    private IEnumerator LowerSpringCoroutine()
    {
        isLowering = true;
        Vector3 startPosition = parent.transform.GetChild(0).GetChild(0).position;
        Vector3 endPosition = target2.position;
        float elapsedTime = 0f;
        float duration = 1f;

        while (elapsedTime < duration)
        {
            parent.transform.GetChild(0).GetChild(0).position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        parent.transform.GetChild(0).GetChild(0).position = endPosition;
        isLowering = false;
    }
}