using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform target;
    [SerializeField] private float minDist;

    [SerializeField] private float bobSpeed;
    [SerializeField] private float bobAmount;
    private bool handTouch = false;

    enum OrbState
    {
        spawn, idle, moving, up
    };
    
    [SerializeField] private OrbState orbState;

    private float yOffset;
    private Vector3 newPosition;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        switch(orbState)
        {
            case OrbState.spawn:
                
                if(transform.position.y < yOffset)
                {
                    transform.Translate(Vector3.up * speed/2 * Time.deltaTime);
                } else 
                {
                    orbState = OrbState.moving;
                }

                break;

            case OrbState.idle:
                yOffset = Mathf.Sin(Time.time * bobSpeed) * bobAmount;
                newPosition = transform.position;
                newPosition.y += yOffset;

                transform.position = newPosition;

                break;

            case OrbState.moving:
                transform.LookAt(target);
                float distance = Vector3.Distance(transform.position, target.position);

                if(distance > minDist)
                {

                    yOffset = Mathf.Sin(Time.time * bobSpeed) * bobAmount;

                    newPosition = transform.position + transform.forward * speed * Time.deltaTime;
                    newPosition.y += yOffset;

                    transform.position = newPosition;
                    //transform.position += transform.forward * speed * Time.deltaTime;
                }
                if(handTouch)
                {
                    orbState = OrbState.up;
                }

                if(distance <= minDist)
                {
                    orbState = OrbState.idle;
                }
                break;

            case OrbState.up:
                transform.Translate(Vector3.up * Time.deltaTime, Space.World);
                break;
        }
    }

    public void SpawnMovement(float moveOffset)
    {
        yOffset = moveOffset;
        orbState = OrbState.spawn;
    }

   void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger happen");
         if (other.CompareTag("Hand"))
        {
           handTouch = true;
        }
    }
}
