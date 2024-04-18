using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject[] roadSection;
    public int zPos = 159;
    public int secNum;

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(Random.Range(0,2));
        if (other.gameObject.CompareTag("Trigger"))
        {   
           // Instantiate(roadSection, roadSection[0].transform.position + new Vector3(0,0,54), Quaternion.identity);
            Instantiate(roadSection[1], new Vector3(0,0,zPos), Quaternion.identity);
            zPos += 159;
        }

    }

}
