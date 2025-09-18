using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobCollision : MonoBehaviour
{
    public Material[] cubeMaterials; // Μια λίστα με τα Materials των κύβων
    private AudioSource audioSource; // Πηγή ήχου για την αναπαραγωγή ήχων συγκρούσεων

    void Start()
    {
        // Αποκτήστε πρόσβαση στο AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
            {
                renderer.material = collision.gameObject.GetComponent<Renderer>().material;
            }

            if (collision.gameObject.name == "CubeUpScale")
            {
                transform.localScale *= 1.1f;
            }
            else if (collision.gameObject.name == "CubeDownScale")
            {
                transform.localScale *= 0.9f;
            }

            // Αναπαραγωγή ήχου συγκρούσεων
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
