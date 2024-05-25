using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Lever2 : MonoBehaviour
{
    bool blockMoved = false;
    bool inCube;
    [SerializeField]
    GameObject Movingblocks2;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Inside");
        inCube = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Outside");
        inCube = false;
    }
    void Update()
    {
        if (inCube)
        {
            if (blockMoved)
            {
                if (Input.GetKeyDown(KeyCode.F) && inCube)
                {
                    Movingblocks2.transform.position += new Vector3(0, 0, 1);
                    blockMoved = false;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.F) && inCube)
                {
                    Movingblocks2.transform.position += new Vector3(0, 0, -1);
                    blockMoved = true;
                }
            }
        }
    }
}