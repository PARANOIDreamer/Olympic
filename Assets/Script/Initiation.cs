using UnityEngine;
using System.Collections;

public class Initiation : MonoBehaviour {

    public Timer stopwath;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            stopwath.ready = true;
        }
    }
    
}
