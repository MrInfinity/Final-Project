using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;
//using System.Threading;

public class BGScroller : MonoBehaviour
{

    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;  
    }

    void FixedUpdate()
    {
        float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;


    
        if (GameController.score >= GameController.scoreToWin ) 
        {
            while (scrollSpeed > -10.0f) {
                scrollSpeed = scrollSpeed - .1f;
            }   
        }
    }
}
