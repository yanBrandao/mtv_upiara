using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoToSelectLevel(){

	}
	public void exit(){
		Application.Quit();
	}
	public void PlayGame(){
		Application.LoadLevel("GamePlay");
	}
}
