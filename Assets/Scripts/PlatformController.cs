﻿using UnityEngine;
using System.Collections;

public class PlatformController : RaycastController {

	public LayerMask passengerMask;
	public Vector3 move;

	// Use this for initialization
	public override void Start ()
	{
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {

		UpdateRaycastOrigins ();

		Vector3 velocity = move * Time.deltaTime;

		MovePassangers (velocity);
		transform.Translate (velocity);	
	}

	void MovePassangers(Vector3 velocity) {
		float directionX = Mathf.Sign (velocity.x);
		float directionY = Mathf.Sign (velocity.y);

		if (velocity.y != 0) {
			float rayLength = Mathf.Abs (velocity.y) + skinWidth;
			
			for (int i = 0; i < verticalRayCount; i++) {
				Vector2 rayOrigin = (directionY == -1)?raycastOrigins.bottomLeft:raycastOrigins.topLeft;
				rayOrigin += Vector2.right * (verticalRaySpacing * i);
				RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, passengerMask);

				if (hit) {
					float pushX = (directionY == 1) ? velocity.x:0;
					float pushY = velocity.y - (hit.distance - skinWidth) * directionY;

					hit.transform.Translate(new Vector3(pushX, pushY));
				}
			}
		}

		// Horizontally moving platform
		if (velocity.x != 0) {
			float rayLength = Mathf.Abs (velocity.x) + skinWidth;
			
			for (int i = 0; i < horizontalRayCount; i ++) {
				Vector2 rayOrigin = (directionX == -1)?raycastOrigins.bottomLeft:raycastOrigins.bottomRight;
				rayOrigin += Vector2.up * (horizontalRaySpacing * i);
				RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, passengerMask);
				
				if (hit) {
					float pushX = velocity.x - (hit.distance - skinWidth) * directionX;
					float pushY = 0;
						
					hit.transform.Translate(new Vector3(pushX,pushY));
				}
			}
		}
		
		// Passenger on top of a horizontally or downward moving platform
		if (directionY == -1 || velocity.y == 0 && velocity.x != 0) {
			float rayLength = skinWidth * 2;
			
			for (int i = 0; i < verticalRayCount; i ++) {
				Vector2 rayOrigin = raycastOrigins.topLeft + Vector2.right * (verticalRaySpacing * i);
				RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up, rayLength, passengerMask);
				
				if (hit) {
					float pushX = velocity.x;
					float pushY = velocity.y;
						
					hit.transform.Translate(new Vector3(pushX,pushY));
				}
			}
		}

	}
}
