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
    private CharacterController m_char;
    private Animator m_Animator;
    private float x;
    public float swipeSpeed;

    public float JumpPower = 7f;
    private float y;

    public bool inJump;
    public bool inRool;

    void Start()
    {
        transform.position = Vector3.zero;
        m_Animator = GetComponent<Animator>();
        m_char = GetComponent<CharacterController>();
        
    }

    bool isRunning()
    {
        return m_Animator.GetBool("isRunning");
    }
    
    void Update()
    {
        
        swipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        swipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        swipeUp= Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        swipeDown= Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);

        //testing

        if (Input.GetKeyDown(KeyCode.Tab))    // TAB -> Start on the menu
        {
            m_Animator.SetBool("isRunning", true);
            
        }

        Jump();

        if (isRunning())
        {

            if (swipeLeft)
            {
                if (m_side == SIDE.MID)
                {
                    newXPos = -XValue;
                    m_side = SIDE.LEFT;
                    //m_Animator.Play("SwipeRight");

                }
                else if (m_side == SIDE.RIGHT)
                {

                    newXPos = 0;
                    m_side = SIDE.MID;
                    //m_Animator.Play("SwipeRight");

                }
            }
            else if (swipeRight)
            {
                if (m_side == SIDE.MID)
                {
                    newXPos = XValue;
                    m_side = SIDE.RIGHT;
                    // m_Animator.Play("SwipeLeft");

                }
                else if (m_side == SIDE.LEFT)
                {

                    newXPos = 0;
                    m_side = SIDE.MID;
                    // m_Animator.Play("SwipeLeft");

                }
            }
        }

        Vector3 moveVector = new Vector3(x - transform.position.x,y * Time.deltaTime,0);
        x = Mathf.Lerp(x, newXPos, Time.deltaTime * swipeSpeed);
        m_char.Move(moveVector);


    }

    public void Jump()
    {
        if (m_char.isGrounded)
        {

            if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("falling"))
            {
                m_Animator.Play("landing");
                inJump = false;
            }

            if (swipeUp)
            {

                y = JumpPower;
                m_Animator.CrossFadeInFixedTime("jump", 0.1f);
                //m_Animator.Play("jump");
                inJump = true;
            }

        } else
        {

            y -= JumpPower * 3 * Time.deltaTime;
            if(m_char.velocity.y < -0.1f)
            {
             //  m_Animator.Play("falling");
            }
          

        }
    }

}
