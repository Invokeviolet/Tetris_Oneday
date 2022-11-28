using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 바닥까지 직진으로 내려옴

        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // 오른쪽 방향으로 회전
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // 왼쪽 이동
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // 오른쪽 이동
        }

    }
}
