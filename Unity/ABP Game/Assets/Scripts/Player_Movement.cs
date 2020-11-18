using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player {
    public class Player_Movement : MonoBehaviour
    {
        private Rigidbody2D PlayerBody;
        [Header("Player Variables")]
        [Tooltip("Horizontal Friction")]
        public float FricYou;
        [Tooltip("Jump Height")]
        public float GettingHigh;
        [Tooltip("Player HP. You can freely modify this, don't worry about conflicts or w/e")]
        public float HP = 100;
        void Start()
        {
            PlayerBody = GetComponent<Rigidbody2D>();
        }
        void Update()
        {
            if (Input.GetKeyDown("x"))//Jumping
        	{
            	PlayerBody.velocity = (new Vector2(PlayerBody.velocity[0],GettingHigh));
        	}
            if (Input.GetAxisRaw ("Horizontal") < 0)//This controls which way the player faces
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            if (Input.GetAxisRaw ("Horizontal") > 0)//This too
            {
            GetComponent<SpriteRenderer>().flipX = false;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))//This is for crouching
            {
            PlayerBody.transform.localScale = new Vector3(0.25f,0.35f,1f);
            PlayerBody.transform.position += Vector3.down * .32f;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))//This is for uncrouching
            {
            PlayerBody.transform.localScale = new Vector3(0.25f,.6f,1f);
            PlayerBody.transform.position += Vector3.up * .32f;
            }
            if (Input.GetKeyDown("r"))//Debug reset code
            {
                PlayerBody.transform.position = new Vector3(-5,2,0);
            }
        
            }
            void FixedUpdate()
            {
                PlayerBody.AddForce(new Vector2(Input.GetAxisRaw ("Horizontal")*70,0)); //This is the left/right movement. The first number is how fast you accelerate
            PlayerBody.AddForce(new Vector2(PlayerBody.velocity[0]/(-FricYou),0)); //Horizontal friction
            if (PlayerBody.velocity.y < 0 ) //This makes your jumps floatier
            {
                PlayerBody.gravityScale = 4f;
            }
            else 
           {
                PlayerBody.gravityScale = Input.GetKey("x") ? 1.3f : 4f; //Hold the button to have lower gravity and thus jump higher
            }
        }
    }
}