using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreGamePlay : MonoBehaviour
{
    public Text ScoreText;
    public int currentScore = 0;

	// Use this for initialization
	void Start ()
    {

        

	}
	
	// Update is called once per frame
	void Update ()
    {

        ScoreText.text = "Score\t : " + currentScore;

    }
}
