using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skicontrol : MonoBehaviour {
    private MeshRenderer[] boardMesh;
    public GameObject cameracontrol;
    private float maxAngle = 90f;
    private float maxMove = 10f;
    private float h, v;

    public ParticleSystem[] splashSnow;

    private bool speedUp = false;
    private bool speedDown = false;
    private bool turnLeft = false;
    private bool turnRight = false;


    public float skiSpeed=0;
    public float skiSpeedMax = 50;//最大速度

    public Animator[] hand;

    void Start()
    {
        h = 0;
        v = 0;
        boardMesh = transform.GetChild(0).GetComponentsInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(skiSpeed != 0)
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
        if(speedUp || speedDown)
        {
            if (speedUp)
            {
                foreach (var i in hand)
                {
                    i.SetBool("up", true);
                }
                if (skiSpeed < skiSpeedMax)
                {
                    //skiSpeed += maxMove * Time.deltaTime;
                    //skiSpeed = Mathf.Clamp(skiSpeed, 0, skiSpeedMax);
                    skiSpeed = Mathf.MoveTowards(skiSpeed, skiSpeedMax, maxMove * Time.deltaTime);
                }
                v = Mathf.MoveTowards(v, 1, 1 * Time.deltaTime);
            }
            else
            {
                foreach (var i in hand)
                {
                    i.SetBool("up", false);
                }
            }
            if (speedDown)
            {
                foreach (var i in hand)
                {
                    i.SetBool("down", true);
                }
                skiSpeed = Mathf.MoveTowards(skiSpeed, 0, 2 * maxMove * Time.deltaTime);
                v = Mathf.MoveTowards(v, -1, 2 * Time.deltaTime);
            }
            else
            {
                foreach (var i in hand)
                {
                    i.SetBool("down", false);
                }
            }
        }
        else
        {
            foreach (var i in hand)
            {
                i.SetBool("up", false);
            }
            foreach (var i in hand)
            {
                i.SetBool("down", false);
            }
            skiSpeed = Mathf.MoveTowards(skiSpeed, 0, 1 * Time.deltaTime);
            v = Mathf.MoveTowards(v, 0, 10 * Time.deltaTime);
            
        }

        if (turnLeft || turnRight)
        {
            if (turnLeft)
            {
                h = Mathf.MoveTowards(h, -3, 1 * Time.deltaTime);
            }
            if (turnRight)
            {
                h = Mathf.MoveTowards(h, 3, 1 * Time.deltaTime);
            }
        }
        else
        {
            h = Mathf.MoveTowards(h, 0, 5 * Time.deltaTime);
        }

        transform.Translate(Vector3.forward * skiSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, h, 0) * maxAngle * Time.deltaTime);

        for (int i = 0; i < 2; i++)
        {
            boardMesh[i].transform.localRotation = Quaternion.Euler(0, h * 3 * maxAngle * Time.deltaTime, 0);
        }
        //partMove();

    }

    private void partMove()
    {

        for (int i = 0; i < 2; i++)
        {
            boardMesh[i].transform.localRotation = Quaternion.Euler(0, h * 3 * maxAngle * Time.deltaTime, 0);
        }
        cameracontrol.transform.localRotation = Quaternion.Euler(0, 0, h  * maxAngle * Time.deltaTime);
        cameracontrol.transform.localPosition = new Vector3( h * maxAngle * Time.deltaTime, 0, v * 3 * maxMove * Time.deltaTime);
        
    }

    private void LateUpdate()
    {
        cameracontrol.transform.localRotation = Quaternion.Euler(0, 0, h * maxAngle * Time.deltaTime);
        cameracontrol.transform.localPosition = new Vector3(h * maxAngle * Time.deltaTime, 0, v * 3 * maxMove * Time.deltaTime);
        //partMove();
    }

    public void quickOn()
    {
        speedUp = true;
    }

    public void quickOff()
    {
        speedUp = false;
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
