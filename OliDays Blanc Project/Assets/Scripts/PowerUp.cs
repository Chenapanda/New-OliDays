using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    public int bonus;
    public GameObject pickupEffect;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().Dammage += bonus;
            Instantiate(pickupEffect, transform.position + new Vector3(0, .5f, 0), pickupEffect.transform.rotation);
            Destroy(gameObject);

        }
    }
}
