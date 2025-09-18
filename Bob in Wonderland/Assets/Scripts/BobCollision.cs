using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobCollision : MonoBehaviour
{
    public Material[] cubeMaterials; // ��� ����� �� �� Materials ��� �����
    private AudioSource audioSource; // ���� ���� ��� ��� ����������� ���� �����������

    void Start()
    {
        // ��������� �������� ��� AudioSource component
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

            // ����������� ���� �����������
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
