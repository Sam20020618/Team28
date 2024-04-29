using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMove : MonoBehaviour
{
    [SerializeField] float handSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          if(Input.GetButtonDown("Horizontal"))
        {
            Debug.Log("Hand is moving");
        }

        float x = Input.GetAxis("Horizontal") * handSpeed *Time.deltaTime;
        float y = Input.GetAxis("Vertical") * handSpeed *  Time.deltaTime;

        transform.Translate(x, y, 0);
    }
}
