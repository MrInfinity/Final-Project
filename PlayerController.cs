﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
     public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
     public static float speed = 10f;
     public float tilt;
     public Boundary boundary;

     public GameObject shot;
     public Transform shotSpawn;
     public static float fireRate = .25f;

     public float nextFire;

     private Rigidbody rb;
     private AudioSource audioSource;

     void Update ()
     {
         if (Input.GetButton("Fire1") && Time.time > nextFire)
         {
             nextFire = Time.time + fireRate;
             Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
             audioSource.Play();
         }
     }

     private void Start()
     {
          rb = GetComponent<Rigidbody>();
          audioSource = GetComponent<AudioSource>();
     }

     void FixedUpdate()
     {
          float moveHorizontal = Input.GetAxis("Horizontal");
          float moveVertical = Input.GetAxis("Vertical");

          Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
          rb.velocity = movement * speed;

          rb.position = new Vector3
          (
               Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
               0.0f,
               Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
          );

          rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
     }
}