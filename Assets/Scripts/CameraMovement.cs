using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    [SerializeField]
    private float xMax;
    [SerializeField]
    private float yMax;
    [SerializeField]
    private float xMin;
    [SerializeField]
    private float yMin;

    private Transform target;

	// Use this for initialization
	void Start () {

        if (CharacterSelection.char_choice == 1)
        {
            GameObject.FindGameObjectWithTag("DS").SetActive(false);
            GameObject.FindGameObjectWithTag("KJ").SetActive(true);
        } 
        else if (CharacterSelection.char_choice == 2)
        {
            GameObject.FindGameObjectWithTag("KJ").SetActive(false);
            GameObject.FindGameObjectWithTag("DS").SetActive(true);
        }


        target = GameObject.Find("Player").transform;
	}
	
	
	void LateUpdate () {
        if (Player.SingletonInstance.inScene == true)
        {
            transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
        }
	}
}
