using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

	public GameObject GameOverUI;
	public PlayerMovement player;
	public GameObject playerbody;

	public void Restart()
	{
		SceneManager.LoadScene("Main", LoadSceneMode.Single);
	}
	// Use this for initialization
	void Start () {
		playerbody = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (playerbody.active == false)
		{
			GameOverUI.SetActive(true);
		}
	}
}
