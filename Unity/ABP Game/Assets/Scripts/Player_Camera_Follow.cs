using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera_Follow : MonoBehaviour
{
	[SerializeField]
	[Tooltip("The transform for the default target. Usually the player.")]
	private Transform PlayerTransform;
    private int CameraTargetTimer;
    private Vector2 CameraTarget;
    //[Tooltip("The camera's speed. It will automatically get faster when far away from the target")]
    //public double CameraSpeed;
    private Vector3 CameraSpeed;
    private Vector3 CameraTarget3;
    public void SetTarget(Vector2 Location, double Seconds)//Please call this function to move the camera
    {
        CameraTarget = Location;
        CameraTargetTimer = (int)Seconds*60;
    }
    void Start()
    {
    CameraTarget3 = PlayerTransform.position + new Vector3(0,0,-50);//this sets up the camera target, and moves it to the origin
    transform.position = CameraTarget3;
    }

    void Update()
    {
        //if (Input.GetKeyDown("c")) {this.SetTarget(new Vector2(0,0), 5);} //Debug code, won't be in the final game
        if (CameraTargetTimer > 0){CameraTargetTimer--;} //This decrements the variable every frame, as advertised
        if ((CameraTargetTimer > 0) || (CameraTargetTimer == -100)) //This part sets the camera target to either it's default target or temporary target
        {
            CameraTarget3 = (Vector3)CameraTarget + (Vector3.back * 50); 
        }
        else
        {
            CameraTarget3 = PlayerTransform.position + new Vector3(0,0,-50) + (Vector3)(PlayerTransform.GetComponent<Rigidbody2D>().velocity/10);
        }
        transform.position = Vector3.SmoothDamp(transform.position, CameraTarget3, ref CameraSpeed, 0.25f);//This actually moves the camera
    }
}
