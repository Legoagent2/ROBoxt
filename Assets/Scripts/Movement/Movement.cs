using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Windows;

public class Movement : MonoBehaviour
{
    Vector3 starPos_player;
    public Transform transform_player;
    public float rotation = 90f;
    Vector3 raycasting_origin;
    Vector3 raycasting_direction;
    public bool Is_Ladder = false;
    //public Transform chController;
    private Rigidbody playerRigidbody;

    private void Awake()
    {
        starPos_player = transform_player.position;
    }

    private void Start()
    {
        //raycasting_origin = new Vector3(-0.5f, -0.5f, 0.0f);
        //raycasting_direction = new Vector3(-1.0f, rotation, 0.0f);
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            Is_Ladder = true;
            playerRigidbody.isKinematic = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            Is_Ladder = false;
            playerRigidbody.isKinematic = false;
        }
    }

    void Update()
    {
       // raycasting_origin = transform_player.position;
        //raycasting_direction = Vector3.left;
        MoveLeftRight();
       // MoveForwardBack();
        Rotate();
        ClimbLadder();
    }

    void MoveLeftRight()
    {
        Vector3 vec_forward = Vector3.zero;
        vec_forward.z = UnityEngine.Input.GetAxis("Horizontal");
        Vector3 v = new Vector3(0.0f, 0.0f, vec_forward.z) * Time.deltaTime * 1500.0f;
        //transform_player.Translate(v, Space.Self);
        playerRigidbody.AddRelativeForce(v, ForceMode.Force);
    }

    //void MoveForwardBack()
    //{
        //Vector3 vec_left = Vector3.zero;
       // vec_left.x = Input.GetAxis("Horizontal");
      //  Vector3 v = new Vector3(vec_left.x, 0.0f, 0.0f) * Time.deltaTime * 15.0f;
       // transform_player.Translate(v, Space.Self);
   // }
    void Rotate()
    {
        if (RotateChecker())
        {
            
            if (UnityEngine.Input.GetKeyDown(KeyCode.Q))
            {
                // Rotate left (-90 degrees)
                transform_player.Rotate(0, 90, 0);
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                // Rotate right (90 degrees)
                transform_player.Rotate(0, -90, 0);
            }
        }
    }

    bool RotateChecker()
    {
        // Define the maximum distance to check for the horizon or obstacles
        //float viewDistance = 100f; // Adjust based on your game scale
        Vector3 rayOrigin = transform_player.position;
        Vector3 rayDirection = -transform_player.right;
        // Perform the raycast to check for obstacles
        RaycastHit hit;
        if (!Physics.Raycast(rayOrigin, rayDirection, out hit, float.PositiveInfinity))
        {
            return true;
        }
        else 
        {
            if (hit.collider.CompareTag("Glass"))
            {
                return true;
            }
            return false;
        }
    }

    void ClimbLadder()
    {
        if (Is_Ladder)
        {
            Vector3 vec_forward = Vector3.zero;
            vec_forward.y = UnityEngine.Input.GetAxis("Vertical");
            Vector3 v = new Vector3(0.0f, vec_forward.y, 0.0f) * Time.deltaTime * 15.0f;
            transform_player.Translate(v, Space.Self);
        }
    }
}