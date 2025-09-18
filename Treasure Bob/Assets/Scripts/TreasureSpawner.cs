using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    public GameObject[] treasurePrefabs; // Πίνακας με Prefabs θησαυρών
    public Transform mazeArea; // Περιοχή του λαβυρίνθου
    public float spawnInterval = 5.0f; // Χρόνος μεταξύ spawn
    public float treasureLifetime = 10.0f; // Χρόνος ζωής θησαυρού
    public LayerMask wallLayer; // Layer για τους τοίχους

    private Bounds mazeBounds;

    void Start()
    {
        // Υπολογισμός των ορίων του λαβύρινθου
        Collider mazeCollider = mazeArea.GetComponent<Collider>();
        mazeBounds = mazeCollider.bounds;

        StartCoroutine(SpawnTreasures());
    }

    IEnumerator SpawnTreasures()
    {
        while (true)
        {
            Vector3 spawnPosition = GetValidSpawnPosition();

            // Επιλογή τυχαίου θησαυρού
            GameObject treasurePrefab = treasurePrefabs[Random.Range(0, treasurePrefabs.Length)];
            GameObject treasure = Instantiate(treasurePrefab, spawnPosition, Quaternion.identity);
            treasure.transform.localScale = Vector3.one * 50.0f; // Διαστάσεις 5x5x5

            // Καταστροφή του θησαυρού μετά από χρόνο
            Destroy(treasure, treasureLifetime);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector3 GetValidSpawnPosition()
    {
        Vector3 spawnPosition;

        // Επαναλαμβάνουμε μέχρι να βρούμε έγκυρη θέση
        do
        {
            float randomX = Random.Range(mazeBounds.min.x, mazeBounds.max.x);
            float randomZ = Random.Range(mazeBounds.min.z, mazeBounds.max.z);
            spawnPosition = new Vector3(randomX, 25.0f, randomZ);

        } while (Physics.CheckBox(spawnPosition, Vector3.one * 25.0f, Quaternion.identity, wallLayer));

        return spawnPosition;
    }
}
