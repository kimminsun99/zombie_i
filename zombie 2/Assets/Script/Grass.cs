using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    [SerializeField]
    private SphereCollider col; //구체 콜라이더

    //필요한 게임 오브젝트
    [SerializeField]
    private GameObject go_grass; // 기본 
    [SerializeField]
    private GameObject go_grass_item_prefab; // 풀 아이템


    // 풀 아이템 생성 개수
    [SerializeField]
    private int MaxCount;
    private int MinCount;


    private void Destruction()
    {

        col.enabled = false;

        for (int i = 0; i <= Mathf.Round(Random.Range(MinCount, MaxCount)); i++)
        {
            Instantiate(go_grass_item_prefab, go_grass.transform.position, Quaternion.identity);
        }

        Destroy(go_grass);

    }
}
