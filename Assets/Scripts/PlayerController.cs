using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 100f;
    //public float sidewaysForce = 50f;

    bool Lane1 = false;
    bool Lane2 = true;
    bool Lane3 = false;

    public Transform Player;


    void Start()
    {
        
    }

    void Update()
    {

        rb.AddForce(0, 0, forwardForce * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.D) && Lane3 == false && Lane2 == false && Lane1 == true)
        {
            Lane2 = true;
            Lane1 = false;
            Lane3 = false;

            Vector3 cpos = Player.transform.position;
            cpos.x = -13.5f;
            Player.position = cpos;
            
            
        }
        else if (Input.GetKeyDown(KeyCode.A) && Lane2 == true)
        {
            Lane1 = true;
            Lane2 = false;
            Lane3 = false;

            Vector3 cpos = Player.transform.position;
            cpos.x = -20.7f;
            Player.position = cpos;

        }
        else if (Input.GetKeyDown(KeyCode.D) && Lane2 == true)
        {
            Lane3 = true;
            Lane1 = false;
            Lane2 = false;

            Vector3 cpos = Player.transform.position;
            cpos.x = -6.4f;
            Player.position = cpos;
        }
        else if (Input.GetKeyDown(KeyCode.A) && Lane1 == false && Lane3 == true)
        {
            Lane2 = true;
            Lane1 = false;
            Lane3 = false;

            Vector3 cpos = Player.transform.position;
            cpos.x = -13.5f;
            Player.position = cpos;
        }

    }
}
