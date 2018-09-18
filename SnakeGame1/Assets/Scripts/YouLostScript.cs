using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class YouLostScript : MonoBehaviour {
    AudioSource sound;
    public Text highScoreText;
    public Text yourScoreText;
    public Text yourTimeText;
	// Use this for initialization
	void Start () {
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        yourScoreText.text = PlayerPrefs.GetInt("CurrentScore").ToString();
        yourTimeText.text = PlayerPrefs.GetFloat("PlayTime").ToString();
        PlayerPrefs.SetInt("CurrentScore", 0);
        sound = GetComponent<AudioSource>();
        sound.Play();
    }
    // Update is called once per frame
    void Update () {
	}
    public void onReplayPressed()
    {
        PlayerPrefs.SetInt("CurrentScore", 0);
        SceneManager.LoadScene("GameScene");
    }
    public void onMainMenuPressed()
    {
        PlayerPrefs.SetInt("CurrentScore", 0);
        SceneManager.LoadScene("WelcomeScene");
    }
}
