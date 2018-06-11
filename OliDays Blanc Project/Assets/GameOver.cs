using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

	public GameObject GameOverUI;
	public GameObject playerbody;

	private StageGeneration stage;

	public void Restart()
	{
		Debug.Log("ON REDEMARRE BABY STILL NOT DEAD");
	}
	// Use this for initialization
	void Start ()
	{
		playerbody = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (playerbody.GetComponent<PlayerMovement>().Health == 0f)
		{
			Time.timeScale = 0f;
			GameOverUI.SetActive(true);
			Destroy(playerbody);
		}
	}
}
