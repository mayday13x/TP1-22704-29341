using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoad : MonoBehaviour
{

    public GameObject road;
    public bool isActive = false;
    private Animator m_Animator;
    public float roadVelocity = -17;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        m_Animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

        if (Input.GetKeyDown(KeyCode.Tab))    // TAB -> Start on the menu
        {
            m_Animator.SetBool("isRunning", true);
            Debug.Log("isActive <-----------");
            isActive = true;

        }
        

        if (isActive && m_Animator.GetBool("isRunning"))
        {
            

             transform.position += new Vector3(0,0,roadVelocity) * Time.deltaTime;        // controla velocidade do jogo


            

             if (road.transform.position.z < -130f)
               {
                        Destroy(road);
               }
        }
       

    }

}
