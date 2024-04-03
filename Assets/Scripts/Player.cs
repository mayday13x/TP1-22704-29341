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
    public bool swipeLeft, swipeRight;
    private CharacterController m_char;
    private Animator m_Animator;
    private float x;
    public float swipeSpeed;

    public AudioSource aud;
    public AudioClip clip;

    void Start()
    {
        transform.position = Vector3.zero;
        m_Animator = GetComponent<Animator>();
        m_char = GetComponent<CharacterController>();
        aud = GetComponent<AudioSource>();
        
    }

    bool isRunning()
    {
        return m_Animator.GetBool("isRunning");
    }
    
    void Update()
    {
        
        swipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        swipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);

        //testing

        if (Input.GetKeyDown(KeyCode.Tab))    // TAB -> Start on the menu
        {
            m_Animator.SetBool("isRunning", true);
            
        }

        if (isRunning())
        {

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
            {

                m_Animator.Play("jump");
     
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {

                m_Animator.Play("roll");
                aud.Play();
            }

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

        x = Mathf.Lerp(x, newXPos, Time.deltaTime * swipeSpeed);
        m_char.Move((x - transform.position.x) * Vector3.right);

    }
}
