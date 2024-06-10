using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class L2_Lever1 : MonoBehaviour
{
    //All the variables set for the script
    bool blockMoved = false;
    bool inCube;
    [SerializeField]
    GameObject Movingblocks1;

    //Detects when the player has entered the lever collider
    private void OnTriggerEnter(Collider other)
    {
        inCube = true;
    }

    //Detects when the player has left the lever collider
    private void OnTriggerExit(Collider other)
    {
        inCube = false;
    }

    // Checks every frame to see if the player is trying to use the lever or not and moves the transform values
    void Update()
    {
        if(inCube)
        {
            if(blockMoved)
            {
                if(Input.GetKeyDown(KeyCode.F) && inCube)
                {
                    Movingblocks1.transform.position += new Vector3(-1, 0, 0);
                    blockMoved = false;


                }
            }
            else
            {
                if(Input.GetKeyDown(KeyCode.F) && inCube)
                {
                    Movingblocks1.transform.position += new Vector3(1, 0, 0);
                    blockMoved = true;
                }
            }
        }
    }
}