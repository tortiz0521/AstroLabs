using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    //Rotational Speed
    public Vector3 speed;

    //Forward Direction
    public bool ForwardX = false;
    public bool ForwardY = false;
    public bool ForwardZ = false;

    //Reverse Direction
    public bool ReverseX = false;
    public bool ReverseY = false;
    public bool ReverseZ = false;

    void Update()
    {
        //Forward Direction
        if (ForwardX == true)
        {
            transform.Rotate(Time.deltaTime * speed.x, 0, 0, Space.Self);
        }
        if (ForwardY == true)
        {
            transform.Rotate(0, Time.deltaTime * speed.y, 0, Space.Self);
        }
        if (ForwardZ == true)
        {
            transform.Rotate(0, 0, Time.deltaTime * speed.z, Space.Self);
        }
        //Reverse Direction
        if (ReverseX == true)
        {
            transform.Rotate(-Time.deltaTime * speed.x, 0, 0, Space.Self);
        }
        if (ReverseY == true)
        {
            transform.Rotate(0, -Time.deltaTime * speed.y, 0, Space.Self);
        }
        if (ReverseZ == true)
        {
            transform.Rotate(0, 0, -Time.deltaTime * speed.z, Space.Self);
        }

    }
}
