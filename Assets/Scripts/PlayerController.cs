using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public static PlayerController playerController;
    public static bool isBlocked; //blocked by other object
    public static bool GameOver;//indicate game over

    private Rigidbody2D selfBody; //self regidbody2d

    public bool isThrough;//denote is the object is througn or not
    public float Distance;//distance from startpoint after through

    private Vector3 StartPoint; //start point of genome

    private bool isStopped; //indicate stopped once or more


	void Start () {
        selfBody = GetComponent<Rigidbody2D>();
        isThrough = false;
        playerController = this;
        StartPoint = transform.position;
        playerController = this;
        isBlocked = false;
        GameOver = false;//set game is not over at start
    }

    private void FixedUpdate()
    {

        if(selfBody.velocity.x < 1f)
        {
            GetComponent<ParticleSystem>().Stop();
            isStopped = true;
        }

        if (isStopped)
        {
            GetComponent<ParticleSystem>().Play();
            isStopped = false;
        }

       

        if (!isThrough)
            return;
        Distance = Vector3.Distance(StartPoint, transform.position);
        Debug.Log(Distance);
        if(selfBody.velocity.x < 0.1f && Mathf.Abs(selfBody.velocity.y) < 0.1f && !isBlocked) //call for gameover
        {
            if(Distance > PlayerPrefs.GetFloat("HighScore"))
            {
                PlayerPrefs.SetFloat("HighScore", Distance);
            }
            UiEvents.uiEvents.GameOver();
            GameOver = true;// broadcast the gameover message
        }
    }
}
