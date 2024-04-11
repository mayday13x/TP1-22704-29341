using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   
    public GameObject roadSection;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {   
            Instantiate(roadSection, new Vector3(0,0, 49.57f), Quaternion.identity);
        }

        if (other.gameObject.CompareTag("LeftSide") || other.gameObject.CompareTag("Mid") || other.gameObject.CompareTag("RightSide"))
        {
            
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Debug.Log("Collide : " + other.gameObject.tag);
            

        }




    }

}
