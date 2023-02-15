using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityCheck : MonoBehaviour
{

    public Behaviour halo;
    // Start is called before the first frame update
    void Start()
    {
        halo.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey("e"))
        {
            halo.enabled = true;
        }
        else
        {
            halo.enabled = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        halo.enabled = false;
    }
}
