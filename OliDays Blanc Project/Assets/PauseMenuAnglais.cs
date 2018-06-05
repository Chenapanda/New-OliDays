using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuAnglais : MonoBehaviour
{

	public static bool GameIsPaused = false;

	public GameObject PauseMenuAnglaisUi;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (GameIsPaused)
			{
				Resume();
			}

			else
			{
				Pause();
			}
		}
	}

	public void Resume()
	{
		PauseMenuAnglaisUi.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	void Pause()
	{
		PauseMenuAnglaisUi.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void LoadMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("MenuAnglais");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}