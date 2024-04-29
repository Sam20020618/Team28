﻿using System.Collections;
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
    private float Timeset = 0.5f;
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
   private bool Left;
   public bool left 
   {
    get
        {
          return Left;
        }
    set
    {
      Left = value;
    }
   }
   private bool Right;
   public bool right 
   {
    get
        {
          return Right;
        }
    set
    {
      Right = value;
    }
   }
   private bool Up;
   public bool up 
   {
    get
        {
          return Up;
        }
    set
    {
      Up = value;
    }
   }
   private bool Down;
   public bool down 
   {
    get
        {
          return Down;
        }
    set
    {
      Down = value;
    }
   }
    public Rigidbody rb;
  
    public float speed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
      Trigger = false;
      Clicktrigger = false;
      Timelock = Timeset;
      Left = false;
      Right = false;
      Up = false;
      Down = false;
      rb = GetComponent<Rigidbody>();
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
    //   if(Timelock <= 0)
    //   {
    //      Lastpos = Player.position;
    //      Timelock = Timeset;
    //   }
    //    else {
    //       Timelock -= Time.deltaTime;
    //    }
    //    Debug.Log(Lastpos);
    //     Debug.Log(Player.position);
    //    if(Lastpos.x < Player.position.x)
    //    {
    //      Debug.Log("Go left");
    //       rb.AddForce(0.1f, 0.0f, 0.0f);
    //    } else 
    //    {
    //       rb.AddForce(-0.1f, 0.0f, 0.0f);
    //         Debug.Log("Go Right");
    //    }
    //   //   if(Lastpos.y < Player.position.y)
    //   //  {
    //   //   rb.AddForce(0.0f, 0.1f, 0.0f);
    //   //  } else 
    //   //  {
    //   //     rb.AddForce(0.0f, -0.1f, 0.0f);
    //   //  }
           if(Left)
               {
                 Debug.Log("Go left");
                 rb.AddForce(-10.0f, 0.0f, 0.0f);
                 Left = false;
               }
                if(Right)
               {
                 rb.AddForce(10.0f, 0.0f, 0.0f);
                 Right = false;
               }
                if(Up)
               {
                 rb.AddForce(0.0f, 10.0f, 0.0f);
                 Up = false;
               }
                if(Down)
               {
                 Debug.Log("Go left");
                 rb.AddForce(0.0f, -10.0f, 0.0f);
                 Down = false;
               }
     }
  }

     
}
