using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Controller2d))]
public class player : MonoBehaviour {

	public float jumpHeight = 4;
	public float timeToJumpApex = .4f;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;

	float moveSpeed = 6;
	float jumpVelocity;
	float gravity;
	Vector3 velocity;
	float velocityXSmoothing;

	Controller2d controller;
	Animate animate;

	// Use this for initialization
	void Start () {
		controller = GetComponent<Controller2d> ();
		animate = GetComponent<Animate> ();
	
		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
	}
	
	// Update is called once per frame
	void Update () {

		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}

		// Get movement input
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		// Handle Jump input
		if (Input.GetKeyDown (KeyCode.Space) && controller.collisions.below) {
			velocity.y = jumpVelocity;
		}

		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);

		// Handle character sprites
		if (velocity.x > 0) {
			animate.StandRight();
		}
		else if (velocity.x < 0) {
			animate.StandLeft();
		}
		if (velocity.y > 0) {
			if (velocity.x < 0) {
				animate.JumpLeft();
			}
			else {
				animate.JumpRight();
			}
		}
	}
}
