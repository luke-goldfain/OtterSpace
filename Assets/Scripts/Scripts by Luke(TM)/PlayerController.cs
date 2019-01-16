using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float offset = 0.0f;
    public float pSpeed = 5.0f;
    public bool FollowMouse;
    public GameObject pShot;
    public Transform pShotSpawn;
    public float pFireRate = 2;
    public float pShotDelay = 10;
    //public float fireRate = 1;


    private float pNextFire;

    // Use this for initialization
    void Start()
    {

        InvokeRepeating("Fire", pShotDelay, pFireRate);

    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, pSpeed * Time.deltaTime, 0, Space.World);

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(pSpeed * Time.deltaTime, 0, 0, Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-pSpeed * Time.deltaTime, 0, 0, Space.World);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -pSpeed * Time.deltaTime, 0, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            pNextFire = Time.time + pFireRate;
            GameObject NewShot = Instantiate(pShot, pShotSpawn.position, pShotSpawn.rotation);
            NewShot.GetComponent<ShotSpeed>().Destroythis = false;
            NewShot.GetComponent<ShotSpeed>().speed = 10f;
            NewShot.GetComponent<ShotSpeed>().LifeTime = 2f;
            NewShot.GetComponent<ShotSpeed>().Damage = 20f;

            GetComponent<AudioSource>().Play();


        }

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
    }
}
