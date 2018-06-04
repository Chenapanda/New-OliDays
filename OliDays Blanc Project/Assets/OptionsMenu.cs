﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;

public class OptionsMenu : MonoBehaviour
{

	
	public Dropdown textureQualityDropdown;
	public Slider musicVolumeSlider;
	
	
	public GameSettings gameSettings;
	public AudioSource musicSource;

	public void FullScreen(bool isFullScreen)
	{
		Screen.fullScreen = isFullScreen;
	}

	void OnEnable()
	{
		gameSettings = new GameSettings();
		textureQualityDropdown.onValueChanged.AddListener(delegate { OnTexttureQualityChange(); });
		musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
	
	}

	public void OnMusicVolumeChange()
	{
		musicSource.volume = gameSettings.musicVolume = musicVolumeSlider.value;
	}
	
	public void OnTexttureQualityChange()
	{
		QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;
	}

}