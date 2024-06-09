using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oreintation : MonoBehaviour
{
    private Transform childTransform;
    private Vector3 leftRotation = new Vector3(0.0f,0.0f,0.0f);
    private Vector3 rightRotation = new Vector3(0.0f,180.0f,0.0f);
    private Vector3 origin = new Vector3(0.0f,-1.0f,0.0f);
    // Start is called before the first frame update
    void Start()
    {
        childTransform = GetComponentInChildren<Transform>();

        if (childTransform == null)
        {
            Debug.LogError("Child object not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetAxis("Horizontal") > 0.0f)
        {
            childTransform.SetLocalPositionAndRotation(origin, Quaternion.Euler(rightRotation));
        }
        else if (UnityEngine.Input.GetAxis("Horizontal") < 0.0f)
        {
            childTransform.SetLocalPositionAndRotation(origin, Quaternion.Euler(leftRotation));
        }
    }
}
