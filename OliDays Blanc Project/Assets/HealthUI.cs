using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    public int number;
    public RawImage Heart;
    GameObject player;
	// Use this for initialization
	void Start () {
        Heart.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update () {
        if (number <= player.GetComponent<PlayerMovement>().health)
        {
            Heart.enabled = true;
        }
        if (number > player.GetComponent<PlayerMovement>().health)
        {
            Heart.enabled = false;
        }
    }
    public void Diee()
    {
        Heart.enabled = false;
    }
}
