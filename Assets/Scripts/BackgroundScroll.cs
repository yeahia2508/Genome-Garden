using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {
    public float Speed; //scrolling speed
    public float ScrollSpeed;//spedd to scroll
    public bool isGround;//define it's ground or not
    public BoxCollider2D GroundCollider;
    
    public static bool Scroll; //switch to active/inactive the scrolling

	// Use this for initialization
	void Start () {
        if (isGround)
            GroundCollider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!Scroll)
            return;
        GetComponent<SpriteRenderer>().size += Vector2.right * Speed*PlayerController.playerController.GetComponent<Rigidbody2D>().velocity.x * Time.deltaTime;//scroll the background
        transform.position -= Vector3.left * Time.deltaTime*PlayerController.playerController.GetComponent<Rigidbody2D>().velocity.x*ScrollSpeed;

        if(isGround)
        {
            //GroundCollider.offset  += Vector2.right * Speed * PlayerController.playerController.GetComponent<Rigidbody2D>().velocity.x * Time.deltaTime;//move the ground collider
            GroundCollider.offset = new Vector2(PlayerController.playerController.transform.position.x, GroundCollider.offset.y);
        }
    }
}
