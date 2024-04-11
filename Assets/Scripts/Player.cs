using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public enum SIDE { LEFT, MID, RIGHT }   // lanes

public class Player : MonoBehaviour
{


    public SIDE m_side = SIDE.MID;
    float newXPos = 0f;             // posição no X
    public float XValue;
    public bool swipeLeft, swipeRight, swipeUp, swipeDown;
    public Rigidbody rb;
    public Animator m_Animator;
    private float x;
    public float swipeSpeed;

    public float JumpPower = 7f;
    private float y;

    public bool isGrounded;
    public bool inRool;

    /**********************************/
    public Transform startMarker;
    public Transform endMarker;
    public Transform player;


    public float speed;
    public float distance;
    private float xStartPosition;

    float time = 0;

    void Start()
    {
        //transform.position = Vector3.zero;
        m_Animator = GetComponent<Animator>();
        player = GetComponent<Transform>();
        xStartPosition = rb.position.x;

    }

    bool isRunning()
    {
        return m_Animator.GetBool("isRunning");
    }

    void Update() 
        {

            swipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
            swipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
            swipeUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
            swipeDown = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);

        //testing

        moveLeft();


        if (isRunning())
            {
            
                if (swipeUp && isGrounded)
                {
                    rb.AddForce(0, JumpPower, 0, ForceMode.Impulse);
                    m_Animator.Play("jump");

                }

                if (swipeLeft)
                {
                    if (m_side == SIDE.MID)
                    {
                    
                      //  rb.transform.Translate(startMarker.transform.position, new Space());
                        rb.GetComponent<Animator>().Play("SwipeLeft");
                        

                    }
                    else if (m_side == SIDE.RIGHT)
                    {

                        

                    }
                }
                else if (swipeRight)
                {
                    if (m_side == SIDE.MID)
                    {
                       

                    }
                    else if (m_side == SIDE.LEFT)
                    {

                       

                    }
                }
            }
        }


            public void moveLeft() {
                    if (rb.transform.position.x > -5)
                    {
                         rb.transform.position += new Vector3(-5f * Time.deltaTime, 0,0);
                         rb.GetComponent<Animator>().Play("SwipeLeft");
                    }
            }


            private void OnCollisionEnter(Collision collision)
            {
                isGrounded = true;
            }

            private void OnCollisionExit(Collision collision)
            {
                isGrounded = false;
            }

        }


