using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private float[] speedLevels = new float[] { 2.0f, 5.0f, 10.0f, 15.0f, 20.0f }; // Διαβαθμίσεις ταχύτητας
    private int currentSpeedLevel = 1; // Τρέχον επίπεδο ταχύτητας
    public float moveSpeed; // Ταχύτητα κίνησης του Bob

    private Vector3 minBounds = new Vector3(-40f, 0f, -40f); // Ελάχιστα όρια του εδάφους
    private Vector3 maxBounds = new Vector3(40f, 0f, 40f); // Μέγιστα όρια του εδάφους
    private float originalYPosition; // Αρχική θέση του Bob στον άξονα y

    void Start()
    {
        // Καταγράφουμε την αρχική θέση του Bob στον άξονα y
        originalYPosition = transform.position.y;
    }
   

    void Update()
    {
        // Αλλαγή ταχύτητας με τα πλήκτρα 1-5
        for (int i = 0; i < speedLevels.Length; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                currentSpeedLevel = i;
                moveSpeed = speedLevels[currentSpeedLevel];
            }
        }

        float xMovement = Input.GetKey(KeyCode.A) ? -1f : Input.GetKey(KeyCode.D) ? 1f : 0f;
        float zMovement = Input.GetKey(KeyCode.S) ? -1f : Input.GetKey(KeyCode.X) ? 1f : 0f;
        float yMovement = Input.GetKey(KeyCode.W) ? 1f : Input.GetKey(KeyCode.E) ? -1f : 0f;

        Vector3 moveDirection = new Vector3(xMovement, yMovement, zMovement).normalized;

        if (moveDirection.magnitude > 1f)
        {
            moveDirection.Normalize();
        }

        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;
        // Υπολογίζουμε το ελάχιστο επιτρεπτό y βάσει της αρχικής θέσης και της κλίμακας
        float minY = originalYPosition * transform.localScale.y; 
        newPosition.y = Mathf.Clamp(newPosition.y, minY, 1000f);
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.z = Mathf.Clamp(newPosition.z, minBounds.z, maxBounds.z);

        transform.position = newPosition;
    }
}
