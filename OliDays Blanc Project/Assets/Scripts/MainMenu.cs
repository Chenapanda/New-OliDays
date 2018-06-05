using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

	public void Jouer()
	{
		SceneManager.LoadScene("Main", LoadSceneMode.Single);
	}
	public void Quitter()
	{
		Debug.Log("Quitter");
		Application.Quit();
	}

}
