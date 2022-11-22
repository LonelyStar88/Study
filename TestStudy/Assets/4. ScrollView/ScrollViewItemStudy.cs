using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollViewItemStudy : MonoBehaviour
{
    [SerializeField]
    private Image iconImage;
    [SerializeField]
    private TMP_Text tmpTxt;


    public void Init(Sprite sprite, int index)
    {
        iconImage.sprite = sprite;
        tmpTxt.text = index.ToString();
        
    }
}
