using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    public GameObject[] treasurePrefabs; // ������� �� Prefabs ��������
    public Transform mazeArea; // ������� ��� ����������
    public float spawnInterval = 5.0f; // ������ ������ spawn
    public float treasureLifetime = 10.0f; // ������ ���� ��������
    public LayerMask wallLayer; // Layer ��� ���� �������

    private Bounds mazeBounds;

    void Start()
    {
        // ����������� ��� ����� ��� ����������
        Collider mazeCollider = mazeArea.GetComponent<Collider>();
        mazeBounds = mazeCollider.bounds;

        StartCoroutine(SpawnTreasures());
    }

    IEnumerator SpawnTreasures()
    {
        while (true)
        {
            Vector3 spawnPosition = GetValidSpawnPosition();

            // ������� ������� ��������
            GameObject treasurePrefab = treasurePrefabs[Random.Range(0, treasurePrefabs.Length)];
            GameObject treasure = Instantiate(treasurePrefab, spawnPosition, Quaternion.identity);
            treasure.transform.localScale = Vector3.one * 50.0f; // ���������� 5x5x5

            // ���������� ��� �������� ���� ��� �����
            Destroy(treasure, treasureLifetime);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector3 GetValidSpawnPosition()
    {
        Vector3 spawnPosition;

        // ��������������� ����� �� ������ ������ ����
        do
        {
            float randomX = Random.Range(mazeBounds.min.x, mazeBounds.max.x);
            float randomZ = Random.Range(mazeBounds.min.z, mazeBounds.max.z);
            spawnPosition = new Vector3(randomX, 25.0f, randomZ);

        } while (Physics.CheckBox(spawnPosition, Vector3.one * 25.0f, Quaternion.identity, wallLayer));

        return spawnPosition;
    }
}
