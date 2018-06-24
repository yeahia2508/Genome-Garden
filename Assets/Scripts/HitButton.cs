using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitButton : MonoBehaviour {

    public Rigidbody2D ThroughObjectBody;//reference to the player rigirbody2d


    public void HitButtonPressEvent()
    {
        if (PlayerController.GameOver)
            return; 

        GetComponent<Animator>().SetTrigger("Switch"); //change animation state
        ThroughObjectBody.AddForce(Vector2.down*2000f);//modify busket velocity
    }
}
