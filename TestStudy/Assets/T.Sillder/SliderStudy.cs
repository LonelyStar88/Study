using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderStudy : MonoBehaviour
{
    [SerializeField]
    private TMP_Text slidertext;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Slider autoSlider;
    [SerializeField]
    private TMP_Text autoslidertext;

    int maxCount = 3;
    int Count = 0;
    // Start is called before the first frame update
    void Start()
    {
        autoSlider.value = 0;
        //Invoke("MainAutoSlider", 0f);
        InvokeRepeating("MainAutoSlider", 2f, 4f); //MainAutoSlider()를 2초 뒤에 4초마다 반복시킴
    }

    // Update is called once per frame
    void Update()
    {
        slidertext.text = string.Format("{0:0}%", slider.value * 100);
    }

    void MainAutoSlider()
    {
        if (Count > maxCount)
        {
            CancelInvoke("MainAutoSlider");
            return;
        }
        Count++;
            StartCoroutine("Autoslider");
        
    }

    IEnumerator Autoslider()
    {
        float max = 10;
        for(int i = 0; i < 10; i++)
        {
            
            autoslidertext.text = string.Format("기분좋은 향기가 솔솔~  {0:0}%", autoSlider.value * 100);
            autoSlider.value = i / max;
            yield return new WaitForSeconds(0.1f);
        }
        //yield return new WaitForSeconds(2f);
        //autoSlider.value = 0;
        //StartCoroutine("Autoslider");
    }
}
