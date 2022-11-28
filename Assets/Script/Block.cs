using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Block : MonoBehaviour
{
    BlockSpawner blockSpawner;
        
    float oldTime = 0f;

    // �������� �ӵ�
    float speed = 3f;
    Vector3 myPos = Vector3.zero;    

    private void Awake()
    {
        blockSpawner = FindObjectOfType<BlockSpawner>();
    }
    void Start()
    {

    }

    bool isRotate = true; // ȸ�� üũ
    public bool isMove = true; // �̵� üũ

    void Update()
    {

        // Ű�Է��� ���� �ʾƵ� ��ĭ�� õõ�� �̵���
        //transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);

        // ���� �ð����� ����� �Ʒ��� �̵�
        if (Time.deltaTime - oldTime >= (Input.GetKey(KeyCode.DownArrow) ? 0.1f : 1))
        {
            transform.Translate(0, -1, 0, Space.World);
            oldTime = Time.time;
        }
        // �� �ٴ��� ����� ��ġ ����
        if (transform.position.z <= 1)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y, 1);
            isRotate = false;
            isMove = false;
        }

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            // ��� �̵� - �ϵ� ���
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }*/
        if (Input.GetKeyDown(KeyCode.UpArrow) && isRotate == true)
        {
            // ��� ȸ��
            //transform.eulerAngles += new Vector3(0, -90, 0);
            transform.RotateAround(transform.TransformPoint(myPos), Vector3.forward, 90);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)&&isMove == true)
        {
            // ��� �̵� - ��
            transform.position += Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)&& isMove==true)
        {
            // ��� �̵� - ��
            transform.position += Vector3.right;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "FInish")
        {
            Debug.Log("�ٴ��̴�!");
            blockSpawner.Delete(this.gameObject);
        }
    }

}
