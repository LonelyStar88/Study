using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageStudy : MonoBehaviour
{
    [SerializeField]
    private Image HPimage;
    [SerializeField]
    private Image MPimage;
    [SerializeField]
    private Image skillDelayImage;
    [SerializeField]
    private TMP_Text skillDelayText;

    float curHP = 100;
    float maxHP = 100;

    float curMP = 50;
    float maxMP = 50;

    const float addHP = 10;
    //const float addMP = 5;

    //float time = 0f;
    float curSkillTime = 0f;
    float maxSkillTime = 3f;

    int level = 1;
    // Start is called before the first frame update
    void Start()
    {
        HPimage.fillAmount = curHP / maxHP;
        MPimage.fillAmount = curMP / maxMP;
        skillDelayImage.fillAmount = 0f;
        skillDelayText.enabled = false;
        //skillDelayText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        HPimage.fillAmount = curHP / maxHP;
        MPimage.fillAmount = curMP / maxMP;
        /*if (Input.GetKeyDown(KeyCode.F1))
        {
            curHP += addHP;
        }*/
        if (Input.GetKeyDown(KeyCode.F2))
        {
            curHP -= addHP;
        }
        
        if (Input.GetKeyDown(KeyCode.F3))
        {
            
            if (curMP <= 0)
            {
                curMP = 0;
            }
            else
            {
                curMP -= 30;
            }
            StopCoroutine("AutoMPRecovery");
            StartCoroutine("AutoMPRecovery");
           // StartCoroutine(AutoMPRecovery());
        }
        
        if (Input.GetKeyDown(KeyCode.F4))
        {
            if(curSkillTime == 0f)
            {
                curHP += addHP;
                skillDelayImage.fillAmount = 1f;
                StartCoroutine(SkillDelayRecovery());
            }
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            level++;
            maxHP += Random.Range(10, 15);
            maxMP += Random.Range(5, 10);
            curHP = maxHP;
            curMP = maxMP;
            Debug.Log($"LV : {level} / HP : {maxHP} / MP : {maxMP}");
        }
        /*
        if(curMP < maxMP)
        {
            time += Time.deltaTime;
            if(time > 0.1f)
            {
                time = 0f;
                curMP += 0.5f;
            }
        }*/

    }
    IEnumerator AutoMPRecovery()
    {
        for(int i = 0; i < maxHP; i++)
        {
            if(curMP < maxMP)
            {
                curMP += 2;
                MPimage.fillAmount = curMP / maxMP;
            }
            yield return new WaitForSeconds(0.2f);
        }
        //yield return null;
    }
    // 1 > 0 값을 이동
    IEnumerator SkillDelayRecovery()
    {
        float time = 3f;
        skillDelayImage.fillAmount = 1f;
        skillDelayText.text = time.ToString();
        skillDelayText.enabled = true;
        curSkillTime = maxSkillTime;
        
        while (curSkillTime >= 0)
        {
            skillDelayText.text = string.Format("{0:0}", time);
            curSkillTime -= 0.1f;
            skillDelayImage.fillAmount = curSkillTime / maxSkillTime;
            time -= 0.1f;
            yield return new WaitForSeconds(0.1f);
            
        }
        curSkillTime = 0f;
        skillDelayImage.fillAmount = 0f;
        skillDelayText.enabled = false;
        //yield return null;
    }
}
