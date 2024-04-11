    using System.Collections;
    using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

    [System.Serializable]

    public enum SIDE { LEFT, MID, RIGHT }   // lanes

    public class Player : MonoBehaviour
    {


    public SIDE m_side = SIDE.MID;
    private bool swipeLeft, swipeRight, swipeUp, swipeDown;
    public Rigidbody rb;
    public Animator m_Animator;
    public float swipeSpeed;

    public float JumpPower = 7f;
    public float DownPower = 11f;

    public bool isGrounded;
    public bool inRool;

    /**********************************/
    public Transform Left;
    public Transform Right;
    public Transform Mid;


    public float speed;
    public float distance;
    private float xStartPosition;


    void Start()
    {
        //transform.position = Vector3.zero;
        m_Animator = GetComponent<Animator>();
        xStartPosition = rb.position.x;

    }

    bool isRunning()
    {
        return m_Animator.GetBool("isRunning");
    }

    void Update() {

        swipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        swipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        swipeUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        swipeDown = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);


    if (isRunning())
        {
            
            if (swipeUp && isGrounded)
            {
                rb.AddForce(0, JumpPower, 0, ForceMode.Impulse);
                m_Animator.Play("jump");

            }

            if (swipeDown && !isGrounded)
            {
                rb.AddForce(0, -DownPower, 0, ForceMode.Impulse);
            } else if (swipeDown && isGrounded)
            {
                //roll
            }

            if (swipeLeft){

                if (m_side == SIDE.MID)
                {
                   
                    rb.AddForce(-swipeSpeed, 0, 0, ForceMode.Impulse);
                    m_side = SIDE.LEFT;
                        
                } else if (m_side == SIDE.RIGHT) {

                    rb.AddForce(-swipeSpeed, 0, 0, ForceMode.Impulse);
                    m_side = SIDE.MID;

                }

                }
                else if (swipeRight)
                {
                    if (m_side == SIDE.MID)
                    {
                        rb.AddForce(swipeSpeed, 0, 0, ForceMode.Impulse);
                        m_side = SIDE.RIGHT;

                    } else if (m_side == SIDE.LEFT) {

                        rb.AddForce(swipeSpeed, 0, 0, ForceMode.Impulse);
                        m_side = SIDE.MID;

                     }
                }
            }
        }


    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Road"))
        {
            isGrounded = true;
            m_Animator.Play("Running");
        }
         
    }

    private void OnCollisionExit(Collision collision){

        if (collision.gameObject.CompareTag("Road"))
        {
            isGrounded = false;
            m_Animator.Play("jump");
        }
    }
}


