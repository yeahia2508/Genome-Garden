﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PoolController : MonoBehaviour {

    public Rigidbody2D StickBody; //reference to the rigidbody2d of the stick
    public Rigidbody2D BusketBody;//reference to the rigidbody2d of the busket
    public Rigidbody2D ThroughObjectBody; //reference to the rigidbody2d to the through object
    public GameObject GenomeSelectUi;//reference to the genome choose dialog
    public GameObject GameUi;//reference to the Game Ui
    public int TapCount; //counts the taps
    public bool isThrough; //throughn or not

    private void Start()
    {
        TapCount = 0;// initialize the tapcount
    }

 
    void Update () {

        if (isThrough)
        {
            if (transform.position.y <= 5f)
            {

            }
        }


#if UNITY_EDITOR 
        //tap funtions on display
        if (Input.GetMouseButtonDown(0)) //detect mouse click 
        {
            Debug.Log("Clicked");
            TapCount++; //count clicks
            if(TapCount == 1 && !EventSystem.current.IsPointerOverGameObject()) //for first click
            {
                StickBody.bodyType = RigidbodyType2D.Dynamic; //makes the rigidbody of the stick active
                CameraFollow.Follow = true; //activate the camera follow
                CameraFollow.FollowUpDownOnly = true; //activate the camera follow
                GenomeSelectUi.SetActive(false);//hide the genome selection dialog
                GameUi.SetActive(true);//show the game ui;

            }
            else if(TapCount == 2) //for second click
            {
                //through the basket and through object
                Destroy(BusketBody.GetComponent<HingeJoint2D>()); //destroy busket joint
                Destroy(BusketBody.GetComponent<DistanceJoint2D>());//destroy busket joint
                Destroy(ThroughObjectBody.GetComponent<FixedJoint2D>());//destroy through object joint
                BusketBody.velocity *= 1.1f;//modify busket velocity
                ThroughObjectBody.velocity *= 1.6f;//modify busket velocity
                ThroughObjectBody.transform.parent = null;//clear parent
                ThroughObjectBody.GetComponent<ParticleSystem>().Play();//start playing particles
                ThroughObjectBody.GetComponent<CapsuleCollider2D>().enabled = true;//enable collision
                ThroughObjectBody.GetComponent<Rigidbody2D>().drag = 0.3f;//set linear drag
                ThroughObjectBody.GetComponent<Rigidbody2D>().angularDrag = 0.5f;//set angular drag
                CameraFollow.FollowUpDownOnly = false; //activate the camera follow
                BackgroundScroll.Scroll = true;//start backgrounds scrolling
                Camera.main.gameObject.GetComponent<Animator>().enabled = true;//enables the camera zoomout
                PlayerController.playerController.isThrough = true;//say the player that is throughn
                GameUi.GetComponent<Animator>().SetTrigger("Switch");//bring full ui
            }
            else
            {
                TapCount = 0;
            }

           
        }
#elif UNITY_ANDROID || UNITY_IOS


      if (Input.touchCount>0) //detect touch 
        {
       
            if (Input.GetTouch(0).phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                Debug.Log("Clicked");
                TapCount++; //count clicks
            }
            else return;
           
            if (TapCount == 1) //for first touch
            {
                StickBody.bodyType = RigidbodyType2D.Dynamic; //makes the rigidbody of the stick active
                CameraFollow.Follow = true; //activate the camera follow
                CameraFollow.FollowUpDownOnly = true; //activate the camera follow
                GenomeSelectUi.SetActive(false);//hide the genome selection dialog
                GameUi.SetActive(true);//show the game ui;

            }
            else if (TapCount == 2) //for second touch
            {
                //through the basket and through object
                Destroy(BusketBody.GetComponent<HingeJoint2D>());//destroy busket joint
                Destroy(BusketBody.GetComponent<DistanceJoint2D>());//destroy busket joint
                Destroy(ThroughObjectBody.GetComponent<FixedJoint2D>());//destroy through object joint
                BusketBody.velocity *= 1.1f; //modify busket velocity
                ThroughObjectBody.velocity *= 1.6f; //modify through object velocity
                ThroughObjectBody.transform.parent = null;//clear parent
                ThroughObjectBody.GetComponent<ParticleSystem>().Play();//start playing particles
                ThroughObjectBody.GetComponent<CapsuleCollider2D>().enabled = true;//enable collision
                ThroughObjectBody.GetComponent<Rigidbody2D>().drag = 0.3f;//set linear drag
                ThroughObjectBody.GetComponent<Rigidbody2D>().angularDrag = 0.5f;//set angular drag
                CameraFollow.FollowUpDownOnly = false; //activate the camera follow
                BackgroundScroll.Scroll = true;//start backgrounds scrolling
                Camera.main.gameObject.GetComponent<Animator>().enabled = true;//enables the camera zoomout
                PlayerController.playerController.isThrough = true;//say the player that is throughn
                GameUi.GetComponent<Animator>().SetTrigger("Switch");//bring full ui

            }
        }


#endif





    }






}
