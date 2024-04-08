using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoad : MonoBehaviour
{

    public GameObject road;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += new Vector3(0,0,-17) * Time.deltaTime;        // controla velocidade do jogo

        if (road.transform.position.z < -60f)
        {
            Destroy(road);
        }

    }

}
