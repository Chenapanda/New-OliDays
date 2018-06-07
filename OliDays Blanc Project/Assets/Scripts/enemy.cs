using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class enemy : MonoBehaviour {   
	private NavMeshAgent navAgent;
    private Collider[] withinAggroColliders;
    private Player player;
                                    
                                    
    public LayerMask aggroLayerMask;

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
	void Start ()
	{
	    navAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    withinAggroColliders = Physics.OverlapSphere(transform.position, 2f, aggroLayerMask);
	    if (withinAggroColliders.Length > 0)
	    {
	        ChasePlayer(withinAggroColliders[0].GetComponent<Player>());
	    }
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


	public void PerformAttack()
	{
		player.TakeDamage(1);
	}

	public void TakeDamage(int amount)
	{
		Health -= amount;
		if (Health <= 0)
			Destroy(gameObject);
	}

	void ChasePlayer(Player player)
	{
		this.player = player;
		navAgent.SetDestination(player.transform.position);
	}

    public void ShowFloatingText()
    {
        var go = Instantiate(textPrefab, transform.position, textPrefab.transform.rotation, transform);
        go.GetComponent<TextMesh>().text = health.ToString();
    }

}
