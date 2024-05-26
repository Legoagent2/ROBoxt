using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L6Pressure_Plate4 : MonoBehaviour
{
    //Sets the variables for the script
    [SerializeField]
    GameObject Cube;
    bool isOpened = false;

    //Detects when the player enters the collider
    void OnTriggerEnter(Collider col)
    {
        if (isOpened == false)
        {
            isOpened = true;
            Cube.transform.position += new Vector3(0, 0, -1);
        }
    }

    //Detects when the player leaves the collider
    private void OnTriggerExit(Collider col)
    {
        if (isOpened != false)
        {
            isOpened = false;
            Cube.transform.position -= new Vector3(0, 0, -1);
        }
    }
}