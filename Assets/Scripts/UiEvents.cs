using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiEvents : MonoBehaviour {

    public static UiEvents uiEvents;

    public GameObject StartUi; //landing ui
    public PoolController Pool; //reference of the poolcontroller script sttached with the pool gameobject
    public GameObject GenomeSelectUi; //reference to the genome selection dialog
    public SpriteRenderer Genome;//spriterenderer component of throughable genome
    public Sprite[] GenomeSprites;//sprites of gemone
    public GameObject GameUi;//reference to the game ui
    //public GameObject GameOverUi; //gameover screen

    // Use this for initialization
    void Start () {
        uiEvents = this;
	}


    public void PlayButtonPressAction() //play button start game play
    {
        StartUi.SetActive(false);//close the start ui
        Pool.enabled = true;//active the poolcontroller script
        GenomeSelectUi.SetActive(true);//make genome selection dialog visible

    }

    public void ChooseGenome(int index) //select the genome
    {
        Genome.sprite = GenomeSprites[index];
    }



    public void GameOver()//draws the gameover screen
    {
        // GameOverUi.SetActive(true);
        GameUi.GetComponent<Animator>().SetTrigger("Switch");
    }

    public void RetryButtonPressEvent() //reload the game scene
    {

        //CameraFollow.Follow = false; //deactivate the camera follow
        SceneManager.LoadScene(0);
    }


}
