using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    private float maxAngle = 90f;
    private float maxMove = 10f;
    private float h, v;

    public ParticleSystem[] splashSnow;
    private Animator skiaction;

    private bool speedUp = false;
    private bool speedDown = false;
    private bool turnLeft = false;
    private bool turnRight = false;
    private bool goHead = false;

    public float skiSpeed = 0;
    public float skiSpeedMax = 50;//最大速度

    void Start()
    {
        h = 0;
        v = 0;
        skiaction = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (skiSpeed != 0)
        {
            foreach (var i in splashSnow)
            {
                i.Play();
            }
        }
        else
        {
            foreach (var i in splashSnow)
            {
                i.Stop();
            }
        }
        if (speedUp || speedDown)
        {
            if (speedUp)
            {
                if (!goHead)
                {
                    skiaction.SetBool("up", true);
                    //skiaction.SetBool("go", false);
                }
                /*
                if (skiSpeed > 0)
                {
                    skiaction.SetBool("up", true);
                    //skiaction.SetBool("go", false);
                }
                else
                {
                    skiaction.SetBool("go", true);
                    skiaction.SetBool("up", false);
                }*/
                //skiaction.SetFloat("gohead", v);
                //skiaction.SetBool("up", true);
                if (skiSpeed < skiSpeedMax)
                {
                    skiSpeed = Mathf.MoveTowards(skiSpeed, skiSpeedMax, maxMove * Time.deltaTime);
                }
                v = Mathf.MoveTowards(v, 1, 1 * Time.deltaTime);
            }
            else
            {
                //skiaction.SetBool("up", false);
                //skiaction.Play("stop", 0, 0);
                //skiaction.SetBool("go", false);
            }
            if (speedDown)
            {
                skiaction.SetBool("down", true);
                skiSpeed = Mathf.MoveTowards(skiSpeed, 0, 2 * maxMove * Time.deltaTime);
                v = Mathf.MoveTowards(v, -1, 2 * Time.deltaTime);
            }
            else
            {
                skiaction.SetBool("down", false);
            }
        }
        else
        {
            skiaction.SetBool("up", false);
            skiaction.SetBool("go", false);
            skiaction.SetBool("down", false);
            skiSpeed = Mathf.MoveTowards(skiSpeed, 0, 1 * Time.deltaTime);
            v = Mathf.MoveTowards(v, 0, 10 * Time.deltaTime);

        }

        if (turnLeft || turnRight)
        {
            if (turnLeft)
            {
                skiaction.SetBool("left", true);
                skiaction.SetBool("right", false);
                h = Mathf.MoveTowards(h, -3, 1 * Time.deltaTime);
            }
            if (turnRight)
            {
                skiaction.SetBool("left", false);
                skiaction.SetBool("right", true);
                h = Mathf.MoveTowards(h, 3, 1 * Time.deltaTime);
            }
        }
        else
        {
            h = Mathf.MoveTowards(h, 0, 5 * Time.deltaTime);
            skiaction.SetBool("left", false);
            skiaction.SetBool("right", false);
        }
        
        transform.Translate(Vector3.forward * skiSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, h, 0) * maxAngle * Time.deltaTime);
        //Debug.Log(skiaction.SetFloat("turn"));
    }

    public void quickOn()
    {
        speedUp = true;
        if (skiSpeed < 0.1)
        {
            skiaction.SetBool("go", true);
            goHead = true;
        }
        //skiaction.SetBool("go", true);
    }

    public void quickOff()
    {
        speedUp = false;
        goHead = false;
        //skiaction.SetFloat("gohead", 0);
        skiaction.SetBool("go", false);
    }

    public void slowOn()
    {
        speedDown = true;
    }

    public void slowOff()
    {
        speedDown = false;
    }

    public void leftOn()
    {
        turnLeft = true;
    }

    public void leftOff()
    {
        turnLeft = false;
    }

    public void rightOn()
    {
        turnRight = true;
    }

    public void rightOff()
    {
        turnRight = false;
    }
}
