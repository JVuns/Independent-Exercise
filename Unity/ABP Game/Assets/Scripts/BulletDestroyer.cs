using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    // OnTriggerEnter2D is called each time the bullet collides with something
    public void OnTriggerEnter2D(Collider2D other)
    {
    	Destroy(gameObject);
    }
    void Start()
    {
    	if (gameObject.name == "Bullet")
    	{
    		GetComponent<Collider2D>().enabled = false;
    		GetComponent<SpriteRenderer>().forceRenderingOff = true;
    	}
    	else
    	{
    		GetComponent<Collider2D>().enabled = true;
    		GetComponent<SpriteRenderer>().forceRenderingOff = false;
    	}
    }
    void Update()
    {
    	if (Input.GetKeyDown("b"))
    	{
    		if (gameObject.name != "Bullet")
    		{
    			Destroy(gameObject);
    		}
    	}
    }
}
