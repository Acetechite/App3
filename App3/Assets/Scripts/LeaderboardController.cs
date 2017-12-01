using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardController : MonoBehaviour {

    private float first;
    private float second;
    private float third;

    public GameObject firstG;
    public GameObject secondG;
    public GameObject thirdG;

    private Text firstT;
    private Text secondT;
    private Text thirdT;

	// Use this for initialization
	void Start () {
        firstT = firstG.GetComponent<Text>();
        secondT = secondG.GetComponent<Text>();
        thirdT = thirdT.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateScores(float newScore, string score) {
        if (first < newScore)
        {
            third = second; thirdT.text = secondT.text;
            second = first; secondT.text = firstT.text;
            first = newScore; firstT.text = score;
        }
        else if (second < newScore) {
            third = second; thirdT.text = secondT.text;
            second = newScore; secondT.text = score;
        }
        else if (third<newScore) {
            third = newScore; thirdT.text = score;
        }
        
    }
}
