using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour
{
    public AudioClip Chirp;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(Chirp, transform.position);
        }
    }
}