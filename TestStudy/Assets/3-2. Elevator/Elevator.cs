using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    private TMP_Text result_text;

   // Dictionary<int, int> Elelog = new Dictionary<int, int>();
   // int[] Elevatorlog = new int[10];
    float Deffloor = 0;
    float nowfloor = 1;
    bool isArrive = false;
    //bool isMoving = false;
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Deffloor = 0;
        nowfloor = 1;
        result_text.text = "1F";
        isArrive = false;
        //isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        result_text.text = string.Format("{0:0}F", nowfloor);
        if (time > 1f)
        {
            time = 0f;
            if(isArrive)
            {
                //Debug.Log("Arrived");
            }
            else
            {
                Moving();
            }
        }
    }

   public void OnPressBtn(float flo)
    {
        Deffloor = flo;
        isArrive = false;
           
    }
   
  

    void Moving()
    {
        
        if(nowfloor < Deffloor)
        {
            
            nowfloor++;
            
            Debug.Log("Upstair");
        }
        else
        {
            if(nowfloor > Deffloor)
            {
               
                nowfloor--;
                
                Debug.Log("Downstair");
            }
            else
            {
                
                
                isArrive = true;
                Debug.Log("Arrived");
            }
        }
    }
 
}
