﻿using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour
{

   
    public GameObject ProjectileObject;
    public Transform SpawnPosition;

    public float Delay = 0.2f;
    public float CooldownTime = 1f;
    public int burst = 1;
    public float burstCooldownIncrease = 0;
    private int shotCount;
    private GameObject LastFiredProjectile;

    private bool CanShoot;

    public float leftOrRight;

    // Use this for initialization
    void Start()
    {
        CanShoot = true;
    }

    //Runs every frame
    void Update()
    {

        leftOrRight = -90f;

        if (CanShoot)
        {
            //Now start a coroutine that will wait before firing.
            shotCount++;

            StartCoroutine(WaitAndFire(Delay));
            CanShoot = false;
            if (shotCount % burst == (burst - 1))
            {
                CooldownTime += burstCooldownIncrease;
            }
            if (shotCount % burst == 0)
            {
                CooldownTime -= burstCooldownIncrease;
            }
            StartCoroutine(CoolDown(CooldownTime));
        }
    }

    IEnumerator WaitAndFire(float waitTime)
    {
        //Pre-Fire ffects here, sound ques etc.
        yield return new WaitForSeconds(waitTime);
        Vector3 spawnPos = Vector3.zero;

        spawnPos = SpawnPosition.position;

        //Instantiate mustache on our spawn position.

        LastFiredProjectile = GameObject.Instantiate(ProjectileObject, spawnPos, Quaternion.AngleAxis(leftOrRight, Vector3.up)) as GameObject;

        //Using other script to fire our stache.
        LastFiredProjectile.GetComponent<ScriptProjectile>().Initialize();
    }

    //Stops the player from spamming shots.
    IEnumerator CoolDown(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        CanShoot = true;
    }
}
