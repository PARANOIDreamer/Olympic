using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject target;
    public Transform playerArea;
    public Transform headPos;

    private void LateUpdate()
    {
        SetPlayerAreaPosition();//需要放在LateUpdate里面，如果放在Update里的话，会有很大抖动
                                //changen.rotation = target.rotation;

    }
    
    private void SetPlayerAreaPosition()
    {
        //target是要跟随的目标，
        //playerArea是CameraRig    
        //headPos是  camera（head）
        playerArea.position = target.transform.position + (playerArea.position - headPos.position);
        playerArea.rotation = target.transform.rotation;
        
    }
}
