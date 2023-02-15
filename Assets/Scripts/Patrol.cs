//LATEST VERSION
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public bool toPosB = true;
    public bool rot = false;
    public float speed = 10f;
    private Vector3 pointAPosition;
    private Vector3 pointBPosition;
    public int counter;
    // Use this for initialization
    void Start()
    {
        //point a is start point point b is end
        pointAPosition = new Vector3(pointA.position.x, pointA.position.y, pointA.position.z);
        pointBPosition = new Vector3(pointB.position.x, pointB.position.y, pointB.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //getting patrol's current position
        Vector3 thisPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //walking to point b
        if (toPosB)
        {
            if(!rot)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
            }
            

            if (thisPosition.Equals(pointBPosition))    //true if object has reached the end point and they need to turn around!
            {
                //Debug.Log ("Position b");
                toPosB = false;
                rot = true;         //turn around (at end of update())

            }
        }
        //walking back to point a
        else
        {
            if(!rot)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
            }           


            if (thisPosition.Equals(pointAPosition))
            {
                //Debug.Log ("Position a");
                toPosB = true;
                rot = true;
                //at end, turn around
            }

        }

        //put rotation here (not in nested conditional statements)
        //at end, turn around
        if (rot)
        {
            transform.RotateAround(transform.position, Vector3.up, 60 * Time.deltaTime);
        }

        //reset rot to false since we are no longer rotating
        if (!toPosB && transform.rotation.eulerAngles.y > -0.5 && transform.rotation.eulerAngles.y < 0.5 || toPosB && transform.rotation.eulerAngles.y > 179.5 && transform.rotation.eulerAngles.y < 180.5)
        {
            rot = false;
        }

    }
}