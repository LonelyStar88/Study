using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollViewStudy : MonoBehaviour
{
    [SerializeField]
    private Transform parents;
    [SerializeField]
    private GameObject itemObj;


    [SerializeField]
    private Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< 10; i++)
        {
            Sprite sprite = sprites[Random.Range(0, sprites.Length)];
            Instantiate(itemObj, parents).GetComponent<ScrollViewItemStudy>().Init(sprite, i);
            //���� �κ��丮 ������ �߰��� �ϰ�������, ScrollViewItemStudy Ŭ������ Listȭ ���Ѽ� Add()�� ���ָ�ȴ�.
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
