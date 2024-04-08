using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Turn2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // this.GetComponent<Button>().OnClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void skip()
    {
        SceneManager.LoadScene("mountain", LoadSceneMode.Single);
    }
}
