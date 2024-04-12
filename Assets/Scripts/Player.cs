using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using UnityEditor.Experimental.GraphView;

[System.Serializable]

    public enum SIDE { LEFT, MID, RIGHT }   // lanes

    public class Player : MonoBehaviour
    {


    public SIDE m_side = SIDE.MID;
    private bool swipeLeft, swipeRight, swipeUp, swipeDown;
    public Rigidbody rb;
    public Animator m_Animator;
    public float swipeSpeed;
    public CapsuleCollider[] capsuleColliders;

    public float JumpPower = 7f;
    public float DownPower = 11f;

    public bool fromAir = false;

    public bool isGrounded;
    public bool inRool;


    void Start()
    {
        m_Animator = GetComponent<Animator>();

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
                rb.AddForce(0, -250f, 0, ForceMode.Impulse);
                fromAir = true;
  

            } else if (swipeDown && isGrounded)
            {
                //roll

                if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Rool"))
                {
                    // rb.GetComponents<CapsuleCollider>()[0].enabled = false;
                    Debug.Log("rolling");
                }
                else
                {
                    Debug.Log("notRolling");
                    // rb.GetComponents<CapsuleCollider>()[1].enabled = true;
                }

                m_Animator.Play("Roll");
            }

            if (swipeLeft){

                if (m_side == SIDE.MID)
                {

                    //rb.AddForce(-swipeSpeed, 0, 0, ForceMode.Impulse);
                    rb.transform.DOMoveX(-3, 0.1f);
                    m_side = SIDE.LEFT;
                        
                } else if (m_side == SIDE.RIGHT) {

                    rb.transform.DOMoveX(0, 0.1f);
                    //rb.AddForce(-swipeSpeed, 0, 0, ForceMode.Impulse);
                    m_side = SIDE.MID;

                }

            }else if (swipeRight){

                if (m_side == SIDE.MID)
                {
                //rb.AddForce(swipeSpeed, 0, 0, ForceMode.Impulse);
                rb.transform.DOMoveX(3, 0.1f);
                m_side = SIDE.RIGHT;

                } else if (m_side == SIDE.LEFT) {

                    //rb.AddForce(swipeSpeed, 0, 0, ForceMode.Impulse);
                    rb.transform.DOMoveX(0, 0.1f);
                    m_side = SIDE.MID;

                }
            }
        }
    }


   

    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Road"))
        {
            isGrounded = true;
            if (fromAir)
            {
                m_Animator.Play("Roll");
                fromAir = false;
                
            } else
            {
                m_Animator.Play("Running");
            }
           
        }
         
    }

    private void OnCollisionExit(Collision collision){

        if (collision.gameObject.CompareTag("Road"))
        {
            isGrounded = false;
          //  m_Animator.Play("jump");
        }
    }
}


