using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScrollViewChatitem : MonoBehaviour
{
    [SerializeField]
    private TMP_Text chatTXT;
    // Start is called before the first frame update
    [SerializeField]
    private TMP_Text todayTXT;
    public ScrollViewChatitem SetText(string txt)
    {
        chatTXT.text = txt;
        return this;
    }
    public ScrollViewChatitem SetTodayTXT()
    {
        DateTime dt = DateTime.Now;

        todayTXT.text = string.Format("{0:00}½Ã {1:00}ºÐ", dt.Hour, dt.Minute);
        return this;
    }
  
}
