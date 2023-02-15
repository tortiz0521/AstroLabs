using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;


//Attach this script to the image on the canvas that you wish to have appear!!!

public class UIActivation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mesh; //Assign the object you want to have picked up to here.
    private Image img;

    public bool imgState;
    private float imgTime;
    void Start()
    {
        img = GetComponent<Image>(); //Decided to move the image component,not sure if necessary, but it moves the entire gameObject as well.
        img.enabled = false;
        imgState = false;
        imgTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!mesh.GetComponent<Renderer>().enabled && imgTime <= 5.0f) //Looking at the mesh renderer of the object that we assigned earlier.
        {
            img.enabled = true;
            imgState = true;
        }
        else
        {
            imgState = false;
            img.enabled = false;
        }

        if (imgState)
        { 
            if(img.transform.localPosition.x >= 750.0f && imgTime < 3.0f) //The local position will change based on the current aspect ratio, use 1920x1080 so this looks right.
            {
                img.transform.localPosition -= new Vector3(5.0f, 0, 0); //Moving on-screen.
            }
            else if(imgTime >= 3.0f)
            {
                img.transform.localPosition += new Vector3(5.0f, 0, 0); //Moving off-screen.
            }

            imgTime += Time.deltaTime;
        }
    }
    //Still looking to make a queue for multiple item pickups, it'll probably also be attatched to the canvas.
}
