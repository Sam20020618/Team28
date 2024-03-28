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
    private Vector3 LastPos;
    public Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
         Cube.transform.position = Player.position * 2 + new Vector3(0,0,2);
    }

    // Update is called once per frame
    void Update()
    {
       
        StartCoroutine(ExampleCoroutine());
      
        // m_Rigidbody.AddForce(transform.up * 3);
       
    }

      IEnumerator ExampleCoroutine()
    {
     
         LastPos = Cube.position;

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);


         if(LastPos.x < Player.position.x)
       {
          Debug.Log("It changed");
          m_Rigidbody.AddForce(Vector3.left  * 1);
       } else {
         m_Rigidbody.AddForce(Vector3.right  * 1);
       }

      
    }
}
