using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    
    public bool onGround { get; set; }

    public bool inScene { get; set; }


    [SerializeField]
    private float groundRadius;

    

    [SerializeField]
    private LayerMask groundSelector;

    // Array for the Ground Points
    [SerializeField]
    private Transform[] ground_points;
 
    [SerializeField]
    private float jumpForce;

    public Text text;

    public Text score;

    public long score_counter;

    private int speed_counter;

    private int score_multiplier;

	// Use this for initialization
	public override void Start () {

        base.Start();
        // Reference to the Player's Rigid Body
        PlayerRigidBody = GetComponent<Rigidbody2D>();
        
        groundRadius = 0.5f;
        inScene = true;
        text.enabled = false;
        score_counter = 0;
        score.text = score_counter.ToString();
        score_multiplier = 1;


}
	
	// Update based on timestamp
	void FixedUpdate () {
        // Getting the X-axis value
        //float horizontal = Input.GetAxis("Horizontal");
       
        //Debug.Log(this.inScene);
        if (inScene == true)
        {
            speed_counter += 1;
            onGround = isOnGround();

            //movementHandler(horizontal);

            //changeDirection(horizontal);

            movementHandler(1);

            changeDirection(1);

            layersHandler();

            score_counter += (1* score_multiplier);
            score.text = score_counter.ToString();

            if (GameObject.Find("Player").transform.position.y <= -6)
            {
                this.inScene = false;
                Debug.Log(this.inScene);
            }

            if(speed_counter == 500)
            {
                speed += 0.5f;
                score_multiplier += 1;
                speed_counter = 0;
            }
           // Debug.Log(GameObject.Find("Player").transform.position.y);

        }
        if (inScene == false)
        {
            Thread.Sleep(2000);
            SceneManager.LoadScene("end");
        }
       
	}

    private void Update()
    {
        if (this.inScene==true)
        {
            inputHandler();
        }
    }

    // Movement Function
    private void movementHandler(float horizontal)
    {
        if (this.inScene==true)
        {
           
            if (PlayerRigidBody.velocity.y < 0)
            {
                playerAnimator.SetBool("land", true);
            }

            if (onGround)
            {
                PlayerRigidBody.velocity = new Vector2(horizontal * speed, PlayerRigidBody.velocity.y);       // x-axis movement
            }

            if (Jump && PlayerRigidBody.velocity.y == 0)
            {
                PlayerRigidBody.AddForce(new Vector2(0, jumpForce));         // Jumping Condition
            }

        }

    }




    
    private void inputHandler()
    {
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetTrigger("jump");
        }

        if (Input.GetKeyDown (KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                text.enabled = true;

            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                text.enabled = false;

            }
        }
        
    }



    private void changeDirection(float horizontal)
    {

       
            if (horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight)
            {
                // From Character Class
                ChangeDirection();
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

    

}
