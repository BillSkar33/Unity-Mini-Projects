using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 100.0f;     // �������� ������� ����� x ��� z ������
    public float heightSpeed = 100.0f;    // �������� ������/������� ���� y �����
    public float rotationSpeed = 100.0f; // �������� ����������� ���� ��� ��� y �����

    void Update()
    {
        HandleMovement(); // ������ �������
        HandleRotation(); // ���������� �������
    }

    void HandleMovement()
    {
        // ������ ����� x ��� z ������ �� �� �������
        float horizontal = Input.GetAxis("Horizontal"); // ��������/�����
        float vertical = Input.GetAxis("Vertical");     // �������/����

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // ������ ���� y ����� �� �� ������� + ��� -
        if (Input.GetKey(KeyCode.KeypadPlus) || Input.GetKey(KeyCode.Equals)) // ������� +
        {
            transform.position += Vector3.up * heightSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.KeypadMinus) || Input.GetKey(KeyCode.Minus)) // ������� -
        {
            transform.position += Vector3.down * heightSpeed * Time.deltaTime;
        }
    }

    void HandleRotation()
    {
        // ���������� ���� ��� ��� ����� ��� ���� y ����� �� �� ������� R
        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
        }
    }
}

