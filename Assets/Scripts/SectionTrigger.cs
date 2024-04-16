using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   
    public GameObject roadSection;
    public GameObject roadSectionType1;
    public GameObject roadSectionType2;
    public GameObject roadSectionType3;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {   
            Instantiate(roadSectionType1, new Vector3(0,-1, 0.4f), Quaternion.identity);
          //  Instantiate(roadSection, new Vector3(0, -1, 101.7f), Quaternion.identity);
        }

    }

}
