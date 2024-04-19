using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UI;
using TMPro;

[System.Serializable]

    public enum SIDE { LEFT, MID, RIGHT }   // lanes

    public class Player : MonoBehaviour
    {


    public SIDE m_side = SIDE.MID;
    private bool swipeLeft, swipeRight, swipeUp, swipeDown;
    public Rigidbody rb;
    public Animator m_Animator;
    public GameObject gameOver;
    public float swipeSpeed;
    public float GameSpeed = 17;


    public float JumpPower = 7f;
    public float DownPower = 11f;

    public bool fromAir = false;

    public bool isGrounded;
    public bool isRolling;


    public AudioSource jumpSound;

    public AudioSource deathSound;

    public AudioSource fallingSound;

    public AudioSource landingSound;

    public AudioSource dodgeSound;

    public AudioSource rollingSound;

    public AudioSource main_sound;

    public TextMeshProUGUI  ScoreValue;

    public TextMeshProUGUI ScoreTextInGame;

    public Score score;



    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.SetBool("isRunning",false);

    }

   public void Play()
    {

            m_Animator.SetBool("isRunning", true);
    }

    bool isRunning()
    {
        return m_Animator.GetBool("isRunning");
    }

    public bool isDead()
    {
        return m_Animator.GetBool("isDead");
    }

    bool isRolling_()
    {
        isRolling = m_Animator.GetBool("isRolling");
        return isRolling;
    }

    void Update() {

        ChangeCollider();

        swipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        swipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        swipeUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space);
        swipeDown = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);

        if (isRunning() && !isRolling)
        {
            
            transform.position += new Vector3(0, 0, GameSpeed) * Time.deltaTime;


            if (swipeUp && isGrounded)
            {
                jumpSound.Play();
                rb.AddForce(0, JumpPower, 0, ForceMode.Impulse);
                m_Animator.Play("jump");

            }

            if (swipeDown && !isGrounded)
            {
                //rollingSound.Play();
                rb.AddForce(0, -250f, 0, ForceMode.Impulse);
                fromAir = true;
                m_Animator.SetBool("isRolling", true);


            } else if (swipeDown && isGrounded)
            {
                //roll

                rollingSound.Play();
                m_Animator.SetBool("isRolling", true);
                m_Animator.Play("Roll");
        
            }


            if (swipeLeft){

                dodgeSound.Play();

                if (m_side == SIDE.MID)
                {

                    rb.transform.DOMoveX(-3.4f, 0.20f);
                    m_side = SIDE.LEFT;
                        
                } else if (m_side == SIDE.RIGHT) {

                    if (!isDead())
                    {

                        rb.transform.DOMoveX(0, 0.20f);
                        m_side = SIDE.MID;
                    } else { 

                        m_side = SIDE.RIGHT;
                        m_Animator.Play("Dead");
                        
                    }

                }

            } else if (swipeRight){

                dodgeSound.Play();

                if (m_side == SIDE.MID)
                {

                rb.transform.DOMoveX(3.2f, 0.20f);
                m_side = SIDE.RIGHT;

                } else if (m_side == SIDE.LEFT) {

                    if (!isDead())
                        {
                        rb.transform.DOMoveX(0, 0.20f);
                        m_side = SIDE.MID;
                    } else {
                        m_side = SIDE.LEFT;
                        rb.transform.DOMoveX(-3.4f, 0.20f);
                        //m_Animator.Play("Dead");
                    }

                }
            }
        }
    }


    private void ChangeCollider()
    {
        if (m_Animator.GetBool("isRolling") == true)
        {
            rb.GetComponent<CapsuleCollider>().center = new Vector3(0, 2, 0);
            rb.GetComponent<CapsuleCollider>().height = 4;

        }
        else
        {
            rb.GetComponent<CapsuleCollider>().center = new Vector3(0, 4.85f, 0);
            rb.GetComponent<CapsuleCollider>().height = 9.61f;
        }
    }

    private void OnCollisionEnter(Collision collision){

        if (collision.gameObject.CompareTag("Road"))
        {
            isGrounded = true;
            if (fromAir)
            {
                m_Animator.Play("Roll");
                m_Animator.SetBool("isRolling", true);
                rollingSound.Play();
                fromAir = false;
                
            } else
            {
              //  m_Animator.Play("Running");
            }
           
        }


        if (collision.gameObject.CompareTag("Obstacle"))
        {
            m_Animator.SetBool("isRunning", false);
            Debug.Log("HIT OBSTACLE");
            m_Animator.Play("Death");
           // m_Animator.SetBool("isDead", true);
            gameOver.SetActive(true);
            deathSound.Play();
            fallingSound.Play();

            ScoreValue.text = "SCORE : " + Mathf.RoundToInt(score.getScore()).ToString();
        }

    }

    private void OnCollisionExit(Collision collision){

        if (collision.gameObject.CompareTag("Road"))
        {
            isGrounded = false;
        }

    }


}


