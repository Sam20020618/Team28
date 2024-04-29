using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    
    [SerializeField] private float floatSpeed;
    [SerializeField] private float floatHeight;

    [SerializeField] private float arcRadius;
    [SerializeField] private float arcSpeed;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed * Mathf.PI) * (floatHeight / 2);


        float newX = startPos.x + Mathf.Cos(Time.time * arcSpeed) * arcRadius;

        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}
