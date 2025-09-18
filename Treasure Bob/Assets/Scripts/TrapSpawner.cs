using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    public GameObject trapPrefab; // Το Prefab της παγίδας
    public Transform mazeArea; // Περιοχή του λαβύρινθου
    public float spawnInterval = 5.0f; // Χρόνος μεταξύ spawn
    public float minLifetime = 3.0f, maxLifetime = 7.0f; // Τυχαία διάρκεια ζωής παγίδας
    public LayerMask wallLayer; // Layer των τοίχων για τον έλεγχο σύγκρουσης
    private Bounds mazeBounds;

    void Start()
    {
        // Υπολογισμός ορίων του λαβυρίνθου
        mazeBounds = mazeArea.GetComponent<Collider>().bounds;
        StartCoroutine(SpawnTraps());
    }

    IEnumerator SpawnTraps()
    {
        while (true)
        {
            Vector3 spawnPosition = GetValidPosition();

            // Δημιουργία παγίδας
            GameObject trap = Instantiate(trapPrefab, spawnPosition, Quaternion.identity);

            // Καταστροφή της παγίδας μετά από τυχαία διάρκεια
            float trapLifetime = Random.Range(minLifetime, maxLifetime);
            Destroy(trap, trapLifetime);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector3 GetValidPosition()
    {
        Vector3 spawnPosition;
        float trapRadius = 50.0f; // Ακτίνα της παγίδας (λόγω διαμέτρου 5)

        // Επαναλαμβάνουμε μέχρι να βρούμε έγκυρη θέση
        do
        {
            float x = Random.Range(mazeBounds.min.x, mazeBounds.max.x);
            float z = Random.Range(mazeBounds.min.z, mazeBounds.max.z);
            spawnPosition = new Vector3(x, 50.0f, z);

        } while (Physics.CheckSphere(spawnPosition, trapRadius, wallLayer)); // Έλεγχος για σύγκρουση με τοίχο

        return spawnPosition;
    }
}
