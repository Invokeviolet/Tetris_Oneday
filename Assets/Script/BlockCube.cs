using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x <= 0)
        {
            transform.position = new Vector3(0,transform.position.y, transform.position.z);
        }
        if (transform.position.x >= 9)
        {
            transform.position = new Vector3(9, transform.position.y, transform.position.z);
        }
    }
}
