using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Block : MonoBehaviour
{
    BlockSpawner blockSpawner;
        
    float oldTime = 0f;

    // 내려오는 속도
    float speed = 3f;
    Vector3 myPos = Vector3.zero;    

    private void Awake()
    {
        blockSpawner = FindObjectOfType<BlockSpawner>();
    }
    void Start()
    {

    }

    bool isRotate = true; // 회전 체크
    public bool isMove = true; // 이동 체크

    void Update()
    {

        // 키입력을 받지 않아도 한칸씩 천천히 이동함
        //transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);

        // 일정 시간마다 블록을 아래로 이동
        if (Time.deltaTime - oldTime >= (Input.GetKey(KeyCode.DownArrow) ? 0.1f : 1))
        {
            transform.Translate(0, -1, 0, Space.World);
            oldTime = Time.time;
        }
        // 맵 바닥을 벗어나면 위치 고정
        if (transform.position.z <= 1)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y, 1);
            isRotate = false;
            isMove = false;
        }

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            // 블록 이동 - 하드 드랍
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }*/
        if (Input.GetKeyDown(KeyCode.UpArrow) && isRotate == true)
        {
            // 블록 회전
            //transform.eulerAngles += new Vector3(0, -90, 0);
            transform.RotateAround(transform.TransformPoint(myPos), Vector3.forward, 90);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)&&isMove == true)
        {
            // 블록 이동 - 왼
            transform.position += Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)&& isMove==true)
        {
            // 블록 이동 - 오
            transform.position += Vector3.right;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "FInish")
        {
            Debug.Log("바닥이다!");
            blockSpawner.Delete(this.gameObject);
        }
    }

}
