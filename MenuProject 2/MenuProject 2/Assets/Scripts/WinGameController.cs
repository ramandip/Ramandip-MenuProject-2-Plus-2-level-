using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 
 * Source file name: Youtube Video (COMP305 - W2016 - )
Author's name: Fatimah 
Last Modified by: Fatimah Alhashim
Date last Modified: April10th, 2016
Program Description: Simple 2d game platformer where you can collect coins when you go over the platForm
*/
public class WinGameController : MonoBehaviour {


		//private variables
		private int scoreValue; 
		private int livesValue; 



		//access methods 
		public int ScoreValue {
			get { 
				return scoreValue;
			}
			set { 
				scoreValue = value; 
				//ScoreLabel.text = "Score: " + scoreValue;
			}
		}
	/*	public int LivesValue {
			get { 
				return livesValue;
			}
			set { 
				livesValue = value; 
				if (livesValue <= 0) {
					endGame ();
				} else {
					LivesLabel.text = "Lives " + LivesValue;
				}
			}
*/
		

		//public variables 


		//public Text LivesLabel; 
		//public Text ScoreLabel;
		//public Text GameOverLabel;
		public Text HighScoreLabel;
		//public Button RestartButton;
		public Button BackButton;

		// Use this for intialization 
		void Start (){
			initialize ();
		}
		private void initialize(){
			ScoreValue = 0; 
		//	LivesValue = 5; 
		//	GameOverLabel.gameObject.SetActive (false); 
			HighScoreLabel.gameObject.SetActive (false);
		//	RestartButton.gameObject.SetActive (false);
			BackButton.gameObject.SetActive (false);

		}
		//private methodes
		private void endGame(){
		//	GameOverLabel.gameObject.SetActive(true);
		//	LivesLabel.gameObject.SetActive(false); 
		//	ScoreLabel.gameObject.SetActive(false); 
			HighScoreLabel.gameObject.SetActive(true); 
		//	RestartButton.gameObject.SetActive(true); 
			BackButton.gameObject.SetActive (true);
			HighScoreLabel.text = "High Score:" + scoreValue;
		}

		// public methods 
	//	public void RestartButtonClick(){
	//		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	//	}
		public void BackButtonClick (){
			SceneManager.LoadScene ("Menu");
		}
	}
