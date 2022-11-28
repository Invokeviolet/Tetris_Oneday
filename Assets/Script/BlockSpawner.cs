using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ó�� ���� ���� ��ư�� ������ 3�� �ڿ� �����´�.
// �������� ť��� ����
// ���� �ϳ��� �����;��ϰ�,
// ���ο� ���� FinishLine�� ����� �� ���� �����Ǿ� �����´�.

public class BlockSpawner : MonoBehaviour
{
    // 6 ������ ��
    [SerializeField] Block[] blockPrefab;
    
    // ������ ����
    int count = 100;

    // �� ����
    Block block;

    // ���� �����Ǵ� ��ġ
    Vector3 BPos;

    // �� �������� �ϳ��� ��Ҵٰ� ��������
    List<Block> BlockList = new List<Block>();

    private void Awake()
    {

    }

    void Start()
    {
        // �ڽ��ݶ��̴� ��������

        BPos = new Vector3(5f, 1f, 25); // ���� �����Ǵ� ��ġ�� ��� �߾�

        // ������ ��� ������ŭ ����
        for (int i = 0; i < count; ++i)
        {
            // ���� + ������ġ �����ϴ� �Լ�
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
            // ���� ����(�ִ� �����ձ��̸�ŭ ���� ��)
            int randomNum = Random.Range(0, blockPrefab.Length);
            // ���ο� ������ ����
            Block RandomBlock = blockPrefab[randomNum];

            // ����
            block = Instantiate(RandomBlock, BPos, Quaternion.identity);
            // ����Ʈ�� ���
            // BlockList.Add(block);

            yield return new WaitUntil(() => block.isMove == false); // ������ �����ϸ� ���� �� ����
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
