using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bottons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public void Replay()
    {
        Debug.Log("Reload");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
    }
	// Update is called once per frame
	void Update () {
		
	}
}
