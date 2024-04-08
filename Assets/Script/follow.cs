using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {


    //public GameObject target;
    public Transform target;
    public Transform player;
    private Transform startPos;

    // Use this for initialization
    void Start () {
        //startPos.position = playerArea.position - target.transform.position;
        startPos.position = player.position - target.position;
    }
	
	// Update is called once per frame
	void Update () {
        player.position = target.position + startPos.position;
    }

}
