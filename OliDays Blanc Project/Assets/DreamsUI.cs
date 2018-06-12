using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DreamsUI : MonoBehaviour {
    public Text myText;
    GameObject player;
    public int dividor;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (dividor == 0)
        {
            myText.text = player.GetComponent<PlayerMovement>().Dreams.ToString()[dividor].ToString();
        }
        else
        {
            if (player.GetComponent<PlayerMovement>().Dreams < 10)
            {
                myText.text = "";
            }
            else
            {
                myText.text = player.GetComponent<PlayerMovement>().Dreams.ToString()[dividor].ToString();

            }
        }


    }
}
