using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectorPositionar : MonoBehaviour {

	void Start () {
        float displacement = Random.Range(0, 2f);//random displacement
        transform.position += Vector3.right * displacement;//displace with random value
        
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x <= Camera.main.transform.position.x - 10f)
        {
            float displacement = Random.Range(25, 100f);//random displacement
            transform.position += Vector3.right * displacement;//displace with random value

        }


    }
}
