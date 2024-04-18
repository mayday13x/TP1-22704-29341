using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    float totalTime;
    float ScoreRate = 0.03f;
    public float Score_;
  //  public Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Animator>().GetBool("isRunning"))
        {
            totalTime += Time.deltaTime;
            Score_ += totalTime * ScoreRate;
        }

    }
}
