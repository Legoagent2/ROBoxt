using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CentrePosition : MonoBehaviour
{

    // NOTE: This script is attached to the player object
    // DO NOT FORGET TO TAG THE SPAWNPOINT BLOCK WITH "Respawn" TAG
    private Rigidbody rb;
    public float smoothTime = 1.2F;
    private Vector3 velocity = Vector3.zero;
    private Vector3 spawnPosition, relativePosition, centredPosition;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // find spawnpoint 
        GameObject spawnpoint = GameObject.FindGameObjectWithTag("Respawn");
        // save its position
        spawnPosition = spawnpoint.transform.position;

        Debug.Log("Spawnpoint position: " + spawnPosition);
    }
    
    void Update()
    {
        // only execute autocentering if no keys are being currently pressed
        if (!Input.anyKey)
        {
            // calculate the player's current position RELATIVE to the spawnpoint
            relativePosition = transform.position - spawnPosition;  
            //  to calculate the new ideal centered WORLD coordinates, round players RELATIVE x and z coordinates to whole numbers, and add them to spawn block's WORLD coordinates,and save it as centredPosition (don't change the y coordinate)
            centredPosition = new Vector3(spawnPosition.x+Mathf.Round(relativePosition.x), transform.position.y, spawnPosition.z+Mathf.Round(relativePosition.z));
            
            // check if the player is not already at the centred position
            if (centredPosition != transform.position)
            {       
               CentrePlayer();
            }
        }   
    }   
    void CentrePlayer()
    {
        // Smoothly move the player towards that target position feeding calculated centrePosition to "SmoothDamp" (it's magic!)
        transform.position = Vector3.SmoothDamp(transform.position, centredPosition, ref velocity, smoothTime);
    }

}
