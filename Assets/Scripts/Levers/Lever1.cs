using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Lever1 : MonoBehaviour
{
    bool blockMoved = false;
    bool inCube;
    [SerializeField]
    GameObject Movingblocks1;

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
