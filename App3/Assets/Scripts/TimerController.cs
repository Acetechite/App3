using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour {

    public Text timerText;
    public GameObject pauseMenu;
    public GameObject startMenu;
    public GameObject leaderMenu;
    private float startTime;
    private bool pause;
    public AudioSource aud;
    public GameObject leaderBoard;

    public float first;
    public float second;
    public float third;

    public GameObject firstG;
    public GameObject secondG;
    public GameObject thirdG;

    private Text firstT;
    private Text secondT;
    private Text thirdT;
    
    public void UpdateScores(float newScore, string score)
    {
        third = PlayerPrefs.GetFloat("third");
        second = PlayerPrefs.GetFloat("second");
        first = PlayerPrefs.GetFloat("first");
        Debug.Log(first);
        Debug.Log(second);
        Debug.Log(third);

        if (first > newScore)
        {
            PlayerPrefs.SetFloat("third", second);
            Debug.Log(second);
            Debug.Log(PlayerPrefs.GetFloat("third"));
            PlayerPrefs.SetString("thirdT", secondT.text);
            PlayerPrefs.SetFloat("second", first);
            PlayerPrefs.SetString("secondT", firstT.text);
            PlayerPrefs.SetFloat("first", newScore);
            PlayerPrefs.SetString("firstT", score);
        }
        else if (second > newScore)
        {
            PlayerPrefs.SetFloat("third", second);
            PlayerPrefs.SetString("thirdT", secondT.text);
            PlayerPrefs.SetFloat("second", newScore);
            PlayerPrefs.SetString("secondT", score);
        }
        else if (third < newScore)
        {
            PlayerPrefs.SetFloat("third", newScore);
            PlayerPrefs.SetString("thirdT", score);
        }

        PlayerPrefs.Save();
        third = PlayerPrefs.GetFloat("third");
        thirdT.text = PlayerPrefs.GetString("thirdT");
        second = PlayerPrefs.GetFloat("second");
        secondT.text = PlayerPrefs.GetString("secondT");
        first = PlayerPrefs.GetFloat("first");
        firstT.text = PlayerPrefs.GetString("firstT");

        
        

    }

    // Use this for initialization
    void Start () {
        aud = GetComponent<AudioSource>();
        startTime = Time.time;
        pause = false;
        Time.timeScale = 0f;
        startMenu.SetActive(true);
        firstT = firstG.GetComponent<Text>();
        PlayerPrefs.SetString("firstT", firstT.text);
        secondT = secondG.GetComponent<Text>();
        thirdT = thirdG.GetComponent<Text>();
        
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape) && !pause && !startMenu.activeSelf)
        {
            aud.Pause();
            Time.timeScale = 0f;
            pause = true;
            pauseMenu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape)&& pause)
        {
            aud.UnPause();
            Time.timeScale = 1f;
            pause = false;
            pauseMenu.SetActive(false);
        }

        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
	}

    public void Restart() {
        Time.timeScale = 1f;
        pause = false;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void StartUp()
    {
        Time.timeScale = 1f;
        AudioSource aud = gameObject.GetComponent<AudioSource>();
        aud.Play();
        startMenu.SetActive(false);
    }

    public void ShowLeaderboard() {
        startMenu.SetActive(false);
        Time.timeScale = 0f;
        leaderMenu.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "End")
        {
            

            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            timerText.text = minutes + ":" + seconds;

            UpdateScores(t,timerText.text);

            ShowLeaderboard();

        }
    }
}
