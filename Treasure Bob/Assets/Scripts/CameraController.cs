using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 100.0f;     // Ταχύτητα κίνησης στους x και z άξονες
    public float heightSpeed = 100.0f;    // Ταχύτητα ανόδου/καθόδου στον y άξονα
    public float rotationSpeed = 100.0f; // Ταχύτητα περιστροφής γύρω από τον y άξονα

    void Update()
    {
        HandleMovement(); // Κίνηση κάμερας
        HandleRotation(); // Περιστροφή κάμερας
    }

    void HandleMovement()
    {
        // Κίνηση στους x και z άξονες με τα βελάκια
        float horizontal = Input.GetAxis("Horizontal"); // Αριστερά/Δεξιά
        float vertical = Input.GetAxis("Vertical");     // Μπροστά/Πίσω

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // Κίνηση στον y άξονα με τα πλήκτρα + και -
        if (Input.GetKey(KeyCode.KeypadPlus) || Input.GetKey(KeyCode.Equals)) // Πλήκτρο +
        {
            transform.position += Vector3.up * heightSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.KeypadMinus) || Input.GetKey(KeyCode.Minus)) // Πλήκτρο -
        {
            transform.position += Vector3.down * heightSpeed * Time.deltaTime;
        }
    }

    void HandleRotation()
    {
        // Περιστροφή γύρω από τον εαυτό της στον y άξονα με το πλήκτρο R
        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
        }
    }
}

