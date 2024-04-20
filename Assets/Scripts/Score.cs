using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    float totalTime;
    float ScoreRate = 0.01f;
    public float Score_;
    public Player player;
    public TextMeshProUGUI ScoreText;


    void Update()
    {

        if (GetComponent<Animator>().GetBool("isRunning"))
        {
            totalTime += Time.deltaTime;
            Score_ += totalTime * ScoreRate;
            ScoreText.text = Mathf.Round(Score_).ToString();
        }

        if (player.isDead())
        {
            ScoreText.enabled = false;
        }

    }

    public float getScore()
    {
        return Score_;
    }

    public void setScore(float score)
    {
        Score_ = score;
    }

}