using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trank : MonoBehaviour {

    private Rigidbody2D PlayerBody;//rigidbody of player tagged object
    private SpriteRenderer PlayerRenderer;//sprite renderer of player object

    private void OnTriggerEnter2D(Collider2D collision)//when other colliders enter into my collider
    {
        if (collision.CompareTag("Player"))//when collider with Player tag enter into my collider
        {
            if (PlayerController.GameOver)
                return;//stop trank function if game is over

            PlayerBody = collision.GetComponent<Rigidbody2D>();//get the reference
            PlayerRenderer = collision.GetComponent<SpriteRenderer>();//get the reference
            PlayerBody.velocity = Vector2.zero;//clear player velocity
            PlayerRenderer.enabled = false;//hide the player
            PlayerController.isBlocked = true;//say the playercontroller that, player is blocked now
            Invoke("ThroughPlayer", 1f);//wait 1 sec then through player
        }
    }





    public void ThroughPlayer()//through the player
    {
        if (PlayerController.GameOver)
            return; //do not jump if game over

        PlayerRenderer.enabled = true;//show the player
        PlayerBody.AddForce(new Vector2(1000f,1750f));//through the player
        PlayerController.isBlocked = false;//say the playercontroller that, player is not blocked now
    }





}
