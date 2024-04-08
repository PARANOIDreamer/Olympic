using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

     public int hour;
     public int minute;
     public int second;
     public int millisecond;

     public float time = 0.0f;
    
    public bool ready = false;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (ready)
        {
            time += Time.deltaTime;
            //hour = (int)time / 3600;
            minute = (int)time / 60;
            second = (int)time - minute * 60;
            millisecond = (int)((time - (int)time) * 1000);
        }
        
	}
}
