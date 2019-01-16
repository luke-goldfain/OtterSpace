using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameShot : MonoBehaviour {

    public GameObject Shot;
    public Transform shotSpawn;
    public float FireRate;
    public float delay;

	// Use this for initialization
	void Start () {

        InvokeRepeating("Fire", delay, FireRate);
	}
	
	// Update is called once per frame
	void Fire () {

        Instantiate(Shot, shotSpawn.position, shotSpawn.rotation);
            
	}
}
