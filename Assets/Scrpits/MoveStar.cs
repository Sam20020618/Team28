using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.Core.Fader;
using Liminal.Platform.Experimental.App.Experiences;
using Liminal.SDK.Core;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Avatars;
using Liminal.SDK.VR.Input;

public class MoveStar : MonoBehaviour
{
    public Transform Cube;
    public float Timelock;
    private float Timeset = 1.0f;
    public Transform Player;
    private Vector3 Lastpos;
    private bool Trigger;
   private bool Clicktrigger;
   public bool ClickTrigger 
   {
    get
        {
          return Clicktrigger;
        }
    set
    {
      Clicktrigger = value;
    }
   }
  
    public float speed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
      Trigger = false;
      Clicktrigger = false;
      Timelock = Timeset;
    }

    // Update is called once per frame
    void Update()
    {
      if(Clicktrigger)
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
    if(Trigger)
    {
      if(Timelock <= 0)
      {
         Lastpos = Player.position;
         Timelock = Timeset;
      }
       else {
          Timelock -= Time.deltaTime;
       }
       Debug.Log(Lastpos);
        Debug.Log(Player.position);
       if(Lastpos.x < Player.position.x)
       {
         Debug.Log("Go left");
         transform.Translate(Vector3.left * Time.deltaTime);
       } else 
       {
         transform.Translate(Vector3.right * Time.deltaTime);
       }
      //   if(Lastpos.y < Player.position.y)
      //  {
      //    Debug.Log("Go left");
      //    transform.Translate(Vector3.up * Time.deltaTime);
      //  } else 
      //  {
      //    transform.Translate(Vector3.down * Time.deltaTime);
      //  }
    }
  }

     
}
