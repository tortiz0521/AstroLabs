using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceDetection : MonoBehaviour
{
    //Attach this script to the player capsule object!
    public bool isImgOn;
    public Image radarOff; //attach radar off image object from Canvas/UI
    public Image radarOn; //attach radar on image object from Canvas/UI
    public float minDistNear = 10;
    public float minDistMedium = 30;
    public GameObject collectable; //drag and drop collectable object/prefab into this field in the properties box
    public GameObject radarDisplay; //drag and drop particle system into this field in the properties box, make sure the system is attached to the player capsule and put low to the ground


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(collectable.transform.position, transform.position);
        // I made the E key the button for the radar to be on but you can change this to whatever you want
        if (!Input.GetKey("e")) // when E key is not pressed (radar is off)
        {
            radarOn.enabled = false;
            isImgOn = false;
            radarDisplay.SetActive(false); //turns off particle system
            Debug.Log("Radar OFF"); 
        }
        else if (Input.GetKey("e")) // when E key is pressed and held down (radar is on)
        {
            radarOn.enabled = true;
            isImgOn = true;
            radarDisplay.SetActive(true);
            if (dist > minDistMedium) //if object is far away from player
            {
                Debug.Log("Radar ON, Player is Far From Object. Distance: " + dist);
                
                //Audio/ UI Functionality in here for Far indicator
            }
            else if (dist > minDistNear && dist <= minDistMedium) //if object is somewhat close to player
            {
                Debug.Log("Radar ON, Player is Somewhat Close to Object. Distance: " + dist);

                //Audio/ UI Functionality in here for Medium Range indicator
            }
            else if (dist <= minDistNear) //if object is very close to player
            {
                Debug.Log("Radar ON, Player is Close to Object. Distance: " + dist);

                //Audio/ UI Functionality in here for Close indicator
            }
        }
    }
}
