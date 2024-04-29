using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlocks2 : MonoBehaviour
{
    [SerializeField]
    GameObject Movingblock;
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Movingblock.transform.position = new Vector3(0, 0, -1);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Movingblock.transform.position = new Vector3(0, 0, 0);
        }
    }
}