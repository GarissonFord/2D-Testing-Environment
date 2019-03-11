using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float currentScore;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisplayScore()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }

    public void UpdateScore(int multiplier)
    {
        currentScore += 100 * multiplier;
        DisplayScore();
    }
}
