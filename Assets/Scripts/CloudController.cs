using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour {

    private SpriteRenderer SelfRenderer;//self sprite renderer component

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Cloud");
        collision.GetComponent<Rigidbody2D>().AddForce(Vector2.one * 500f); //increase the bottole spedd to x axis
    }


    // Use this for initialization
    void Start () {
        SelfRenderer = GetComponent<SpriteRenderer>(); //assign self spriterenderer component

    }

    private void OnBecameInvisible()
    {
       // Destroy(gameObject);
        transform.position += Vector3.right * 35f;
    }

    // Update is called once per frame
    void Update () {
        

        
		
	}
}
