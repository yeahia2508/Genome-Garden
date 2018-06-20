using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiEvents : MonoBehaviour {

    public static UiEvents uiEvents;

    public GameObject GameOverUi;

    // Use this for initialization
    void Start () {
        uiEvents = this;
	}

    public void GameOver()//draws the gameover screen
    {
        GameOverUi.SetActive(true);
    }

    public void RetryButtonPressEvent() //reload the game scene
    {

        //CameraFollow.Follow = false; //deactivate the camera follow
        SceneManager.LoadScene(0);
    }


}
