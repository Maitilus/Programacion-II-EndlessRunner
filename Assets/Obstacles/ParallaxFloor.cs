using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxFloor : MonoBehaviour
{
    public float OffsetX = 1000;
    public float FloorSpeed = 10;


    void Update()
    {
        transform.position -= new Vector3(FloorSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x <= -OffsetX)
        {
            transform.position = new Vector3(OffsetX, transform.position.y, 0); 
        }
    }
}
