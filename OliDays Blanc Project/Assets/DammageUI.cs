﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DammageUI : MonoBehaviour {

    public Text myText;
    GameObject player;
    public int dividor;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMovement>().Dammage.ToString().Length > dividor)
        {
            myText.text = player.GetComponent<PlayerMovement>().Dammage.ToString()[dividor].ToString();

        }
    }
}
