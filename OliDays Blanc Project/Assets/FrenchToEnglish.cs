using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FrenchToEnglish : MonoBehaviour
{
	//Make sure to attach these Buttons in the Inspector
	public Button langue;

	void Start()
	{
		Button btn = langue.GetComponent<Button>();

		//Calls the TaskOnClick method when you click the Button
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		//Output this to console when the Button is clicked
		SceneManager.LoadScene("MenuAnglais", LoadSceneMode.Single);
	}
}
