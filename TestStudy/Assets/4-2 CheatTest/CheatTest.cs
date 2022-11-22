using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheatTest : MonoBehaviour
{
    [SerializeField]
    private Transform parent;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private TMP_InputField inputField;

    bool istrans = false;
    // Start is called before the first frame update
    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            //OnInputEnd();
            istrans = true;
        }*/
        if(istrans)
        {
            OnInputEnd();
            istrans = false;
        }
    }

    public void OnClickBtn()
    {
        istrans = true;
    }
    public void OnInputEnd()
    {
        GameObject obj = Instantiate(prefab, parent);

            obj.GetComponent<ScrollViewChatitem>()
            .SetText(inputField.text)
            .SetTodayTXT();

        obj.transform.SetAsFirstSibling();

        inputField.text = "";
    }
    /*
    public void OnEnterKey()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            inputField.text += "\n";
        }
    }*/
}
