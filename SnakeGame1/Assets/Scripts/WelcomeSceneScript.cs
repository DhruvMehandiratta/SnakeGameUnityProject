using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WelcomeSceneScript : MonoBehaviour {

    // Use this for initialization
    bool isPlaying = true;
    AudioSource sound;
    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.Play();
        if (PlayerPrefs.GetInt("HighScore") == null)
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        PlayerPrefs.SetInt("CurrentScore", 0);
    }
        // Update is called once per frame
        void Update () {
	}
    public void LoadGamePlayScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void onMuteButtonPressed()
    {
        if (isPlaying)
        {
            sound.volume = 0;
            GameObject.Find("MuteButton").GetComponentInChildren<Text>().text = "UnMute";
            isPlaying = false;
        }
        else
        {
            sound.volume = 1;
            GameObject.Find("MuteButton").GetComponentInChildren<Text>().text = "Mute";
            isPlaying = true;
        }
    }
    public void onInstructionsButtonPressed()
    {
        SceneManager.LoadScene("InstructionsScene");
    }
}
