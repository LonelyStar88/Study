using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollViewTest : MonoBehaviour
{
    [SerializeField]
    private GameObject TimeCT;
    [SerializeField]
    private TMP_Text studyclocktext; //학습시간의 시간
    [SerializeField]
    private TMP_Text studyminutetext; //학습시간의 분
    [SerializeField]
    private TMP_Text presentdaytext; //접속일 수
    [SerializeField]
    private Image RotaIMG; //집중도 그래프
    [SerializeField]
    private Slider ProcessStudy; // 학습 진척도
    [SerializeField]
    private TMP_Text ProcessStudyText;
    [SerializeField]
    private Slider Accuracy; // 정답률
    [SerializeField]
    private TMP_Text AccuracyText;

    
    float studyclockcount = 0;
    float studyminutecount = 0;
    int presentday = 0;
    float MaxProcessStudy = 0;
    float NowProcessStudy = 0;
    float TmpProcessStudy = 0;
    float MaxAccuracy = 0;
    float NowAccuracy = 0;
    float TmpAccuracy = 0;
    float Concentration = 1;
    float Concentdir = 0f;
    float Tmpdir = 0f;
    float time = 0f;
    bool isOK = false;

    //float tempfloat = 0;
    //float time = 0;
    public Dictionary<string, int> SubjectDic = new Dictionary<string, int>();
    public List<Sprite> imgs = new List<Sprite>();
    //public Dictionary<>;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f; // 1초부터 9999시간까지의 랜덤
        MaxAccuracy = 100;
        MaxProcessStudy = 100;
        isOK = false;
        /*
        SubjectDic.Add("국어", Random.Range(1, 6));
        SubjectDic.Add("수학", Random.Range(1, 6));
        SubjectDic.Add("사회", Random.Range(1, 6));
        SubjectDic.Add("과학", Random.Range(1, 6));
        NowProcessStudy = Random.Range(1, 100);
        MaxProcessStudy = 100;
        NowAccuracy = Random.Range(1, 100);
        MaxAccuracy = 100;
        Updatatext();
        Present();
        */
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //RotaIMG.transform.rotation = Quaternion.Euler(0, 0, Tmpdir);
        Updatatext();
        if(TmpProcessStudy == NowProcessStudy && TmpAccuracy == NowAccuracy && Tmpdir == Concentdir)
        {
            isOK = true;
        }
        else
        {
            isOK = false;
        }
        
        if (time > 0.01f)
        {
            time = 0f;
            UpdateStudyValues();
            UpdateAccuracy();
            if (Tmpdir != Concentdir)
            {
                UpdateConcentdir();
            }
           

        }
    }

    public void OnClickSearch()
    {
        time = Random.Range(1, 35996400); // 1초부터 9999시간까지의 랜덤
        if (NowProcessStudy == 0)
        {
            NowProcessStudy = Random.Range(1, 100);
        }
        else
        {
            TmpProcessStudy = NowProcessStudy;
            NowProcessStudy = Random.Range(1, 100);
        }
        if (NowAccuracy == 0)
        {
            NowAccuracy = Random.Range(1, 100);
        }
        else
        {
            TmpAccuracy = NowAccuracy;
            NowAccuracy = Random.Range(1, 100);
        }
        AddSubject();
        NewValue();
        Present();
        Concentration = GetAverAccuracy();
        Debug.Log($"Concentration : {Concentration}");
        if (Concentdir == 0f)
        {
            Concentdir = ConCentrationDir(Concentration);
        }
        else
        {
            Tmpdir = Concentdir;
            Concentdir = ConCentrationDir(Concentration);
        }


    }
    void AddSubject()
    {
        if (!SubjectDic.ContainsKey("국어"))
        {
            SubjectDic.Add("국어", Random.Range(1, 6));
        }
        else
        {
            SubjectDic["국어"] = Random.Range(1, 6);
        }
        if (!SubjectDic.ContainsKey("수학"))
        {
            SubjectDic.Add("수학", Random.Range(1, 6));
        }
        else
        {
            SubjectDic["수학"] = Random.Range(1, 6);

        }
        if (!SubjectDic.ContainsKey("사회"))
        {
            SubjectDic.Add("사회", Random.Range(1, 6));
        }
        else
        {
            SubjectDic["사회"] = Random.Range(1, 6);
        }
        if (!SubjectDic.ContainsKey("과학"))
        {
            SubjectDic.Add("과학", Random.Range(1, 6));
        }
        else
        {
            SubjectDic["과학"] = Random.Range(1, 6);
        }
    }
    float GetAverAccuracy()
    {
        int[] Accaver = new int[4];
        int i = 0;
        int sum = 0;
        foreach (var item in SubjectDic)
        {
            Accaver[i] = item.Value;
            i++;
        }
        for (int j = 0; j < 4; j++)
        {
            sum += Accaver[j];
        }

        if (Accaver.Length > 0)
        {
            return sum / Accaver.Length;
        }
        else
        {
            return 0;
        }
    }
    void NewValue()
    {
        studyclockcount = (float)System.Math.Truncate(time / 3600f);
        studyclocktext.text = studyclockcount.ToString();
        studyminutecount = (float)System.Math.Truncate(time / 60f) - (studyclockcount * 60f);
        studyminutetext.text = studyminutecount.ToString();
    }
    void Updatatext()
    {
        ProcessStudy.value = TmpProcessStudy / MaxProcessStudy;
        ProcessStudyText.text = string.Format("{0:0%}", TmpProcessStudy / MaxProcessStudy);
        Accuracy.value = TmpAccuracy / MaxAccuracy;
        AccuracyText.text = string.Format("{0:0%}", TmpAccuracy / MaxAccuracy);
        RotaIMG.transform.rotation = Quaternion.Euler(0, 0, Tmpdir);

    }
    void Present()
    {
        presentday = (int)System.Math.Truncate(time / 86400f);
        presentdaytext.text = presentday.ToString();

    }
    float ConCentrationDir(float Cont)
    {

        switch (Cont)
        {
            case 1:
                {
                    Concentdir = 45f;
                    break;
                }
            case 2:
                {
                    Concentdir = 22.5f;
                    break;
                }
            case 3:
                {
                    Concentdir = 0f;
                    break;
                }
            case 4:
                {
                    Concentdir = -22.5f;
                    break;
                }
            case 5:
                {
                    Concentdir = -45f;
                    break;
                }
        }
        return Concentdir;
    }
    void UpdateStudyValues()
    {
        if (TmpProcessStudy != NowProcessStudy)
        {
            if (TmpProcessStudy < NowProcessStudy)
            {


                TmpProcessStudy++;

            }
            else if (TmpProcessStudy > NowProcessStudy)
            {

                TmpProcessStudy--;

            }

        }
    }
    void UpdateAccuracy()
    {
        if (TmpAccuracy != NowAccuracy)
        {
            if (TmpAccuracy < NowAccuracy)
            {


                TmpAccuracy++;

            }
            else if (TmpAccuracy > NowAccuracy)
            {

                TmpAccuracy--;

            }

        }
    }
    void UpdateConcentdir()
    {
        
            if(Tmpdir > Concentdir)
            {
                Tmpdir -= 0.5f;
            }
            else if(Tmpdir < Concentdir)
            {
                Tmpdir += 0.5f;
            }
        
    }
    /*
    IEnumerator Updatevalues()
    {
        if (!isOK)
        {
            yield return new WaitForSeconds(0.1f);
            UpdateStudyValues();
            UpdateAccuracy();
            if (Tmpdir != Concentdir)
            {
                UpdateConcentdir();
            }
            RotaIMG.transform.rotation = Quaternion.Euler(0, 0, Tmpdir);
            StartCoroutine("Updatevalues");
        }
        else
        {
            StopCoroutine("Updatavalues");
        }
    }*/
}
