using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

	public GameObject GameOverUI;

	private StageGeneration stage;

	public void Restart()
	{
		Debug.Log("ON REDEMARRE BABY STILL NOT DEAD");
	}
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<PlayerMovement>().Health == 0)
		{
			GameOverUI.SetActive(true);
		}
	}
}
