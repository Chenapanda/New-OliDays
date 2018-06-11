using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject GameOverUI;
    public GameObject self;
    public Rigidbody player;
    public int speed;
    public float maxSpeed;
    public Texture2D Staff;
    public Texture2D Hp;
    private float health = 3f;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
    private float dammage = 5f;
    public float Dammage
    {
        get
        {
            return dammage;
        }
        set
        {
            dammage = value;
        }
    }


    private int dreams = 0;
    public int Dreams
    {
        get
        {
            return dreams;
        }
        set
        {
            dreams = value;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        if (Input.GetKey("d"))
        {
            player.AddForce(speed * 10, 0, 0);
            //transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("z"))
        {

            player.AddForce(0, 0, speed * 10);
            //transform.Translate(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey("q"))
        {
            player.AddForce(-speed * 10, 0, 0);
            //transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            player.AddForce(0, 0, -speed * 10);
            //transform.Translate(0, 0, -speed * Time.deltaTime);
        }
        
        if (player.velocity.x > maxSpeed)
        {
            player.velocity = new Vector3(maxSpeed, player.velocity.y, player.velocity.z);
        }
        if (player.velocity.x < -maxSpeed)
        {
            player.velocity = new Vector3(-maxSpeed, player.velocity.y, player.velocity.z);
        }
        if (player.velocity.z > maxSpeed)
        {
            player.velocity = new Vector3(player.velocity.x, player.velocity.y, maxSpeed);
        }
        if (player.velocity.z < -maxSpeed)
        {
            player.velocity = new Vector3(player.velocity.x, player.velocity.y, -maxSpeed);
        }
    }

    private void OnGUI()
    {
        for (int i = 0; i < Health; i++)
        {
            Rect posHealth = new Rect(20 + 20 * i, 50, 40, 40);
            GUI.Label(posHealth, Hp);
        }
        //displays dreams
        GUI.contentColor = Color.magenta;
        GUI.Label(new Rect(20, 20, 100, 20), "Dreams : " + Dreams);
        //displays dammage
        Rect posDammage = new Rect(20, 90, 40, 40);
        GUI.Label(posDammage, Staff);
        Rect posDammage2 = new Rect(70, 100, 70, 70);
        GUI.Label(posDammage2, dammage.ToString());
    }
    
    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0)
            Die();
    }
    
    private void Die()
    {
        Debug.Log("Player dead. Reset health.");
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        Destroy(self);
        // Destroy(gameObject);
        //this.Health = 3f;
    }

}
