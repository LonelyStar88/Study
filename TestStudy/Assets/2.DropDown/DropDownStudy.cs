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
        dropdown.ClearOptions(); //���� Ư�� value �ϳ��� ������� �Ҷ�, �� �Լ� ȣ����, ������ value���� ADD�Ѵ�
        
        List<TMP_Dropdown.OptionData> optiondatas = new List<TMP_Dropdown.OptionData>();
        for(int i = 0; i < strs.Length; i++)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
            data.text = strs[i];
            optiondatas.Add(data);
        }
        dropdown.AddOptions(optiondatas); // Dropdown value �߰�
       
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
