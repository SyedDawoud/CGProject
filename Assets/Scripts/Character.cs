using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    //protected Animator playerAnimator;
    public Animator playerAnimator { get; private set; }


    [SerializeField]
    protected float speed;

    // To check for the face direction
    protected bool isFacingRight;

    // Use this for initialization
   public virtual void Start () {
        playerAnimator = GetComponent<Animator>();
        isFacingRight = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeDirection()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

  
}
