using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TestSetting : MonoBehaviour {


   void OnBecameInvisible()
    {
        
        transform.localPosition = new Vector3(transform.localPosition.x + 23 , transform.localPosition.y,transform.localPosition.z);
        
    }

    
}
