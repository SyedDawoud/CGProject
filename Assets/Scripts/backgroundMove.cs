using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMove : MonoBehaviour {

    void OnBecameInvisible()
    {

        transform.localPosition = new Vector3(transform.localPosition.x + (2 *25.56f), transform.localPosition.y, transform.localPosition.z);

    }

}
