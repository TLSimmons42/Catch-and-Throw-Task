using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Vector3 target;
    public float speed = 5.0f;
    float t;

    public Vector3 yOffset; 
    public Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        yOffset = new Vector3(0, -2, 0);
    }

    private void Update()
    {
        t = (t + Time.deltaTime);
        transform.position = Vector3.Slerp(startPos - yOffset, target - yOffset, t/speed);
        transform.position += yOffset;
        if(transform.position == target)
        {
            Destroy(gameObject);
        }
    }
}
