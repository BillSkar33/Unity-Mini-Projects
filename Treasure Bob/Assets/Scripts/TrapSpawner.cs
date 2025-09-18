using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    public GameObject trapPrefab; // �� Prefab ��� �������
    public Transform mazeArea; // ������� ��� ����������
    public float spawnInterval = 5.0f; // ������ ������ spawn
    public float minLifetime = 3.0f, maxLifetime = 7.0f; // ������ �������� ���� �������
    public LayerMask wallLayer; // Layer ��� ������ ��� ��� ������ ����������
    private Bounds mazeBounds;

    void Start()
    {
        // ����������� ����� ��� ����������
        mazeBounds = mazeArea.GetComponent<Collider>().bounds;
        StartCoroutine(SpawnTraps());
    }

    IEnumerator SpawnTraps()
    {
        while (true)
        {
            Vector3 spawnPosition = GetValidPosition();

            // ���������� �������
            GameObject trap = Instantiate(trapPrefab, spawnPosition, Quaternion.identity);

            // ���������� ��� ������� ���� ��� ������ ��������
            float trapLifetime = Random.Range(minLifetime, maxLifetime);
            Destroy(trap, trapLifetime);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector3 GetValidPosition()
    {
        Vector3 spawnPosition;
        float trapRadius = 50.0f; // ������ ��� ������� (���� ��������� 5)

        // ��������������� ����� �� ������ ������ ����
        do
        {
            float x = Random.Range(mazeBounds.min.x, mazeBounds.max.x);
            float z = Random.Range(mazeBounds.min.z, mazeBounds.max.z);
            spawnPosition = new Vector3(x, 50.0f, z);

        } while (Physics.CheckSphere(spawnPosition, trapRadius, wallLayer)); // ������� ��� ��������� �� �����

        return spawnPosition;
    }
}
