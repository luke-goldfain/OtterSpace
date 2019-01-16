using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public float offset = 0.0f ;
    public float speed = 10.0f;
    public bool FollowMouse;
    public GameObject shot;
    public Transform shotSpawn;
    public float FireRate = 2;
    public float delay = 10;
    public float fireRate = 1;
   

    private float nextFire;

    // Use this for initialization
    void Start () {

        InvokeRepeating("Fire", delay, FireRate);

    }

// Update is called once per frame
void Update () {



        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
          
               nextFire = Time.time + fireRate;
               GameObject NewShot = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
               NewShot.GetComponent<ShotSpeed>().Destroythis = false;
               NewShot.GetComponent<ShotSpeed>().speed = 10f;
               NewShot.GetComponent<ShotSpeed>().LifeTime = 2f;
               NewShot.GetComponent<ShotSpeed>().Damage = 20f;
               
               GetComponent<AudioSource>().Play();


        }

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;

        difference.Normalize();

        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
    }
}
