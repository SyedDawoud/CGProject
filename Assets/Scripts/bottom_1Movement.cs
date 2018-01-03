using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottom_1Movement : MonoBehaviour {

    private bool first = true;

    private void OnBecameInvisible()
    {
        int x_range;
        if (first == true)
        {
             x_range = Random.Range(63, 65);
        }
        else
        {
             x_range = Random.Range(45, 50);
        }
        
        if (Player.SingletonInstance.transform.localPosition.x > transform.localPosition.x)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + x_range, transform.localPosition.y, transform.localPosition.z);
            first = false;
        }
    }

}
