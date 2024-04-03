using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.Core.Fader;
using Liminal.Platform.Experimental.App.Experiences;
using Liminal.SDK.Core;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Avatars;
using Liminal.SDK.VR.Input;

public class FollowHand : MonoBehaviour
{
    public Transform Cube;
    public Transform Player;
    private bool Trigger;
  
    public float speed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
      Trigger = false;
    }

    // Update is called once per frame
    void Update()
    {
       var step =  speed * Time.deltaTime;
       if(!Trigger)
       {
          transform.position = Vector3.MoveTowards(transform.position, Player.position, step);
       }
     

       if (Vector3.Distance(transform.position, Player.position) < 2.0f)
        {
          Trigger = true;
        }
    }

     
}
