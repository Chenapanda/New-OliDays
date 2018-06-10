using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : PowerUp {
    public PowerUp powerup;
    public int cost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (cost <= other.GetComponent<PlayerMovement>().Dreams)
            {
                Power(other);
                other.GetComponent<PlayerMovement>().Dreams -= cost;
            }
        }

    }
}
