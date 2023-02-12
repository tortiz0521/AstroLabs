using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_MultiPoint : MonoBehaviour
{
    public List<Transform> points;
    public float speed = 10f;
    private int index = 0;

    // Update is called once per frame
    void Update()
    {
        Vector3 thisPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, points[index].position, speed * Time.deltaTime);

        if (thisPosition.Equals(points[index].position))
        {
            index++;
            if (index >= points.Count)
            {
                index = 0;
            }
        }
        
        
    }
}
