using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimingBoard : MonoBehaviour {

    public Text text_timeBoard;
    public Timer stopwatch;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        text_timeBoard.text = string.Format("{0:D2}:{1:D2}.{2:D2}", stopwatch.minute, stopwatch.second, stopwatch.millisecond);
	}
}
