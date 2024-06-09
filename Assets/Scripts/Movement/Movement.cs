using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 starPos_player;
    public Transform transform_player;
    public float rotation = 90f;
    public bool Is_Ladder = false;
    private Rigidbody playerRigidbody;
    public float jump_force_start;
    
    Animator Player;
    bool Walking;
    bool Jumping;

    private void Awake()
    {
        starPos_player = transform_player.position;
    }

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();

        Player = gameObject.GetComponentInChildren<Animator>();
        Walking = false;
        
    }

    void Update()
    {
        //Walking
        //Plays the walking animation going right
        if (Input.GetKey(KeyCode.D))
        {
            Walking = true;
        }
        else
        {
            Walking = false;
        }

        if (Walking == false)
        {
            Player.SetBool("Walking", false);
        }

        if (Walking == true)
        {
            Player.SetBool("Walking", true);
        }

        //Plays the walking animation going left
        else if (Input.GetKey(KeyCode.A))
        {
            Walking = true;
        }
        else
        {
            Walking = false;
        }

        if (Walking == false)
        {
            Player.SetBool("Walking", false);
        }

        if (Walking == true)
        {
            Player.SetBool("Walking", true);
        }

        //Trying to set up the jump animation
        if (Walking == true)
        {
            Player.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Jumping = true;
        }
        else
        {
            Jumping = false;
        }

        if (Jumping == false)
        {
            Player.SetBool("Jumping", false);
        }

        if (Jumping == true)
        {
            Player.SetBool("Jumping", true);
        }

        Jump();
        Rotate();
    }

    //Detects when the player has entered the ladder collider
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

    //Allows the player to jump
    void Jump()
    {
        float jump_force_sim = jump_force_start;
        if((Physics.Raycast(transform.position - new Vector3(0.0f, 0.3f, 0.0f), transform.forward, 1.0f)) || (Physics.Raycast(transform.position - new Vector3(0.0f, 0.3f, 0.0f), -transform.forward, 1.0f)))
        {
            jump_force_sim *= 2.5f;
        }
        if(UnityEngine.Input.GetKeyDown(KeyCode.Space) && (Is_Ladder == false))
        {
            if(Physics.Raycast(transform_player.position, Vector3.down, 0.6f))
            {
                playerRigidbody.AddRelativeForce(Vector3.up * jump_force_sim, ForceMode.Impulse);
            }
        }
    }
        
        
    
    //Gives the player movement to traverse the game world
    void MoveLeftRight()
    {
        Vector3 vec_forward = transform.forward;
        vec_forward = vec_forward * UnityEngine.Input.GetAxis("Horizontal") * 5.0f;
        playerRigidbody.velocity = new Vector3(vec_forward.x, playerRigidbody.velocity.y, vec_forward.z );
        // reutrn to this to make child object rotate
        
        
    }
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

    //Sends out a raycast to see if theres any blocks in the players path
    bool RotateChecker()
    {
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

    //Allows the player to go up and down the ladder
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