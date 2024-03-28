using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 100f;
    public float sidewaysForce = 50f;


    void Start()
    {
        
    }

    void FixedUpdate()
    {

        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

    }
}
