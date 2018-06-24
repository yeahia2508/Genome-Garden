using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    public Text ScoreView;//reference to the score text
    public Text HighScoreView;//reference to the hoghscore text
    

	// Use this for initialization
	void Start () {
        ScoreView.text =Mathf.Round(PlayerController.playerController.Distance).ToString(); //set the score view
        HighScoreView.text = Mathf.Round(PlayerPrefs.GetFloat("HighScore")).ToString(); // set the highscore view
    }
	
	// Update is called 
	void Update () {

        ScoreView.text = Mathf.Round(PlayerController.playerController.Distance).ToString(); //update the score view
    }
}
