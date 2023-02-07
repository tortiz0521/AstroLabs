using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPlatform : MonoBehaviour
{
    public float duration = 5f;
    public float reappearDuration = 5f;

    MeshRenderer mr;
    Collider col;

    bool colliderLock = false;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        col = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!colliderLock)
        {
            colliderLock = true;
            StartCoroutine(TimedVanish());
        }
    }

    IEnumerator TimedVanish()
    {
        yield return new WaitForSeconds(duration);
        mr.enabled = false;
        col.enabled = false;
        StartCoroutine(Reappear());

    }

    IEnumerator Reappear()
    {
        yield return new WaitForSeconds(reappearDuration);
        mr.enabled = true;
        col.enabled = true;
        colliderLock = false;
    }



}
