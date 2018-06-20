using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public static PlayerController playerController;

    private Rigidbody2D selfBody; //self regidbody2d

    public bool isThrough;//denote is the object is througn or not

	// Use this for initialization
	void Start () {
        selfBody = GetComponent<Rigidbody2D>();
        isThrough = false;
        playerController = this;
	}

    private void FixedUpdate()
    {

        if (!isThrough)
            return;

        if(selfBody.velocity == Vector2.zero) //call for gameover
        {
            UiEvents.uiEvents.GameOver();
        }
    }
}
