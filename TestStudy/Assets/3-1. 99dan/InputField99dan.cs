using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputField99dan : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField input1;
    [SerializeField]
    private TMP_InputField input2;
    [SerializeField]
    private TMP_Text resulttext;
    [SerializeField]
    private TMP_Text Errortext;
    [SerializeField]
    private TMP_Text Errortext2;
    [SerializeField]
    private TMP_Text Errortext3;
    int fir = 0;
    int sec = 0;
    //int result = 0;
    bool checkint = false;
    //bool isOK = false;
    //string[] resultstr = new string[9];
    //Dictionary<int, string[]> resultlist = new Dictionary<int, string[]>();
    // Start is called before the first frame update
    void Start()
    {
        fir = 0;
        sec = 0;
        Errortext.enabled = false;
        Errortext2.enabled = false;
        Errortext3.enabled = false;
        //isOK = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnButtonResult()
    {
        if (fir != 0 && sec != 0 && fir < sec)

        {
            //Errortext3.enabled = false;
            for (int i = 1; i <= 9; i++)
            {
                for (int j = fir; j <= sec; j++)
                {
                    resulttext.text += $"{j} X {i} = {j * i} \t";

                }

                resulttext.text += "\n";
            }
            //Onreset();
        }
        else
        {
            if(fir >= sec)
            {
                Errortext.enabled = true;
                //Errortext3.enabled = true;
            }
            else
            {
                if(fir == 0)
                {
                    Errortext.enabled = true;
                }
                else if(sec == 0)
                {
                    Errortext2.enabled = true;
                }
            }
        }
     
       
    }
    public bool OnCheckint(string str)
    {
        if(int.Parse(str) > 0)
        {
            checkint = true;
        }
        else
        {
            checkint = false;
        }
        return checkint;
    }
    public void OnExposeError()
    {
        Errortext.enabled = true;
    }
    public void OnInputCheck1()
    {
        resulttext.text = "";
        Errortext.enabled = false;
        if (int.Parse(input1.text) > 0)
        {
            fir = int.Parse(input1.text);
        }
        Debug.Log($"First : {fir}");
        
    }
    public void OnInputCheck2()
    {
        Errortext2.enabled = false;
        Errortext3.enabled = false;
        if (int.Parse(input2.text) > fir)
        {
            sec = int.Parse(input2.text);
            Debug.Log($"Second : {sec}");
            // isOK = true;
        }
        else
        {
            Errortext2.enabled = true;
            input2.text = "";

        }
    }

    public void Onreset()
    {
        fir = 0;
        sec = 0;
        Errortext.enabled = false;
        Errortext2.enabled = false;
        Errortext3.enabled = false;
        //isOK = false;
        resulttext.text = "";
    }
  
}
