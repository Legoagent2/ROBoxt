using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Lever : Interactable
{
    bool BlockMoved = false;
    public bool playerInside;
    [SerializeField]
    GameObject Movingblocks1;

    private void OnTriggerStay(Collider other)
    {
        playerInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerInside = false;
    }

    public override void DoInteraction()
    {
        if (playerInside)
        {
            BlockMoved = !BlockMoved;

            if(BlockMoved)
            {
                Movingblocks1.transform.position += new Vector3(1, 0, 0);
            }
            else
            {
                Movingblocks1.transform.position += new Vector3(-1, 0, 0);
            }
        }
    }
}