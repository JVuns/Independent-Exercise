using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Script : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The transform for the source bullet.")]
    private Rigidbody2D projectile;
    [SerializeField]
    [Tooltip("The speed of the bullet, won't affect existing bullets if changed")]
    public float speed = 10;
    void Update ()
    {
        if (Input.GetKeyDown("v"))
        {
            bool flip = GetComponent<SpriteRenderer>().flipX;//This makes bullets face the right way
            Rigidbody2D instantiatedProjectile = Instantiate(projectile,transform.position + (Vector3.right*0.8f*(flip? -1 : 1)),transform.rotation)as Rigidbody2D;//This makes a new projectile in front of you
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector2(speed*(flip? -1 : 1),Input.GetAxisRaw ("Vertical")*2));//This makes it move the right way
            instantiatedProjectile.gameObject.GetComponent<SpriteRenderer>().flipX = flip;//This makes it visually face the right way
        }
    }
}
