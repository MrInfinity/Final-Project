using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupController : MonoBehaviour
{

    private GameController gameController;

    

    void Start ()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag ("Player"))
        { 
            PlayerController.fireRate = .1f;
            PlayerController.speed = 15f;
            Destroy(gameObject);

        }
    }
}
