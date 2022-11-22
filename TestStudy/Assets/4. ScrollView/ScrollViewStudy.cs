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
            //만일 인벤토리 구현중 추가를 하고싶을경우, ScrollViewItemStudy 클래스에 List화 시켜서 Add()를 해주면된다.
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
