using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public int points = 10; // ������ ��� ��� ������������ �������
    public GameObject pickupEffect; // ���
    public AudioClip pickupSound; // ����

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // � Bob ���� tag "Player"
        {
            PlayPickupEffects();
            ScoreManager.instance.AddScore(points); // �������� ��� ����
            StartCoroutine(ShrinkAndDestroy());
        }
    }

    void PlayPickupEffects()
    {
        Instantiate(pickupEffect, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
    }

    IEnumerator ShrinkAndDestroy()
    {
        float shrinkDuration = 0.5f;
        Vector3 originalScale = transform.localScale;

        for (float t = 0; t < shrinkDuration; t += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, t / shrinkDuration);
            yield return null;
        }

        Destroy(gameObject);
    }
}
