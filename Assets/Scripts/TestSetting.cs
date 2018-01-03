using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TestSetting : MonoBehaviour {


   void OnBecameInvisible()
    {

        int x_range = Random.Range(49, 51);
        if (Player.SingletonInstance.transform.localPosition.x > transform.localPosition.x)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + x_range, transform.localPosition.y, transform.localPosition.z);
        }

    }

    
}
