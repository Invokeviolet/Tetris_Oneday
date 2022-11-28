using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ǥ : 2���� �迭
// �� Ÿ�ϸ��� ������ ������ ���� : 1 �Ǵ� 0
// 
// ��ü ���� �ѹ� �׷��ְ�
// �� ���� ����ġ�� �Ǵ��ؼ� �浹�ϴ¸��� ������ 1�̳� 0���� üũ
//    
// ������� ��������ִ� �ָ� üũ
//
// ������ ��ġ�� ����� ����� �̸� �׷���� ��
//
// �� ������ ������ 
// �� ���� �־��ֱ� 


enum MapInfo
{
    EMPTY,
    FULL
}

// ���� y ���� �ٷ� ��� �ٸ� ť��� �浹�� ��ť���� y�� �� ���� ��� �浹���� �� �浹�� �� �� ��ü ����


public class MapSpawner : MonoBehaviour
{

    [SerializeField] MapCube mapCubePrefab;

    // ��ť�긦 ���� 2���� �迭
    MapCube[,] mapCubes;
    // ��ť�� ����
    MapCube MAPCUBE = null;
    // ��ť�� ��ġ��
    float[,] mapPos;
    // ��ť�� ��ü ũ��
    int height = 20;
    int width = 10;

    float xScale;
    float zScale;

    private void Awake()
    {        
        // mapCube ��ġ �ʱⰪ
        mapCubePrefab.transform.position = new Vector3(0f, 0f, 0f);
        // x, z �� ���� ������ �� �޾ƿ��� 
        xScale = mapCubePrefab.transform.localScale.x;
        zScale = mapCubePrefab.transform.localScale.z;

        mapCubes = new MapCube[height,width];
    }

    private void Start()
    {

        for (int i = 0; i < width; i++) // GetLength[0]
        {
            for (int j = 0; j < height; j++)
            {
                Vector3 vec3 = new Vector3(i * xScale, 0, j * zScale);
                Instantiate(mapCubePrefab, vec3, Quaternion.identity,this.transform);

                // mapCubes[j, i] = MAPCUBE;
            }
        }
    }
}
