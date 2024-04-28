using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Lever : MonoBehaviour
{
    [SerializeField]
    GameObject Movingblock;
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
                Movingblock.transform.position = new Vector3(-2, -11, 5);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
                Movingblock.transform.position = new Vector3(-3, -11, 5);
        }
    }
}