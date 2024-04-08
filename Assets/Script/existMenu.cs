using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class existMenu : MonoBehaviour {

    private bool exist = false;
    public GameObject[] board;
    public GameObject choseBoard;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void turnBack()
    {
        if (exist)
        {
            Time.timeScale = 1f;
            choseBoard.SetActive(false);
            SceneManager.LoadScene("building", LoadSceneMode.Single);
        }
        else
        {
            Time.timeScale = 0;
            foreach (var i in board)
            {
                i.SetActive(false);
            }
            choseBoard.SetActive(true);
            exist = true;
        }

    }

    public void chanleBack()
    {
        if (exist)
        {
            choseBoard.SetActive(false);
            Time.timeScale = 1f;
            exist = false;
        }
    }

}
