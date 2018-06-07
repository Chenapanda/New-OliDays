using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour {
    public float destroyTime = 3f;
    public Vector3 randomiozer = new Vector3(.5f, 0, 0);
	// Use this for initialization
	void Start () {
        Destroy(gameObject, destroyTime);
        transform.localPosition += new Vector3(Random.Range(-randomiozer.x, randomiozer.x),
            Random.Range(-randomiozer.y, randomiozer.y),
            Random.Range(-randomiozer.z, randomiozer.z));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
