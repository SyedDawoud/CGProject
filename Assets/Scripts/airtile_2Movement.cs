using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airtile_2Movement : MonoBehaviour {


    void OnBecameInvisible()
    {
        int x_range = Random.Range(30, 40);
        if (Player.SingletonInstance.transform.localPosition.x > transform.localPosition.x)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + x_range, transform.localPosition.y, transform.localPosition.z);

        }
    }
}
