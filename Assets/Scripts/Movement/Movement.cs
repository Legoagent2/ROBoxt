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
    //Vector3 raycasting_origin;
    //Vector3 raycasting_direction;
    public bool Is_Ladder = false;
    //public Transform chController;
    private Rigidbody playerRigidbody;
    private float jump_force_start = 2.5f;

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
            playerRigidbody.useGravity = false;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            Is_Ladder = false;
            playerRigidbody.useGravity = true;
        }
    }

    void FixedUpdate()
    {
        MoveLeftRight();

        ClimbLadder();

    }

    void Update()
    {
        //raycasting_origin = transform_player.position;
        //raycasting_direction = Vector3.left;
        Jump();
        // MoveForwardBack();
        Rotate();

    }

    void Jump()
    {
        float jump_force_sim = jump_force_start;
        if((Physics.Raycast(transform.position - new Vector3(0.0f, 0.3f, 0.0f), transform.forward, 1.0f)) || (Physics.Raycast(transform.position - new Vector3(0.0f, 0.3f, 0.0f), -transform.forward, 1.0f)))
        {
            jump_force_sim *= 3.0f;
        }
        if(UnityEngine.Input.GetKeyDown(KeyCode.Space) && (Is_Ladder == false))
        {
            if(Physics.Raycast(transform_player.position, Vector3.down, 0.6f))
            {
                playerRigidbody.AddRelativeForce(Vector3.up * jump_force_sim, ForceMode.Impulse);
                Debug.Log("triggered");
            }
        }
    }
        
        
    

    void MoveLeftRight()
    {
        Vector3 vec_forward = transform.forward;
        vec_forward = vec_forward * UnityEngine.Input.GetAxis("Horizontal") * 5.0f;
        //Vector3 v = new Vector3(0.0f, 0.0f, vec_forward.z) * 5.0f;// * Time.deltaTime;
        playerRigidbody.velocity = new Vector3(vec_forward.x, playerRigidbody.velocity.y, vec_forward.z ); 
        
        //transform_player.Translate(v, Space.Self);
        //playerRigidbody.AddRelativeForce(v, ForceMode.Force);
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
        //Vector3 rayOrigin = ;
        //Vector3 rayDirection = ;
        // Perform the raycast to check for obstacles
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, -transform.right, out hit, float.PositiveInfinity))
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