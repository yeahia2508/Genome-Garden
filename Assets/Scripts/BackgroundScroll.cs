using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {
    public float Speed; //scrolling speed
    public float ScrollSpeed;
    
    public static bool Scroll; //switch to active/inactive the scrolling

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!Scroll)
            return;
        GetComponent<SpriteRenderer>().size += Vector2.right * Speed*PlayerController.playerController.GetComponent<Rigidbody2D>().velocity.x * Time.deltaTime;//scroll the background
        transform.position -= Vector3.left * Time.deltaTime*PlayerController.playerController.GetComponent<Rigidbody2D>().velocity.x*ScrollSpeed;
	}
}
