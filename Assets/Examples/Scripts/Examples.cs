﻿using System.Collections;
using Liminal.Core.Fader;
using Liminal.Platform.Experimental.App.Experiences;
using Liminal.SDK.Core;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Avatars;
using Liminal.SDK.VR.Input;
using UnityEngine;

namespace Liminal.Examples
{
    public class Examples : MonoBehaviour
    {
        public Transform Cube;
        public Transform Player;
        public MoveStar move;
        private bool hit = false;

        private void Update()
        {
            var avatar = VRAvatar.Active;
            if (avatar == null)
                return;

            var rightInput = GetInput(VRInputDeviceHand.Right);
            var leftInput = GetInput(VRInputDeviceHand.Left);

            // Input Examples
            if (rightInput != null)
            {
                if (rightInput.GetButtonDown(VRButton.Back))
                    Debug.Log("Back button pressed");

                if (rightInput.GetButtonDown(VRButton.One))
                    Debug.Log("Trigger button pressed");
            }

            if (leftInput != null)
            {
                if (leftInput.GetButtonDown(VRButton.Back))
                    Debug.Log("Back button pressed");

                if (leftInput.GetButtonDown(VRButton.One))
                    Debug.Log("Trigger button pressed");
            }

            // Any input
            // VRDevice.Device.GetButtonDown(VRButton.One);
        }

        private IVRInputDevice GetInput(VRInputDeviceHand hand)
        {
            var device = VRDevice.Device;
            return hand == VRInputDeviceHand.Left ? device.SecondaryInputDevice : device.PrimaryInputDevice;
        }

        /// <summary>
        /// End will only close the application when you're within the platform
        /// </summary>
        public void End()
        {
            ExperienceApp.End();
        }

        public void FadeToBlack()
        {
            StartCoroutine(FadeToBlackRoutine());
        }

        private IEnumerator FadeToBlackRoutine()
        {
            ScreenFader.Instance.FadeTo(Color.black, duration: 1);
            yield return ScreenFader.Instance.WaitUntilFadeComplete();
            ScreenFader.Instance.FadeToClear(duration: 1);
        }

        public void ChangeCubeSize()
        {
            Cube.localScale = Vector3.one * Random.Range(0.1f, 0.35F);
        }

        public void ChangeCubePos()
        {
            Cube.transform.position = Player.position + new Vector3(0,1,0);
        }
         public void ClickHappened()
        {
            move.ClickTrigger = true;
            hit = true;
        }

         public void RandomMove()
        {
            if(hit)
            {
                var position = Random.Range(0.0f, 4.0f);
                Debug.Log("The postion is" + position);
               if(position <= 1)
               {
                Debug.Log("Left click worked");
                 move.left = true;
               }
               if(position <= 2 && position > 1)
               {
                 move.right = true;
               }
               if(position <= 3 && position > 2)
               {
                 move.up = true;
               }
               if(position <= 4 && position > 3)
               {
                 move.down = true;
               }
            }
        }
  }
}
