using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionIgnore : MonoBehaviour {


    [SerializeField]
    private Collider2D collider;

	private void Awake () {

        // Ignore Collision between ourself and other collider object 
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider, true);
	}
	
	
}
