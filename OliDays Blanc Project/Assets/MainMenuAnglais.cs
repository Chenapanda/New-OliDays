using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuAnglais : MonoBehaviour {
	
	
	public void Jouer()
	{
		SceneManager.LoadScene("MainAnglais", LoadSceneMode.Single);
	}

	public void Quitter()
	{
		Debug.Log("Quitter");
		Application.Quit();
	}

}
