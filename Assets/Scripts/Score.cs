using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    float totalTime;
    float ScoreRate = 0.03f;
    public float Score_;

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        Score_ += totalTime * ScoreRate;
    }
}
