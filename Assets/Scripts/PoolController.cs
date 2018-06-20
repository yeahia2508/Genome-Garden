using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour {

    public Rigidbody2D StickBody; //reference to the rigidbody2d of the stick
    public Rigidbody2D BusketBody;//reference to the rigidbody2d of the busket
    public Rigidbody2D ThroughObjectBody; //reference to the rigidbody2d to the through object

    public int TapCount; //counts the taps
    public bool isThrough; //throughn or not

    private void Start()
    {
        TapCount = 0;// initialize the tapcount
    }

    // Update is called once per frame
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
            if(TapCount == 1) //for first click
            {
                StickBody.bodyType = RigidbodyType2D.Dynamic; //makes the rigidbody of the stick active
                CameraFollow.Follow = true; //activate the camera follow
                CameraFollow.FollowUpDownOnly = true; //activate the camera follow


            }
            else if(TapCount == 2) //for second click
            {
                //through the basket and through object
                Destroy(BusketBody.GetComponent<HingeJoint2D>()); //destroy busket joint
                Destroy(BusketBody.GetComponent<DistanceJoint2D>());//destroy busket joint
                Destroy(ThroughObjectBody.GetComponent<FixedJoint2D>());//destroy through object joint
                BusketBody.velocity *= 1.5f;//modify busket velocity
                ThroughObjectBody.velocity *= 3f;//modify busket velocity
                ThroughObjectBody.transform.parent = null;//clear parent
                ThroughObjectBody.GetComponent<ParticleSystem>().Play();//start playing particles
                CameraFollow.FollowUpDownOnly = false; //activate the camera follow
                BackgroundScroll.Scroll = true;//start backgrounds scrolling
                Camera.main.gameObject.GetComponent<Animator>().enabled = true;//enables the camera zoomout
                PlayerController.playerController.isThrough = true;//say the player that is throughn
            }
        }
#elif UNITY_ANDROID || UNITY_IOS


      if (Input.touchCount>0) //detect mouse click 
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.Log("Clicked");
                TapCount++; //count clicks
            }
            else return;
           
            if (TapCount == 1) //for first click
            {
                StickBody.bodyType = RigidbodyType2D.Dynamic; //makes the rigidbody of the stick active
                CameraFollow.Follow = true; //activate the camera follow
                CameraFollow.FollowUpDownOnly = true; //activate the camera follow

            }
            else if (TapCount == 2) //for second click
            {
                //through the basket and through object
                Destroy(BusketBody.GetComponent<HingeJoint2D>());//destroy busket joint
                Destroy(BusketBody.GetComponent<DistanceJoint2D>());//destroy busket joint
                Destroy(ThroughObjectBody.GetComponent<FixedJoint2D>());//destroy through object joint
                BusketBody.velocity *= 1.5f; //modify busket velocity
                ThroughObjectBody.velocity *= 3f; //modify through object velocity
                ThroughObjectBody.transform.parent = null;//clear parent
                ThroughObjectBody.GetComponent<ParticleSystem>().Play();//start playing particles
                CameraFollow.FollowUpDownOnly = false; //activate the camera follow
                BackgroundScroll.Scroll = true;//start backgrounds scrolling
                Camera.main.gameObject.GetComponent<Animator>().enabled = true;//enables the camera zoomout
                PlayerController.playerController.isThrough = true;//say the player that is throughn

            }
        }


#endif





    }






}
