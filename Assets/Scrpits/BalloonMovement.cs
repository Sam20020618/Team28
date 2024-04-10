using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    
    [SerializeField] private float floatSpeed;
    [SerializeField] private float floatHeight;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
