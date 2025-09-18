using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobMovement : MonoBehaviour
{
    public Transform Bob; // Αναφορά στον Bob (Sphere)
    public GameObject Plane; // Αναφορά στο Plane
    public float[] speedLevels = { 100.0f, 120.0f, 140.0f, 160.0f, 200.0f }; // Διαβαθμίσεις ταχύτητας
    public int currentSpeedLevel = 1; // Αρχικό επίπεδο ταχύτητας
    public LayerMask wallLayer; // Layer για τους τοίχους

    private float moveStep; // Ταχύτητα κίνησης
    private Bounds planeBounds;

    void Start()
    {
        // Υπολογισμός των ορίων του Plane
        MeshRenderer planeRenderer = Plane.GetComponent<MeshRenderer>();
        planeBounds = planeRenderer.bounds;

        // Ορισμός αρχικής ταχύτητας
        moveStep = speedLevels[currentSpeedLevel];
    }

    void Update()
    {
        AdjustSpeed(); // Διαχείριση διαβαθμίσεων ταχύτητας
        MoveBob();     // Κίνηση του Bob
    }

    void MoveBob()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.J)) direction = Vector3.left;  // Αριστερά
        if (Input.GetKey(KeyCode.L)) direction = Vector3.right; // Δεξιά
        if (Input.GetKey(KeyCode.I)) direction = Vector3.forward; // Μπροστά
        if (Input.GetKey(KeyCode.K)) direction = Vector3.back; // Πίσω

        if (direction != Vector3.zero)
        {
            // Νέα θέση του Bob
            Vector3 newPosition = Bob.position + direction.normalized * moveStep * Time.deltaTime;

            // Έλεγχος για σύγκρουση με τοίχους μέσω BoxCast
            if (!Physics.BoxCast(Bob.position, Vector3.one * 35.0f, direction, Quaternion.identity, moveStep * Time.deltaTime, wallLayer))
            {
                // Έλεγχος αν η θέση είναι εντός των ορίων του Plane
                if (IsWithinBounds(newPosition))
                {
                    Bob.position = newPosition;
                }
            }
            else
            {
                Debug.Log("Ο Bob εμποδίζεται από τον τοίχο!");
            }
        }
    }

    void AdjustSpeed()
    {
        // Μείωση ταχύτητας με Z
        if (Input.GetKeyDown(KeyCode.Z) && currentSpeedLevel > 0)
        {
            currentSpeedLevel--;
            moveStep = speedLevels[currentSpeedLevel];
            Debug.Log("Ταχύτητα μειώθηκε σε: " + moveStep);
        }

        // Αύξηση ταχύτητας με X
        if (Input.GetKeyDown(KeyCode.X) && currentSpeedLevel < speedLevels.Length - 1)
        {
            currentSpeedLevel++;
            moveStep = speedLevels[currentSpeedLevel];
            Debug.Log("Ταχύτητα αυξήθηκε σε: " + moveStep);
        }
    }

    bool IsWithinBounds(Vector3 position)
    {
        // Έλεγχος αν η νέα θέση είναι μέσα στα όρια του Plane
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
