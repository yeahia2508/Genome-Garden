using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform Target; //thre target transfor to follow
    public static bool Follow; //switch to active/inactive the follow
    public static bool FollowUpDownOnly; //follow the y axis only


    private float BottomLimit;//limit to go down 

    private void Start()
    {
        Follow = false;
        FollowUpDownOnly = false;
        BottomLimit = transform.position.y; //set the start y position for bottom limit
    }

    void Update () {
        if (!Follow)
            return;

        float deltaY = Mathf.Clamp(Target.position.y, BottomLimit, Mathf.Infinity);
        Vector3 temp;
        if (FollowUpDownOnly)
        {
            temp = new Vector3(transform.position.x, deltaY, transform.position.z); //calculate the target position 
            transform.position = temp; //move to the target position
            return;
        }


        temp = new Vector3(Target.position.x, deltaY, transform.position.z); //calculate the target position 
        transform.position = temp; //move to the target position
	}
}
