using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class enemy : MonoBehaviour {   
    public NavMeshAgent agent;
    private Collider[] withinAggroColliders;
    private PlayerMovement player;

	private float lastPatate = 0f, timeBetweenPatate = 2f;
	private bool canhit;
	private bool isAttacking;
	
	public string IDLE	= "Anim_Idle";
	public string ATTACK	= "Anim_Attack";
	public string DAMAGE	= "Anim_Damage";
	public string DEATH	= "Anim_Death";

	public Animation anim;


	public Animator animator;
	public Collision col;
	public GameObject playerbody;
    public Vector3 roomPos;
    public int range = 4;
    public Transform playertransform;
    public float speed = 0.04f;
    public LayerMask aggroLayerMask;
    public GameObject textPrefab;
    public GameObject dream;
    public GameObject dreamA;
    public Rigidbody self;
    public int type; //type0 =enemy normal type1 = boss
    public float health;
    public int loot;
	public float distanceCac = 0.001f;
    public GameObject StageGeneration;
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
        StageGeneration = GameObject.FindGameObjectWithTag("Stage");
		playertransform = GameObject.FindGameObjectWithTag("Player").transform;
		playerbody = GameObject.FindGameObjectWithTag("Player");
		agent.GetComponent<NavMeshAgent>();
		if (animator != null)
		{
			animator.GetComponent<Animator>();
		}

        if (type == 0)
        {
            health += StageGeneration.GetComponent<StageGeneration>().difficulty * 10 ;
        }
        if (type == 1)
        {
            health += StageGeneration.GetComponent<StageGeneration>().difficulty * 50;
        }
    }


	void Update(){
        if (transform != null)
        {
            bool shouldchase = ((roomPos.x - 0.5f < playertransform.position.x) && (playertransform.position.x < roomPos.x + 8f)) && ((roomPos.z - 0.5f < playertransform.position.z) && (playertransform.position.z < roomPos.z + 8f));
            if (shouldchase && !isAttacking)
            {
            	agent.SetDestination(playertransform.position);
	            anim.Play(IDLE);
	        	animator.Play("Move");
            }
        }
    }
	
	
    public void ishit(float dmg)
    {
        Health -= dmg;
        playerbody.GetComponent<PlayerMovement>().score += 5;
        ShowFloatingText();
        if (Health <= 0)
        {
            if (Random.Range(0, 100) < loot)
            {
                Instantiate(dream, transform.position, new Quaternion(0, 0, 0, 0));
                Instantiate(dreamA, transform.position + new Vector3(0, .5f, 0), dreamA.transform.rotation);
            }
            if (type == 0)
            {
                playerbody.GetComponent<PlayerMovement>().score += 100;
            }
            if (type == 1)
            {
                playerbody.GetComponent<PlayerMovement>().score += 2000;
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
	
	 IEnumerator OnCollisionEnter(Collision col)
	 {
		 isAttacking = true;
		 if (col.gameObject.tag == "Player") 
		 {
			 if (type == 1)
			 {
				 anim.Play(ATTACK);
			 }
			 else
			 {
				 animator.Play("Attack", -1);
			 }
			Debug.Log("Damages dealt");
			playerbody.GetComponent<PlayerMovement>().TakeDamage(1);

		 }
		 yield return new WaitForSeconds(1);
		 agent.destination = playertransform.position;
		 isAttacking = false;
	 }
}
