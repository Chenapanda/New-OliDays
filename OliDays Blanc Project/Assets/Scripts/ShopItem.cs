using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : PowerUp {
    public PowerUp powerup;
    public int cost;
    public int costUp = 2;
    public GameObject text;
    private GameObject go;
    //public float offset = 9f;

    private void Start()
    {
        go = Instantiate(text, transform.position + text.transform.position, text.transform.rotation, transform);
    }

    private void Update()
    {
        go.GetComponent<TextMesh>().text = cost.ToString() + "D";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (cost <= other.GetComponent<PlayerMovement>().Dreams)
            {
                Power(other);
                other.GetComponent<PlayerMovement>().Dreams -= cost;
                cost += costUp;
            }
        }

    }
}
