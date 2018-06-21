using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public static PlayerController playerController;

    private Rigidbody2D selfBody; //self regidbody2d

    public bool isThrough;//denote is the object is througn or not
    public float Distance;//distance from startpoint after through

    private Vector3 StartPoint; //start point of genome

	// Use this for initialization
	void Start () {
        selfBody = GetComponent<Rigidbody2D>();
        isThrough = false;
        playerController = this;
        StartPoint = transform.position;

    }

    private void FixedUpdate()
    {

        if (!isThrough)
            return;
        Distance = Vector3.Distance(StartPoint, transform.position);
        Debug.Log(Distance);
        if(selfBody.velocity == Vector2.zero) //call for gameover
        {
            if(Distance > PlayerPrefs.GetFloat("HighScore"))
            {
                PlayerPrefs.SetFloat("HighScore", Distance);
            }
            UiEvents.uiEvents.GameOver();
        }
    }
}
