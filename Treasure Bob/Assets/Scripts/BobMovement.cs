using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobMovement : MonoBehaviour
{
    public Transform Bob; // ������� ���� Bob (Sphere)
    public GameObject Plane; // ������� ��� Plane
    public float[] speedLevels = { 100.0f, 120.0f, 140.0f, 160.0f, 200.0f }; // ������������ ���������
    public int currentSpeedLevel = 1; // ������ ������� ���������
    public LayerMask wallLayer; // Layer ��� ���� �������

    private float moveStep; // �������� �������
    private Bounds planeBounds;

    void Start()
    {
        // ����������� ��� ����� ��� Plane
        MeshRenderer planeRenderer = Plane.GetComponent<MeshRenderer>();
        planeBounds = planeRenderer.bounds;

        // ������� ������� ���������
        moveStep = speedLevels[currentSpeedLevel];
    }

    void Update()
    {
        AdjustSpeed(); // ���������� ������������ ���������
        MoveBob();     // ������ ��� Bob
    }

    void MoveBob()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.J)) direction = Vector3.left;  // ��������
        if (Input.GetKey(KeyCode.L)) direction = Vector3.right; // �����
        if (Input.GetKey(KeyCode.I)) direction = Vector3.forward; // �������
        if (Input.GetKey(KeyCode.K)) direction = Vector3.back; // ����

        if (direction != Vector3.zero)
        {
            // ��� ���� ��� Bob
            Vector3 newPosition = Bob.position + direction.normalized * moveStep * Time.deltaTime;

            // ������� ��� ��������� �� ������� ���� BoxCast
            if (!Physics.BoxCast(Bob.position, Vector3.one * 35.0f, direction, Quaternion.identity, moveStep * Time.deltaTime, wallLayer))
            {
                // ������� �� � ���� ����� ����� ��� ����� ��� Plane
                if (IsWithinBounds(newPosition))
                {
                    Bob.position = newPosition;
                }
            }
            else
            {
                Debug.Log("� Bob ����������� ��� ��� �����!");
            }
        }
    }

    void AdjustSpeed()
    {
        // ������ ��������� �� Z
        if (Input.GetKeyDown(KeyCode.Z) && currentSpeedLevel > 0)
        {
            currentSpeedLevel--;
            moveStep = speedLevels[currentSpeedLevel];
            Debug.Log("�������� �������� ��: " + moveStep);
        }

        // ������ ��������� �� X
        if (Input.GetKeyDown(KeyCode.X) && currentSpeedLevel < speedLevels.Length - 1)
        {
            currentSpeedLevel++;
            moveStep = speedLevels[currentSpeedLevel];
            Debug.Log("�������� �������� ��: " + moveStep);
        }
    }

    bool IsWithinBounds(Vector3 position)
    {
        // ������� �� � ��� ���� ����� ���� ��� ���� ��� Plane
        return (position.x >= planeBounds.min.x && position.x <= planeBounds.max.x &&
                position.z >= planeBounds.min.z && position.z <= planeBounds.max.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            FindObjectOfType<GameOverManager>().TriggerGameOver();
        }
    }

}
