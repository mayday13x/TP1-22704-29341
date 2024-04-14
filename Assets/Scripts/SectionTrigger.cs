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
            Instantiate(roadSection, new Vector3(0,-1, 49.8f), Quaternion.identity);
          //  Instantiate(roadSection, new Vector3(0, -1, 101.7f), Quaternion.identity);
        }

    }

}
