using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    private static Player singletonInstance;

    public static Player SingletonInstance
    {
        get
        {
            if (singletonInstance == null)
            {
                singletonInstance = GameObject.FindObjectOfType<Player>();
            }
            return singletonInstance;
        }
    }

    public Rigidbody2D PlayerRigidBody { get; set; }
    
    

    public bool Jump { get; set; }

    public bool Slide { get; set; }
    public bool onGround { get; set; }

    public override bool isDead
    {
        get
        {
            return health <= 0;
        }
    }

    [SerializeField]
    private float groundRadius;

    

    [SerializeField]
    private LayerMask groundSelector;

    // Array for the Ground Points
    [SerializeField]
    private Transform[] ground_points;
 
    [SerializeField]
    private float jumpForce;

	// Use this for initialization
	public override void Start () {

        base.Start();
        // Reference to the Player's Rigid Body
        PlayerRigidBody = GetComponent<Rigidbody2D>();
        
        groundRadius = 0.5f;

    
}
	
	// Update based on timestamp
	void FixedUpdate () {
        // Getting the X-axis value
        float horizontal = Input.GetAxis("Horizontal");

        onGround = isOnGround();

        movementHandler(horizontal);

        changeDirection(horizontal);

        //movementHandler(1);

        //changeDirection(1);

        layersHandler();

       
	}

    private void Update()
    {
       
        inputHandler();
    }

    // Movement Function
    private void movementHandler(float horizontal)
    {
        if(PlayerRigidBody.velocity.y < 0)
        {
            playerAnimator.SetBool("land", true);
        }

        if(!Attack && !Slide && onGround)
        {
            PlayerRigidBody.velocity = new Vector2(horizontal * speed, PlayerRigidBody.velocity.y);       // x-axis movement
        }

        if(Jump && PlayerRigidBody.velocity.y == 0)
        {
            PlayerRigidBody.AddForce(new Vector2(0, jumpForce));         // Jumping Condition
        }

        playerAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }




    
    private void inputHandler()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    playerAnimator.SetTrigger("attack");
        //}

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerAnimator.SetTrigger("slide");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetTrigger("jump");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerAnimator.SetTrigger("throw");
            
        }
    }



    private void changeDirection(float horizontal)
    {

        if (!Slide)
        {
            if (horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight)
            {
                // From Character Class
                ChangeDirection();
            }
        }
    }


    private bool isOnGround()
    {

        if(PlayerRigidBody.velocity.y <= 0)
        {

            foreach(Transform current in ground_points)
            {
                // Creating circle around each point. If the point overlaps with some area, we are on ground or whatever the thing is
                Collider2D[] collider = Physics2D.OverlapCircleAll(current.position, groundRadius,groundSelector);

                foreach(Collider2D temp in collider)
                {
                    // The gameObject on the right refers to the player. It means if all the colliding objects aren't player, player is on ground
                    if (temp.gameObject != gameObject)
                    {

                        return true;
                    }
                }
            }
        }

        return false;

    }


    private void layersHandler()
    {
        if (!onGround)
        {
            playerAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            playerAnimator.SetLayerWeight(1, 0);
        }
    }


    public override void throwKnife(int value)
    {
        
        if(!onGround && value == 1 || onGround && value==0)
        {
            base.throwKnife(value);
            
        }
        
    }

    // IEnumerator will take some seconds before call and stuff
    public override IEnumerator receiveDamage()
    {
       yield return null;
    }
}
