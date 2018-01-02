using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TestSetting : MonoBehaviour {


   void OnBecameInvisible()
    {

        int x_range = Random.Range(25, 40);
        transform.localPosition = new Vector3(transform.localPosition.x + x_range, transform.localPosition.y, transform.localPosition.z);

    }

    
}
