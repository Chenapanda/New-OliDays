using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour {
    public int level;
    public GameObject player;
    public GameObject StageGeneration;
	// Use this for initialization
	void Start () {
        StageGeneration = GameObject.FindGameObjectWithTag("Stage");
        level = StageGeneration.GetComponent<StageGeneration>().difficulty;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GoToNextLevel();
            StageGeneration.GetComponent<StageGeneration>().difficulty += 1;
            StageGeneration.GetComponent<StageGeneration>().roomObj = null;
        }
    }
    public void GoToNextLevel()
    {
        DestroyAllGameObjects();
        StageGeneration.GetComponent<StageGeneration>().occupiedPos = new List<Vector2>();
        StageGeneration.GetComponent<StageGeneration>().boss = false;
        StageGeneration.GetComponent<StageGeneration>().powerup = false;
        StageGeneration.GetComponent<StageGeneration>().CreateRooms();
        StageGeneration.GetComponent<StageGeneration>().SetRoomDoors();
        StageGeneration.GetComponent<StageGeneration>().DrawMap();
        player.transform.position = new Vector3(0, 3f, 0);
    }

    public void DestroyAllGameObjects()
    {
        GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);

        for (int i = 0; i < GameObjects.Length; i++)
        {
            if (GameObjects[i].tag != "Player" && GameObjects[i].tag != "MainCamera" && GameObjects[i].tag != "Script" && GameObjects[i].tag != "Stage" && GameObjects[i].tag != "HUD")
            {
                Destroy(GameObjects[i]);
            }
        }
    }
}
