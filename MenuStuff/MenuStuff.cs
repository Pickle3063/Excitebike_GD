using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuStuff : MonoBehaviour {

    public Sprite StartMenu1;
    public Sprite StartMenu2;
    public Sprite StartMenu3;
    public Sprite StartMenuNull;

    public Sprite SoloMenu1;
    public Sprite SoloMenu2;
    public Sprite SoloMenu3;
    public Sprite SoloMenu4;
    public Sprite SoloMenu5;
    public Sprite SoloMenuNull;

    public Sprite DesignMenu1;
    public Sprite DesignMenu2;
    public Sprite DesignMenu3;
    public Sprite DesignMenu4;
    public Sprite DesignMenu5;
    public Sprite DesignMenu6;

    public AudioClip[] TitleTrack = new AudioClip[4];
    public AudioClip BeepSelect;
    public AudioClip RaceIntro;


    //This Script is for storing Menu Sprites.
	
	void Start () {
        //GameObject.Find("MenuImage").GetComponent<Image>().sprite = StartMenuNull;

    }
	
	
	void Update () {
		
	}
}
