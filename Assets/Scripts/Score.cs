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

    public Text ScoreText;

    void Update()
    {
        Debug.Log(123);
      //  ScoreText.text = "Score: " + Score_;
        if (this.GetComponent<Animator>().GetBool("isRunning"))
        {
            totalTime += Time.deltaTime;
            Score_ += totalTime * ScoreRate;
            ScoreText.text = "Score: " + Mathf.Round(Score_);

        }

    }
}
