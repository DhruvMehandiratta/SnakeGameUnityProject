using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	void Update () {
	}
    public void onBackButtonPressed()
    {
        SceneManager.LoadScene("WelcomeScene");
    }
}
