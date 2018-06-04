using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

	public AudioMixer volumeMixer;
	
	Resolution[] resolutions;

	public Dropdown resolutionsDropdown;
	
	public void Volume(float volume)
	{
		volumeMixer.SetFloat("volume", volume);
	}

	public void FullScreen(bool isFullScreen)
	{
		Screen.fullScreen = isFullScreen;
	}
}