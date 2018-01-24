using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine;

//"Script by Brian Dang"

public class MenuStuff : MonoBehaviour {

    public Sprite StartMenu1; // Sprites for Title Menu
    public Sprite StartMenu2;
    public Sprite StartMenu3;
    public Sprite StartMenuNull;

    public Sprite SoloMenu1; // Sprites for Track Selection
    public Sprite SoloMenu2;
    public Sprite SoloMenu3;
    public Sprite SoloMenu4;
    public Sprite SoloMenu5;
    public Sprite SoloMenuNull;

    public Sprite DesignMenu1; // Sprites for Design Menu
    public Sprite DesignMenu2;
    public Sprite DesignMenu3;
    public Sprite DesignMenu4;
    public Sprite DesignMenu5;
    public Sprite DesignMenu6;

    public Sprite ResultScreen; // Sprites for the Result Screen and a Track's Best Time
    public Sprite TrackResult;

    public AudioClip[] TitleTrack = new AudioClip[4]; // Sounds and Music
    public AudioClip BeepSelect;
    public AudioClip RaceIntro;
    public AudioClip ResultSound;
    public AudioClip ErrorSound;

    public Text BestTime; // Text for Times shown in the result screens
    public Text PTime;
    public Text TrackTime;

    //This Script is for storing Menu Sprites.
    //If there is a change needed to the MenuStateMachine, simply add what you need here.
	
	void Start () {

    }
	
	
	void Update () {
		
	}
}
