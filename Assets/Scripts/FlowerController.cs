using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerController : MonoBehaviour {

    public bool isReady;//ready to play animation or not
    public bool isMoveable;//define the gameobject is moveabe or not

    private Animator SelfAnimator;//self animator component


	void Start () {
        isReady = true; //set ready at start
        SelfAnimator = GetComponent<Animator>();//get reference
        transform.localScale = Vector3.zero; //shrink to zero on start
    }
	
	// Update is called once per frame
	void Update () {
        if (isMoveable)
        {
            if(transform.position.x <= Camera.main.transform.position.x - 10f)
            {
                Debug.Log("CameraPassed!");
                SelfAnimator.enabled = false;//stop animation
                transform.localScale = Vector3.zero;//shrink to zero
                transform.position += Vector3.right * 24f;//move forward
                isReady = true;//set ready for next transection 
            }
        }

        if (!isReady)
            return;
		if(PlayerController.playerController.transform.position.x > transform.position.x -0.2f)
        {
            isReady = false;
            if (SelfAnimator.enabled)
            {
                SelfAnimator.Rebind();
            }
            else
            {
                SelfAnimator.enabled = true;
                SelfAnimator.Rebind();
            }
        }
	}
}
