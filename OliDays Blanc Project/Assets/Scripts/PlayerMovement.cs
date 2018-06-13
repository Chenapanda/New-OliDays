using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject GameOverUI;
    public GameObject self;
    public Rigidbody player;
    public int speed;
    public float maxSpeed;
    public float minSpeed;
    public float startmove = 0.1f;
    public Texture2D Staff;
    public Texture2D Hp;
    public float health = 3f;
    private float lastShot = 0;
    public float timeBetweenShots = .35f;
    public bool canBeHit = true;
    public GameObject HUD;
    public int score = 0;

    private void Start()
    {
        minSpeed = speed;
    }
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

    private void Update()
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
        
        if (player.velocity.x < minSpeed && player.velocity.x > -minSpeed && (player.velocity.x > startmove || player.velocity.x < -startmove))
        {
            if (player.velocity.x == 0)
            {
                player.velocity = new Vector3(0, player.velocity.y, player.velocity.z);
            }
            if (player.velocity.x < 0)
            {
                player.velocity = new Vector3(-minSpeed, player.velocity.y, player.velocity.z);
            }
            if (player.velocity.x > 0)
            {
                player.velocity = new Vector3(minSpeed, player.velocity.y, player.velocity.z);
            }
        }
        if (player.velocity.z < minSpeed && player.velocity.z > -minSpeed && (player.velocity.z > startmove || player.velocity.z < -startmove))
        {
            if (player.velocity.z == 0)
            {
                player.velocity = new Vector3(player.velocity.x, player.velocity.y, 0);
            }
            if (player.velocity.z < 0)
            {
                player.velocity = new Vector3(player.velocity.x, player.velocity.y, -minSpeed);
            }
            if (player.velocity.z > 0)
            {
                player.velocity = new Vector3(player.velocity.x, player.velocity.y, minSpeed);
            }
        }
    }
    /*
    private void OnGUI()
    {
        //displays Health
        for (int i = 0; i < Health; i++)
        {
            Rect posHealth = new Rect(20 + 20 * i, 20, 40, 40);
            GUI.Label(posHealth, Hp);
        }
        //displays Dreams
        GUI.contentColor = Color.magenta;
        GUI.Label(new Rect(20, 90, 100, 20), "Dreams : " + Dreams);
        //displays Dammage
        Rect posDammage = new Rect(20, 50, 40, 40);
        GUI.Label(posDammage, Staff);
        Rect posDammage2 = new Rect(70, 60, 70, 70);
        GUI.Label(posDammage2, dammage.ToString());
        //displays Score
        GUI.Label(new Rect(20, 110, 100, 20), "Score : " + score);
    }
    */
    public void TakeDamage(int amount)
    {
        bool canBeHit = (lastShot + timeBetweenShots < Time.time);
        if (canBeHit)
        {
            Health -= amount;
            if (Health <= 0)
               Die();
            lastShot = Time.time;
        }
        
    }
    
    private void Die()
    {
        Destroy(HUD);
        GameOverUI.SetActive(true);
        Destroy(gameObject);
    }

}
