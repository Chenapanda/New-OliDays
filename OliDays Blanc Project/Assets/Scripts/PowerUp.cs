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
            if (type == 1)
            {
                other.GetComponent<PlayerMovement>().Dammage += bonus;
            }
            if (type == 2)
            {
                other.GetComponent<PlayerMovement>().Health += bonus;
            }
            Instantiate(pickupEffect, transform.position + new Vector3(0, .5f, 0), pickupEffect.transform.rotation);
            Destroy(gameObject);

        }
    }
}
