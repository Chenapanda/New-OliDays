using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    public int type; //1 = dammage 2 = hp 3 = attackspeed
    public int bonus;
    public GameObject pickupEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Power(other);
            Destroy(gameObject);

        }
    }

    public void Power(Collider other)
    {
        if (type == 1)
        {
            other.GetComponent<PlayerMovement>().Dammage += bonus;
        }
        if (type == 2)
        {
            other.GetComponent<PlayerMovement>().Health += bonus;
        }
        other.GetComponent<PlayerMovement>().score += bonus * 100;
        Instantiate(pickupEffect, transform.position + new Vector3(0, .5f, 0), pickupEffect.transform.rotation);
    }
}
