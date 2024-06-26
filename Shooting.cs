﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shooting : MonoBehaviour
{





    public float damgae = 10f;

    public float range = 100f;

    public float fireRate = 100f;



    public Camera fpsCam;

    public ParticleSystem muzzleFlash;

    public GameObject impactEffect;

    public float impactforce = 30;



    private float nextTimeToFire = 0f;



    void Update()

    {



        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)

        {

            nextTimeToFire = Time.time + 1f / fireRate;

            Shoot();

        }

    }



    void Shoot()

    {

        muzzleFlash.Play();

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))

        {

            Debug.Log(hit.transform.name);



            target target = hit.transform.GetComponent<target>();

            if (target != null)

            {

                target.TakeDamage(damgae);



            }



            if (hit.rigidbody != null)

            {

                hit.rigidbody.AddForce(-hit.normal * impactforce);

            }



            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            Destroy(impactGo, 2f);

        }

    }



}
