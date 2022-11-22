using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IconControl : MonoBehaviour
{
    [SerializeField]
    private Image[] images;
    [SerializeField]
    private GameObject gamemanager;
    [SerializeField]
    public string key;


    int icon = 0;
    
    // Start is called before the first frame update
    void Start() //기본값 다 1
    {
        for(int i = 0; i < images.Length; i++)
        {
            if(i == 0)
            {
                images[i].enabled = true;
            }
            else
            {
                images[i].enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetConcentration();
        viewicon(icon, images);
    }
    void GetConcentration()
    {
        
        if(gamemanager.GetComponent<ScrollViewTest>().SubjectDic.ContainsKey(key))
        {
            icon = gamemanager.GetComponent<ScrollViewTest>().SubjectDic[key];
        }
    }
    void viewicon(int ic, Image[] img)
    {
        for(int i = 0; i < img.Length; i++)
        {
            img[i].enabled = false;
        }
        img[ic - 1].enabled = true;
    }
}
