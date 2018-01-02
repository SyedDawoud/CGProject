using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    //protected Animator playerAnimator;
    public Animator playerAnimator { get; private set; }

    public bool takingDamage { get; set; }

    [SerializeField]
    protected Transform knifePosition;

    [SerializeField]
    protected float speed;

    // To check for the face direction
    protected bool isFacingRight;

    [SerializeField]
    protected GameObject knifePrefab;

    public bool Attack { get; set; }

    [SerializeField]
    protected int health;


    public abstract bool isDead { get; }

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

    public virtual void throwKnife(int value)
    {
        GameObject temp;
        if (isFacingRight)
        {
            temp = (GameObject)Instantiate(knifePrefab, knifePosition.position, Quaternion.Euler(new Vector3(0, 0, -90)));
            temp.GetComponent<Knife>().initialize(Vector2.right);
        }
        else
        {
            temp = (GameObject)Instantiate(knifePrefab, knifePosition.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            temp.GetComponent<Knife>().initialize(Vector2.left);
        }
    }


    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerKnife")
        {
            StartCoroutine(receiveDamage());
        }
    }

    public abstract IEnumerator receiveDamage();
}
