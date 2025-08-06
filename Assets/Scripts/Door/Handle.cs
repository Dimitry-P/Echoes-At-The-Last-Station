using UnityEngine;

public class Handle : MonoBehaviour
{
    private bool isRotated = false;

    public void RotateHandle(bool opening)
    {
        if (opening && !isRotated)
        {
            transform.Rotate(Vector3.forward * 45f);  // ��� Z
            isRotated = true;
        }
        else if (!opening && isRotated)
        {
            transform.Rotate(Vector3.forward * -45f);   // �������
            isRotated = false;
        }
    }
}
