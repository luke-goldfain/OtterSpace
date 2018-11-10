using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSpeed : MonoBehaviour {

    public float speed = 10f;
    public float LifeTime = 2;
    public float Damage = 20;
    public bool Destroythis;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(speed * Time.deltaTime, 0, 0);
        LifeTime -= Time.deltaTime;

        if (LifeTime <= 0 && !Destroythis)
        {

            Object.Destroy(this.gameObject);



        }

    }
}
