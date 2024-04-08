using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grade : MonoBehaviour
{
    public bool show = false;
    public Text gradeBoard;
    public Timer stopwatch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (show)
        {
            if(stopwatch.time < 45.0f)
            {
                gradeBoard.text = "高手";
            }
            else
            {
                if (stopwatch.time < 60.0f)
                {
                    gradeBoard.text = "优秀";
                }
                else
                {
                    if (stopwatch.time < 75.0f)
                    {
                        gradeBoard.text = "良好";
                    }
                    else
                    {
                        gradeBoard.text = "初级";
                    }
                }
            }
        }
    }
}
