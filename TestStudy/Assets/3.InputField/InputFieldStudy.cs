using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputFieldStudy : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputfield;
    // Start is called before the first frame update
  
    public void OnValueChangeEnd()
    {
        Debug.Log(_inputfield.text);
    }
    public void OnValueClear()
    {
        _inputfield.text = "";
    }
}
