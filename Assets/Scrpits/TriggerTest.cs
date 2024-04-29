using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger happen");
        //  if (other.CompareTag("Hand"))
        // {
        //     Destroy(other.gameObject);
        // }
    }
}
