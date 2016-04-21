using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/* 
 * Source file name: Youtube Video (COMP305 - W2016 - )
Author's name: Fatimah 
Last Modified by: Fatimah Alhashim
Date last Modified: April10th, 2016
Program Description: Simple 2d game platformer where you can collect coins when you go over the platForm
*/
public class MenuController : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//handler for startbutton

	public void StartButtonClick (){
		SceneManager.LoadScene ("Level1");
	}
	public void InstructionsButtonClick (){
		SceneManager.LoadScene ("Instructions");
	}
	public void QuitButtonClick(){
		Application.Quit ();
	}
	
}
