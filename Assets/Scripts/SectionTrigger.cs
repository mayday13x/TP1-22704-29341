using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject[] roadSection;
    public int zPos = 156;
    public int secNum;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            secNum = Random.Range(0, 3);
           // Instantiate(roadSection, roadSection[0].transform.position + new Vector3(0,0,54), Quaternion.identity);
            Instantiate(roadSection[2], new Vector3(0,0,zPos), Quaternion.identity);
            zPos += 156;
        }

    }

}