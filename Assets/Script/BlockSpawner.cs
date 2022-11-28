using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 처음 블럭은 시작 버튼을 누르면 3초 뒤에 내려온다.
// 떨어지는 큐브는 랜덤
// 블럭은 하나씩 내려와야하고,
// 새로운 블럭은 FinishLine에 닿았을 때 새로 생성되어 내려온다.

public class BlockSpawner : MonoBehaviour
{
    // 6 종류의 블럭
    [SerializeField] Block[] blockPrefab;
    
    // 생성할 갯수
    int count = 100;

    // 블럭 변수
    Block block;

    // 블럭이 생성되는 위치
    Vector3 BPos;

    // 블럭 종류별로 하나씩 담았다가 꺼내야함
    List<Block> BlockList = new List<Block>();

    private void Awake()
    {

    }

    void Start()
    {
        // 박스콜라이더 가져오기

        BPos = new Vector3(5f, 1f, 25); // 블럭이 생성되는 위치는 상단 중앙

        // 생성할 블록 갯수만큼 생성
        for (int i = 0; i < count; ++i)
        {
            // 생성 + 스폰위치 포함하는 함수
            StartCoroutine(Spawn());
        }

    }

    private void Update()
    {

    }

    
    IEnumerator Spawn()
    {
        while (true) 
        {
            // 랜덤 변수(최대 프리팹길이만큼 받을 것)
            int randomNum = Random.Range(0, blockPrefab.Length);
            // 새로운 프리팹 변수
            Block RandomBlock = blockPrefab[randomNum];

            // 생성
            block = Instantiate(RandomBlock, BPos, Quaternion.identity);
            // 리스트에 담기
            // BlockList.Add(block);

            yield return new WaitUntil(() => block.isMove == false); // 조건이 충족하면 다음 줄 실행
            block.isMove = true;
        }
        
    }

    // 
    public void Delete(GameObject obj)
    {
        Destroy(obj);
        BlockList.RemoveAt(0);
    }

}
