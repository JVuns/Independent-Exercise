/* 
This is all a work in progress, please dont judge me and try not to break anything



*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
namespace Player {
	public class Player_Hook_Movement : MonoBehaviour
	{
		public float MaxDist; //The furthest the player can get from the target
		public Transform TargetObject; //In future, this will be set every time you grapple
		private Rigidbody2D PlayerBody; //no comment
        private Vector2 Velocity; //How fast the player is going
        private Vector2 Velocity2; //A temporary variable
        private Vector3 Position; //The player's position, with a magnitude between 0 and 1.
        private Vector3 Target; //The position of the TargetObject
        private float x; //debug variable, will be removed 
    	void Start()
    	{
    	    PlayerBody = GetComponent<Rigidbody2D>();
    	}

    	// Update is called once per frame
    	void Update()
    	{

    	    if (Input.GetKeyDown("c")) {
                Target = TargetObject.position; //This is the only time TargetObject is used
                Position = PlayerBody.transform.position - Target; //The order of these is important
                MaxDist = Position.magnitude; //The player can never get further away from the target than they were when they started
                MaxDist = MaxDist < 1.5f ? 1.5f : MaxDist; //Unless they're within 1.5 units to start
                Velocity = PlayerBody.velocity; //The speed here is saved because looking it up each time is probably slow
                Position = Position / MaxDist; //This makes sure the position has a magnitude between 0 and 1
        		//PlayerBody.velocity = ((Target - PlayerBody.transform.position).normalized * 20); //This will be used later for a version of the hook that launches you
                x = 0; //Debug
        	}
    	    if (Input.GetKey("c")) {
                Velocity = PlayerBody.velocity; //This is all the same as up there
                Position = PlayerBody.transform.position - Target;
                Position = Position / MaxDist;
                Debug.Log(Position.x); //Debug again
                Debug.Log(x);
        		//PlayerBody.AddForce((Target - PlayerBody.transform.position).normalized * 20);
        		if (Position.magnitude > 1) //If you're outside the max radius. put yourself inside and adjust speed. You have full permission to redo this if you know a better way
        		{
                    Position = Position.normalized; //Sets magnitude to 1
        			Velocity2 = (Vector3.Project(Velocity, Vector2.Perpendicular(Position))); //This makes the vector align with the circle, so you go around
                    if (Vector2.Angle(Velocity2, Velocity) > 10) //This is why there are 2 Velocities
                    {
                        Velocity2 = Velocity2.normalized * Velocity.magnitude; //This makes it so if the speed  is already nearly on the circle, you keep full pseed rather than losing some to the conversion
                    }
                PlayerBody.velocity = Velocity2;
                PlayerBody.transform.position = (Position * MaxDist) + Target; //Convert back to world coords
                x++;
        		}
        	}
    	}
	}
}