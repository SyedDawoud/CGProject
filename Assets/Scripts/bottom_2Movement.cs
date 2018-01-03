using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottom_2Movement : MonoBehaviour {

    private bool first = true;
    void OnBecameInvisible()
    {
        int x_range;
        if (first==true)
        {
            x_range = Random.Range(41, 43);
        }
        else
        {
            x_range = Random.Range(47, 49);
        }
        if (Player.SingletonInstance.transform.localPosition.x > transform.localPosition.x)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + x_range, transform.localPosition.y, transform.localPosition.z);
            first = false;
        }
    }
}
