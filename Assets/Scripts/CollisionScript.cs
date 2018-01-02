using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour {


    private BoxCollider2D playerCollider;
    [SerializeField]
    private BoxCollider2D platformCollider;
    [SerializeField]
    private BoxCollider2D platformTrigger;

	// Use this for initialization
	void Start () {
        playerCollider = GameObject.Find("Player").GetComponent<BoxCollider2D>();
        // ignore collision between the main platform collider and the trigger collider
        Physics2D.IgnoreCollision(platformCollider, platformTrigger, true);
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If player is coming from below, ignore the collision
        if (collision.gameObject.name == "Player")
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollider, true);
        }
    }

    // Reset the trigger when it is over
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollider, false);
        }
    }
}
