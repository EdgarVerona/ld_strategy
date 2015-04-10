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
		public float MaxSpeed = 2.0f;

		private Transform _transform;

		public StrategyCameraInput()
		{
			
		}

		private void Awake()
		{
			_transform = this.GetComponent<Transform>();
		}


		private void Update()
		{
			CrossPlatformInputManager.GetButtonDown("Jump");
		}


		private void FixedUpdate()
		{
			// Read the inputs.
			this._transform.Translate(GetDisplacement("Horizontal"), GetDisplacement("Vertical"), 0);
		}

		private float GetDisplacement(string axisName)
		{
			float axis = CrossPlatformInputManager.GetAxis(axisName);

			float displacement = axis * this.MaxSpeed * Time.deltaTime;

			return displacement;
		}
	}
}
