using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class SnakeScriptt : MonoBehaviour
{
    // Use this for initialization
    //direction of movement of snake
    Vector2 direction = Vector2.right;
    bool ate = false;
    private int score = 0;
    private int life = 2;
    public GameObject tailPrefab;
    public Text scoreText;
    public Text lifeText;
    public Text timerText;
    public Text topScoreText;
    private float startTime;
    private float deltaTime;
    public AudioSource eatingAudioSource;
    public AudioSource energyAudioSource;
    public bool paused;

    //tail
    private List<Transform> tail = new List<Transform>();
    void Start()
    {
        //snake moved after every 100 ms ....if we do this in update function then its called at every frame...which will be very fast
        UpdateScoreText();
        UpdateLifeText();
        topScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        InvokeRepeating("Move", 0.15f, 0.15f);
        paused = false;
        startTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        //change the direction
        deltaTime = Time.time - startTime;
        string minutes = ((int)deltaTime / 60).ToString();
        string seconds = (deltaTime % 60).ToString("f2");
        timerText.text = minutes + ":" + seconds;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //if snake moving in left direction, then ignore right key: -
            if (direction != Vector2.left)
            {
                direction = Vector2.right;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (direction != Vector2.right)
            {
                direction = Vector2.left;
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (direction != Vector2.down)
            {
                direction = Vector3.up;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (direction != Vector2.up)
            {
                direction = Vector3.down;
            }
        }
        //play and pause
        else if (Input.GetKey(KeyCode.Space) || (Input.GetKey(KeyCode.Escape)))
        {
            /*if (!pausePanel.activeInHierarchy)
            {
                PauseGame();
            }
            if (pausePanel.activeInHierarchy)
            {
                ContinueGame();
            }*/
            paused = !paused;
            if (paused)
            {
                PauseGame();
            }
            else if (!paused)
            {
                ContinueGame();
            }
        }
    }
    void Move()
    {
        //move the last tail element to the gap to move the snake tail
        //saving the current head position: -
        Vector2 v = transform.position;
        //Move head into new direction
        transform.Translate(direction);
        if (ate)
        {
            //Load Prefab that is instantiate it for making new tail element
            GameObject newTailElement = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);
            tail.Insert(0, newTailElement.transform);
            ate = false;
        }
        //tail
        if (tail.Count > 0)
        {
            tail.Last().position = v;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //Food
        if (coll.CompareTag("FoodTag"))
        {
            eatingAudioSource.Play();
            ate = true;
            //Remove the food
            Destroy(coll.gameObject);
            score += 10;
            UpdateScoreText();
        }
        //energy
        else if (coll.CompareTag("EnergyTag"))
        {
            PlayEnergySound();
            Destroy(coll.gameObject);
            score += 100;
            UpdateScoreText();
            //length not increased and ate is not updated
        }
        //poison
        else if (coll.CompareTag("PoisonTag"))
        {
            Destroy(coll.gameObject);
            life--;
            UpdateLifeText();
            score -= 100;
            if (score < 0)
            {
                score = 0;
            }
            UpdateScoreText();
            if (life <= 0)
            {
                PlayerPrefs.SetFloat("PlayTime", deltaTime);
                SceneManager.LoadScene("YouLostScene");
            }
        }
        //life
        else if (coll.CompareTag("LifeTag"))
        {
            Destroy(coll.gameObject);
            life++;
            UpdateLifeText();
        }
        
        else
        {
            //collided with border or itself
            if (coll.CompareTag("BottomWall"))
            {
                transform.Translate(0, 15, 0);
            }
            else if (coll.CompareTag("TopWall"))
            {
                transform.Translate(0, -15, 0);
            }
            else if (coll.CompareTag("LeftWall"))
            {
                transform.Translate(25, 0, 0);
            }
            else if (coll.CompareTag("RightWall"))
            {
                transform.Translate(-25, 0, 0);
            }
            //save score in playerprefs
            Debug.Log("here");
            life--;
            UpdateLifeText();
            if (life <= 0)
            {
                PlayerPrefs.SetFloat("PlayTime", deltaTime);
                SceneManager.LoadScene("YouLostScene");
            }
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("CurrentScore", score);
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (highScore < score)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
    void UpdateLifeText()
    {
        lifeText.text = life.ToString();
    }
    void PlayEatingSound()
    {
        eatingAudioSource.Play();
    }
    void PlayEnergySound()
    {
        energyAudioSource.Play();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
    }
    public void onLeftButtonClicked()
    {
        if(direction == Vector2.up)
        {
            direction = Vector2.left;
        }
        else if (direction == Vector2.left)
        {
            direction = Vector2.down;
        }
        else if (direction == Vector2.down)
        {
            direction = Vector2.right;
        }
        else if (direction == Vector2.right)
        {
            direction = Vector2.up;
        }
    }
    public void onRightButtonClicked()
    {
        if (direction == Vector2.up)
        {
            direction = Vector2.right;
        }
        else if (direction == Vector2.left)
        {
            direction = Vector2.up;
        }
        else if (direction == Vector2.down)
        {
            direction = Vector2.left;
        }
        else if (direction == Vector2.right)
        {
            direction = Vector2.down;
        }
    }
    public void onPauseButtonClicked()
    {
        paused = !paused;
        if (paused)
        {
            PauseGame();
        }
        else if (!paused)
        {
            ContinueGame();
        }
    }
}
