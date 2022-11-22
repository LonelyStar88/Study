using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDownStudy : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown dropdown;

    string[] strs = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K" };
    // Start is called before the first frame update
    void Start()
    {
        dropdown.ClearOptions(); //만일 특정 value 하나만 지우고자 할때, 이 함수 호출후, 나머지 value들은 ADD한다
        
        List<TMP_Dropdown.OptionData> optiondatas = new List<TMP_Dropdown.OptionData>();
        for(int i = 0; i < strs.Length; i++)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
            data.text = strs[i];
            optiondatas.Add(data);
        }
        dropdown.AddOptions(optiondatas); // Dropdown value 추가
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnValueChange()
    {
        Debug.Log(strs[dropdown.value]);
    }
}
