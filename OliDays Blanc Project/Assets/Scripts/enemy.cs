using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
    public GameObject textPrefab;
    public GameObject dream;
    public GameObject dreamA;
    public Rigidbody self;
    public int type; //type0 =enemy normal type1 = boss
    public float health;
    public int loot;
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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ishit(float dmg)
    {
        Health -= dmg;
        ShowFloatingText();
        if (Health <= 0)
        {
            if (Random.Range(0, 100) < loot)
            {
                Instantiate(dream, transform.position, new Quaternion(0, 0, 0, 0));
                Instantiate(dreamA, transform.position + new Vector3(0, .5f, 0), dreamA.transform.rotation);
            }
            Destroy(gameObject);
        }
    }
    public void ShowFloatingText()
    {
        var go = Instantiate(textPrefab, transform.position, textPrefab.transform.rotation, transform);
        go.GetComponent<TextMesh>().text = health.ToString();
    }
}
