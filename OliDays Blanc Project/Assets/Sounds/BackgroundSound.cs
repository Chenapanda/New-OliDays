using UnityEngine;
using UnityEngine.UI;

public class BackgroundSound : MonoBehaviour
{

	public Slider MenuSlider;
	public AudioSource AudioSource;

	// Use this for initialization
	void Start()
	{

	}



	private static BackgroundSound instance = null;

	public static BackgroundSound Instance
	{
		get { return instance; }
	}

	private void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
			return;
		}
		else
		{
			instance = this;
		}

		DontDestroyOnLoad(this.gameObject);
		AudioSource.volume = MenuSlider.value;
	}

	// Update is called once per frame
	void Update()
	{
		AudioSource.volume = MenuSlider.value;
	}
}