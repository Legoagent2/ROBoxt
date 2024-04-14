using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{

    public Transform chController;
    bool inside = false;
    public float speedUpDown = 3.2f;
    public Movement SCInput;

    void Start()
    {
        SCInput = GetComponent<Movement>();
        inside = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            SCInput.enabled = false;
            inside = !inside;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Ladder")
        {
            SCInput.enabled = true;
            inside = !inside;
        }
    }
    void Update()
    {
        if(inside == true && Input.GetKey("w"))
        {
            chController.transform.position += Vector3.up / speedUpDown;
        }
        if(inside == true && Input.GetKey("s"))
        {
            chController.transform.position += Vector3.down / speedUpDown;
        }
    }
}
