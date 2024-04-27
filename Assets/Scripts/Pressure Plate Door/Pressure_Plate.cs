using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure_Plate : MonoBehaviour
{
    [SerializeField]
    GameObject Cube;
    bool isOpened = false;

    void OnTriggerEnter(Collider col)
    {
        if (isOpened == false)
        {
            isOpened = true;
            Cube.transform.position += new Vector3(0, 0, -2);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (isOpened != false)
        {
            isOpened = false;
            Cube.transform.position -= new Vector3(0, 0, -2);
        }
    }
}
