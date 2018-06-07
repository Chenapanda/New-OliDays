using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class enemy : MonoBehaviour {   
	private NavMeshAgent navAgent;
    private Collider[] withinAggroColliders;
    private PlayerMovement player;
	public Transform playertransform;
                                    
                                    
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

	private void Start()
	{
		playertransform = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update(){
		if (Vector3.Distance(playertransform.position, this.transform.position) < 2)
		{
			Vector3 direction = playertransform.position - this.transform.position;
			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 1f);

			if (direction.magnitude > 0.75f)
			{
				this.transform.Translate(0,0,0.05f);
			}
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


	/*public void PerformAttack()
	{
		player.TakeDamage(1);
	}

	public void TakeDamage(int amount)
	{
		Health -= amount;
		if (Health <= 0)
			Destroy(gameObject);
	}

	void ChasePlayer(PlayerMovement player)
	{
		this.player = player;
		navAgent.SetDestination(player.transform.position);

	}*/

    public void ShowFloatingText()
    {
        var go = Instantiate(textPrefab, transform.position, textPrefab.transform.rotation, transform);
        go.GetComponent<TextMesh>().text = health.ToString();
    }

}
