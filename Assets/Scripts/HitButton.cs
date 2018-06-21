using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitButton : MonoBehaviour {

    public Rigidbody2D ThroughObjectBody;//reference to the player rigirbody2d


    public void HitButtonPressEvent()
    {
        GetComponent<Animator>().SetTrigger("Switch");
        ThroughObjectBody.AddForce(Vector2.down*2000f);//modify busket velocity
    }
}
