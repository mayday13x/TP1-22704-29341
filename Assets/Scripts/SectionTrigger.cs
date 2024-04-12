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
            Instantiate(roadSection, new Vector3(0,0, 36.61f), Quaternion.identity);
        }

    }

}
