using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Daniel West-WES15004515
Simon Hunt – Games Technologies for Virtual Reality
Assignment 1 – Written Code*/

public class PlayerController : MonoBehaviour {

    public float moveSpeed; //Determines the movement speed of the player
    private float moveSpeedStore; //Stores the starting speed of the player
    public float speedMultiplier; //Increased movement speed velocity

    public float speedIncreaseMilestone; //A milestone. If reached then the movement speed of the player will increase
    private float speedIncreaseMilestoneStore; //stores the increased milestone speed
    private float speedMilestoneCount; //Keeps track of the current milestone
    private float speedMilestoneCountStore; //Stores the starting milestone count

    public float jumpForce; //Determines the force applied to the player in an upwards direction
    public float jumpTime; //How long the player can jump for
    private float jumpTimeCounter; //Counter that keeps track of how often jumpTime has been used

    private bool stoppedJumping; //Determines whether the player has stopped jumping or not

    private Rigidbody2D myRigidbody; //Rigidbody that belongs to the player

    public bool grounded; //Checks to see if the player is touching the floor
    public LayerMask whatIsGround; //Assigns a layer to an object
    public Transform groundCheck; //Checks for the ground
    public float groundCheckRadius; //The radius of the ground check

    //private Collider2D myCollider; //Collider that belongs to the player 

    private Animator myAnimator; //Animator that belongs to the player 

    public GameManager theGameManager; //Reference to the GameManager

    public AudioSource jumpSound; //The sound of the players jump
    public AudioSource deathSound; //the sound of the players death

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>(); //Searches the player for the Rigidbody2D

        //myCollider = GetComponent<Collider2D>(); //Searches the player for the Collider2D

        myAnimator = GetComponent<Animator>(); //Searches the player for the Animator

        jumpTimeCounter = jumpTime; //jumpTimeCounter is the same equal to jumpTime

        //Adjusts the speedMilestoneCount to use the new speedIncreaseMilestone
        speedMilestoneCount = speedIncreaseMilestone;

        moveSpeedStore = moveSpeed; //the moveSpeedStore has the same value as the starting moveSpeed
        //the speedMilestoneCountStore has the same value as the starting speedMilestoneCount
        speedMilestoneCountStore = speedMilestoneCount;
        //the speedIncreaseMilestoneStore has the same value as the increased milestone speed 
        speedIncreaseMilestoneStore = speedIncreaseMilestone;

        stoppedJumping = true; //Player has stopped jumping
	}
	
	// Update is called once per frame
	void Update () {

        //If the collider on the player is touching the collider on the ground, then the player is considered grounded.
        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        //If the circle is overlapping with the ground, then contact with the ground is true
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround); 

        //Moves the milestone when reached, increasing the distance to the next one and applies the speedMultiplier to the moveSpeed
        if (transform.position.x > speedMilestoneCount) 
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier; 

            moveSpeed = moveSpeed * speedMultiplier;
        }

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y); //Adds velocity to player on the x axis 

        //Every time the spacebar or left click is pressed, this if statement will run
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
        {
            if (grounded) //allows the player to jump if grounded
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce); //Adds velocity to player on the y axis
                stoppedJumping = false; //Player is jumping when the spacebar or left click is pressed
                jumpSound.Play(); //Plays the jumpSound
            }
        }

        //Allows the player to continue jumping if they hold onto the left mouse button or spacebar
        if ((Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping) 
        {
            if (jumpTimeCounter > 0)
                stoppedJumping = true; //Player has stopped jumping
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce); //Adds velocity to player on the y axis
                jumpTimeCounter -= Time.deltaTime; //Counts down to 0, then stops adding velocity to y axis
            }
        }

        /*When the player stops pressing the spacebar or left mouse click,
         * prevents velocity being added on the y axis until the player reaches the floor again */
        if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp(0)) 
        {
            jumpTimeCounter = 0;
        }

        if(grounded)
        {
            jumpTimeCounter = jumpTime;
        }

        //Allows the animator to see what velocity is applied to the player
        myAnimator.SetFloat("Speed", myRigidbody.velocity.x); 
        myAnimator.SetBool("Grounded", grounded); //Allows the animator to see if the player is grounded
	}

    //Detects the collision between two objects. In this instance the player and the killbox
    void OnCollisionEnter2D (Collision2D other) 
    {
        if(other.gameObject.tag == "killbox")
        {   
            theGameManager.RestartGame(); //Calls for the RestartGame routine
            moveSpeed = moveSpeedStore; //When the player dies, resets the movement speed
            speedMilestoneCount = speedMilestoneCountStore; //when the player dies, resets the milestones
            speedIncreaseMilestone = speedIncreaseMilestoneStore; //When the player dies, resets the increased milestone speed
            deathSound.Play(); //Plays the deathSound
        }
    }
}
