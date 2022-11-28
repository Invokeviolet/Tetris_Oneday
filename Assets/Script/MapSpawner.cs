using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 맵좌표 : 2차원 배열
// 맵 타일마다 정보를 가지고 있음 : 1 또는 0
// 
// 전체 맵을 한번 그려주고
// 그 위에 블럭위치를 판단해서 충돌하는면의 정보를 1이나 0으로 체크
//    
// 블럭모양이 만들어져있는 애를 체크
//
// 떨어질 위치에 블록의 모습을 미리 그려줘야 함
//
// 맵 생성이 끝나면 
// 맵 정보 넣어주기 


enum MapInfo
{
    EMPTY,
    FULL
}

// 맵의 y 축을 줄로 세어서 다른 큐브와 충돌한 맵큐브의 y축 한 줄이 모두 충돌했을 때 충돌한 그 줄 전체 삭제


public class MapSpawner : MonoBehaviour
{

    [SerializeField] MapCube mapCubePrefab;

    // 맵큐브를 담을 2차원 배열
    MapCube[,] mapCubes;
    // 맵큐브 변수
    MapCube MAPCUBE = null;
    // 맵큐브 위치값
    float[,] mapPos;
    // 맵큐브 전체 크기
    int height = 20;
    int width = 10;

    float xScale;
    float zScale;

    private void Awake()
    {        
        // mapCube 위치 초기값
        mapCubePrefab.transform.position = new Vector3(0f, 0f, 0f);
        // x, z 의 로컬 스케일 값 받아오기 
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
