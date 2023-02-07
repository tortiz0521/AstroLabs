using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ActivationTrigger : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();

    public void Toggle()
    {
        foreach (GameObject o in targets)
        {
            o.SetActive(!o.activeInHierarchy);
        }
    }

    public void ActivationTrigger()
    {
        foreach (GameObject o in targets)
        {
            o.SetActive(true);
        }
    }

    public void DeactivationTrigger()
    {
        foreach (GameObject o in targets)
        {
            o.SetActive(false);
        }
    }

}
