using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Return : MonoBehaviour {

    public bool pass = false;
    private float time = 0.0f;
    public GameObject gradeBoard;
    public Text timeBoard;
    public Timer stopwatch;
    public Grade moutZ;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (pass)
        {
            time += Time.deltaTime;
            if (time > 0.5)
            {
                Time.timeScale = 0;
                gradeBoard.SetActive(true);
                timeBoard.text = string.Format("{0:D2}:{1:D2}.{2:D2}", stopwatch.minute, stopwatch.second, stopwatch.millisecond);
                moutZ.show = true;
            }
        }
	}
}
