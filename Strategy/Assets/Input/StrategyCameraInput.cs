using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Assets.Input
{
	public class StrategyCameraInput : MonoBehaviour
	{
		
		private void Awake()
		{
		}


		private void Update()
		{
			CrossPlatformInputManager.GetButtonDown("Jump");
		}


		private void FixedUpdate()
		{
			// Read the inputs.
			//bool crouch = Input.GetKey(KeyCode.LeftControl);
			//float h = CrossPlatformInputManager.GetAxis("Horizontal");
	}
}
