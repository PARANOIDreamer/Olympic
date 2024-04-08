using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Destination : MonoBehaviour {

    public Timer stopwatch;

    public Return skip;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            stopwatch.ready = false;
            skip.pass = true;
        }
    }

}
