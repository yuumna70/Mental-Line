using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using GoogleMobileAds.Api;

public class MainManager : MonoBehaviour
{
    // ����
    public GameObject SettingView;
    public GameObject HelpView;

    // ����
    public GameObject EscapeView;

    // ����
    [SerializeField] AudioSource music;
    public GameObject soundOn;
    public GameObject soundOff;
    public GameObject sfxOn;
    public GameObject sfxOff;
    public GameObject shakeOn;
    public GameObject shakeOff;

    // ���Ĺ� ������� ����
    public Text Dopamine;
    public Text Serotonin;
    private int D;
    private int DD;
    private int S;
    private int SS;

    // �⼮üũ �� / ��ư
    public Button[] DayBtns;
    public GameObject DayView;
    public GameObject View1;
    public GameObject View2;
    // �⼮üũ �Ϸ� �̹���
    public GameObject[] Btnimg;

    // *���� ��
    public GameObject Views1;
    public GameObject Views2;
    public GameObject Views3;
    public GameObject Views4;
    public GameObject Views5;
    public GameObject Views6;
    public GameObject Views7;

    // ����
    public AudioSource click;

    // day = ���� 00��
    DateTime day = DateTime.Today.AddDays(1);
    TimeSpan ts = new TimeSpan(10, 0, 0);
    DateTime Now = DateTime.Now;

    // ������ ����
    private RewardedAd rewardedAd;
    private RewardedAd rewardedAd2;
    private RewardedAd rewardedAd3;
    private RewardedAd rewardedAd4;
    private RewardedAd rewardedAd5;
    private RewardedAd rewardedAd6;
    private RewardedAd rewardedAd7;
    public Canvas myCan;

    // ���� ���� ID
    private string rewardID; // = "ca-app-pub-4101740431730513/5910670487";

    private bool rewarded = false;
    private bool rewarded2 = false;
    private bool rewarded3 = false;
    private bool rewarded4 = false;
    private bool rewarded5 = false;
    private bool rewarded6 = false;
    private bool rewarded7 = false;

    DateTime dtNowTime = DateTime.Now;

    // �⼮üũ ������ ���� 
    // ������ ����
    public void UserChoseToWatchAd()
    {
        click.Play();
        if (PlayerPrefs.GetInt("Noads") == 1)
        {
            PlayerPrefs.SetInt("Serotonin", S + 100);
            PlayerPrefs.SetInt("SSerotonin", SS + 100);
            Views1.SetActive(false);
            PlayerPrefs.SetInt("Day1", 1);
        }
        else if (PlayerPrefs.GetInt("Noads") == 0)
        {
            if (rewardedAd.IsLoaded()) // ���� �ε� �Ǿ��� ��
            {
                rewardedAd.Show(); // ���� �����ֱ�
                myCan.sortingOrder = -1;
            }
        }
    }

    public void CreateAndLoadRewardedAd() // ���� �ٽ� �ε��ϴ� �Լ�
    {
        rewardedAd = new RewardedAd(rewardID);

        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);
    }

    public void HandleRewardedAdClosed(object sender, System.EventArgs args)
    {  // ����ڰ� ���� �ݾ��� ��
        CreateAndLoadRewardedAd();  // ���� �ٽ� �ε�
    }

    private void HandleUserEarnedReward(object sender, Reward e)
    {  // ���� �� ���� ��
        rewarded = true; // ���� true
        PlayerPrefs.SetInt("Serotonin", S + 100);
        PlayerPrefs.SetInt("SSerotonin", SS + 100);
        Views1.SetActive(false);
        PlayerPrefs.SetInt("Day1", 1);
    }

    // ������ ����  2
    public void UserChoseToWatchAd2()
    {
        click.Play();
        if (PlayerPrefs.GetInt("Noads") == 1)
        {
            PlayerPrefs.SetInt("Serotonin", S + 100);
            PlayerPrefs.SetInt("SSerotonin", SS + 100);
            Views2.SetActive(false);
            PlayerPrefs.SetInt("Day2", 1);
        }
        else if (PlayerPrefs.GetInt("Noads") == 0)
        {
            if (rewardedAd2.IsLoaded()) // ���� �ε� �Ǿ��� ��
            {
                rewardedAd2.Show(); // ���� �����ֱ�
                myCan.sortingOrder = -1;
            }
        }
    }

    public void CreateAndLoadRewardedAd2() // ���� �ٽ� �ε��ϴ� �Լ�
    {
        rewardedAd2 = new RewardedAd(rewardID);

        rewardedAd2.OnUserEarnedReward += HandleUserEarnedReward2;
        rewardedAd2.OnAdClosed += HandleRewardedAdClosed2;

        AdRequest request2 = new AdRequest.Builder().Build();
        rewardedAd2.LoadAd(request2);
    }

    public void HandleRewardedAdClosed2(object sender, System.EventArgs args)
    {  // ����ڰ� ���� �ݾ��� ��
        CreateAndLoadRewardedAd2();  // ���� �ٽ� �ε�
    }

    private void HandleUserEarnedReward2(object sender, Reward e)
    {  // ���� �� ���� ��
        rewarded2 = true; // ���� true
        PlayerPrefs.SetInt("Serotonin", S + 100);
        PlayerPrefs.SetInt("SSerotonin", SS + 100);
        Views2.SetActive(false);
        PlayerPrefs.SetInt("Day2", 1);
    }

    // ������ ����  3
    public void UserChoseToWatchAd3()
    {
        click.Play();
        if (PlayerPrefs.GetInt("Noads") == 1)
        {
            PlayerPrefs.SetInt("Serotonin", S + 200);
            PlayerPrefs.SetInt("SSerotonin", SS + 200);
            Views3.SetActive(false);
            PlayerPrefs.SetInt("Day3", 1);
        }
        else if (PlayerPrefs.GetInt("Noads") == 0)
        {
            if (rewardedAd3.IsLoaded()) // ���� �ε� �Ǿ��� ��
            {
                rewardedAd3.Show(); // ���� �����ֱ�
                myCan.sortingOrder = -1;
            }
        }
    }

    public void CreateAndLoadRewardedAd3() // ���� �ٽ� �ε��ϴ� �Լ�
    {
        rewardedAd3 = new RewardedAd(rewardID);

        rewardedAd3.OnUserEarnedReward += HandleUserEarnedReward3;
        rewardedAd3.OnAdClosed += HandleRewardedAdClosed3;

        AdRequest request3 = new AdRequest.Builder().Build();
        rewardedAd3.LoadAd(request3);
    }

    public void HandleRewardedAdClosed3(object sender, System.EventArgs args)
    {  // ����ڰ� ���� �ݾ��� ��
        CreateAndLoadRewardedAd3();  // ���� �ٽ� �ε�
    }

    private void HandleUserEarnedReward3(object sender, Reward e)
    {  // ���� �� ���� ��
        rewarded3 = true; // ���� true
        PlayerPrefs.SetInt("Serotonin", S + 200);
        PlayerPrefs.SetInt("SSerotonin", SS + 200);
        Views3.SetActive(false);
        PlayerPrefs.SetInt("Day3", 1);
    }

    // ������ ����  4
    public void UserChoseToWatchAd4()
    {
        click.Play();
        if (PlayerPrefs.GetInt("Noads") == 1)
        {
            PlayerPrefs.SetInt("Serotonin", S + 100);
            PlayerPrefs.SetInt("SSerotonin", SS + 100);
            Views4.SetActive(false);
            PlayerPrefs.SetInt("Day4", 1);
        }
        else if (PlayerPrefs.GetInt("Noads") == 0)
        {
            if (rewardedAd4.IsLoaded()) // ���� �ε� �Ǿ��� ��
            {
                rewardedAd4.Show(); // ���� �����ֱ�
                myCan.sortingOrder = -1;
            }
        }
    }

    public void CreateAndLoadRewardedAd4() // ���� �ٽ� �ε��ϴ� �Լ�
    {
        rewardedAd4 = new RewardedAd(rewardID);

        rewardedAd4.OnUserEarnedReward += HandleUserEarnedReward4;
        rewardedAd4.OnAdClosed += HandleRewardedAdClosed4;

        AdRequest request4 = new AdRequest.Builder().Build();
        rewardedAd4.LoadAd(request4);
    }

    public void HandleRewardedAdClosed4(object sender, System.EventArgs args)
    {  // ����ڰ� ���� �ݾ��� ��
        CreateAndLoadRewardedAd4();  // ���� �ٽ� �ε�
    }

    private void HandleUserEarnedReward4(object sender, Reward e)
    {  // ���� �� ���� ��
        rewarded4 = true; // ���� true
        PlayerPrefs.SetInt("Serotonin", S + 100);
        PlayerPrefs.SetInt("SSerotonin", SS + 100);
        Views4.SetActive(false);
        PlayerPrefs.SetInt("Day4", 1);
    }

    // ������ ����  5
    public void UserChoseToWatchAd5()
    {
        click.Play();
        if (PlayerPrefs.GetInt("Noads") == 1)
        {
            PlayerPrefs.SetInt("Serotonin", S + 100);
            PlayerPrefs.SetInt("SSerotonin", SS + 100);
            Views5.SetActive(false);
            PlayerPrefs.SetInt("Day5", 1);
        }
        else if (PlayerPrefs.GetInt("Noads") == 0)
        {
            if (rewardedAd5.IsLoaded()) // ���� �ε� �Ǿ��� ��
            {
                rewardedAd5.Show(); // ���� �����ֱ�
                myCan.sortingOrder = -1;
            }
        }
    }

    public void CreateAndLoadRewardedAd5() // ���� �ٽ� �ε��ϴ� �Լ�
    {
        rewardedAd5 = new RewardedAd(rewardID);

        rewardedAd5.OnUserEarnedReward += HandleUserEarnedReward5;
        rewardedAd5.OnAdClosed += HandleRewardedAdClosed5;

        AdRequest request5 = new AdRequest.Builder().Build();
        rewardedAd5.LoadAd(request5);
    }

    public void HandleRewardedAdClosed5(object sender, System.EventArgs args)
    {  // ����ڰ� ���� �ݾ��� ��
        CreateAndLoadRewardedAd5();  // ���� �ٽ� �ε�
    }

    private void HandleUserEarnedReward5(object sender, Reward e)
    {  // ���� �� ���� ��
        rewarded5 = true; // ���� true
        PlayerPrefs.SetInt("Serotonin", S + 100);
        PlayerPrefs.SetInt("SSerotonin", SS + 100);
        Views5.SetActive(false);
        PlayerPrefs.SetInt("Day5", 1);
    }

    // ������ ����  6
    public void UserChoseToWatchAd6()
    {
        click.Play();
        if (PlayerPrefs.GetInt("Noads") == 1)
        {
            PlayerPrefs.SetInt("Serotonin", S + 300);
            PlayerPrefs.SetInt("SSerotonin", SS + 300);
            Views6.SetActive(false);
            PlayerPrefs.SetInt("Day6", 1);
        }
        else if (PlayerPrefs.GetInt("Noads") == 0)
        {
            if (rewardedAd6.IsLoaded()) // ���� �ε� �Ǿ��� ��
            {
                rewardedAd6.Show(); // ���� �����ֱ�
                myCan.sortingOrder = -1;
            }
        }
    }

    public void CreateAndLoadRewardedAd6() // ���� �ٽ� �ε��ϴ� �Լ�
    {
        rewardedAd6 = new RewardedAd(rewardID);

        rewardedAd6.OnUserEarnedReward += HandleUserEarnedReward6;
        rewardedAd6.OnAdClosed += HandleRewardedAdClosed6;

        AdRequest request6 = new AdRequest.Builder().Build();
        rewardedAd6.LoadAd(request6);
    }

    public void HandleRewardedAdClosed6(object sender, System.EventArgs args)
    {  // ����ڰ� ���� �ݾ��� ��
        CreateAndLoadRewardedAd6();  // ���� �ٽ� �ε�
    }

    private void HandleUserEarnedReward6(object sender, Reward e)
    {  // ���� �� ���� ��
        rewarded6 = true; // ���� true
        PlayerPrefs.SetInt("Serotonin", S + 300);
        PlayerPrefs.SetInt("SSerotonin", SS + 300);
        Views6.SetActive(false);
        PlayerPrefs.SetInt("Day6", 1);
    }

    // ������ ����  7
    public void UserChoseToWatchAd7()
    {
        click.Play();
        if (PlayerPrefs.GetInt("Noads") == 1)
        {
            PlayerPrefs.SetInt("Serotonin", S + 1000);
            PlayerPrefs.SetInt("SSerotonin", SS + 1000);
            Views7.SetActive(false);
            PlayerPrefs.SetInt("Day7", 1);
        }
        else if (PlayerPrefs.GetInt("Noads") == 0)
        {
            if (rewardedAd7.IsLoaded()) // ���� �ε� �Ǿ��� ��
            {
                rewardedAd7.Show(); // ���� �����ֱ�
                myCan.sortingOrder = -1;
            }
        }
    }

    public void CreateAndLoadRewardedAd7() // ���� �ٽ� �ε��ϴ� �Լ�
    {
        rewardedAd7 = new RewardedAd(rewardID);

        rewardedAd7.OnUserEarnedReward += HandleUserEarnedReward7;
        rewardedAd7.OnAdClosed += HandleRewardedAdClosed7;

        AdRequest request7 = new AdRequest.Builder().Build();
        rewardedAd7.LoadAd(request7);
    }

    public void HandleRewardedAdClosed7(object sender, System.EventArgs args)
    {  // ����ڰ� ���� �ݾ��� ��
        CreateAndLoadRewardedAd7();  // ���� �ٽ� �ε�
    }

    private void HandleUserEarnedReward7(object sender, Reward e)
    {  // ���� �� ���� ��
        rewarded7 = true; // ���� true
        PlayerPrefs.SetInt("Serotonin", S + 1000);
        PlayerPrefs.SetInt("SSerotonin", SS + 1000);
        Views7.SetActive(false);
        PlayerPrefs.SetInt("Day7", 1);
    }



    // Start is called before the first frame update
    void Start()
    {
        // �⼮üũ ������ ���� 
        rewardedAd = new RewardedAd(rewardID);
        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request); // ���� �ε�

        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // ����ڰ� ���� ������ ��û���� ��
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        // ����ڰ� ���� �߰��� �ݾ��� ��

        rewardedAd2 = new RewardedAd(rewardID);
        AdRequest request2 = new AdRequest.Builder().Build();
        rewardedAd2.LoadAd(request); // ���� �ε�

        rewardedAd2.OnUserEarnedReward += HandleUserEarnedReward2;
        // ����ڰ� ���� ������ ��û���� ��
        rewardedAd2.OnAdClosed += HandleRewardedAdClosed2;
        // ����ڰ� ���� �߰��� �ݾ��� ��

        rewardedAd3 = new RewardedAd(rewardID);
        AdRequest request3 = new AdRequest.Builder().Build();
        rewardedAd3.LoadAd(request); // ���� �ε�

        rewardedAd3.OnUserEarnedReward += HandleUserEarnedReward3;
        // ����ڰ� ���� ������ ��û���� ��
        rewardedAd3.OnAdClosed += HandleRewardedAdClosed3;
        // ����ڰ� ���� �߰��� �ݾ��� ��

        rewardedAd4 = new RewardedAd(rewardID);
        AdRequest request4 = new AdRequest.Builder().Build();
        rewardedAd4.LoadAd(request); // ���� �ε�

        rewardedAd4.OnUserEarnedReward += HandleUserEarnedReward4;
        // ����ڰ� ���� ������ ��û���� ��
        rewardedAd4.OnAdClosed += HandleRewardedAdClosed4;
        // ����ڰ� ���� �߰��� �ݾ��� ��

        rewardedAd5 = new RewardedAd(rewardID);
        AdRequest request5 = new AdRequest.Builder().Build();
        rewardedAd5.LoadAd(request); // ���� �ε�

        rewardedAd5.OnUserEarnedReward += HandleUserEarnedReward5;
        // ����ڰ� ���� ������ ��û���� ��
        rewardedAd5.OnAdClosed += HandleRewardedAdClosed5;
        // ����ڰ� ���� �߰��� �ݾ��� ��

        rewardedAd6 = new RewardedAd(rewardID);
        AdRequest request6 = new AdRequest.Builder().Build();
        rewardedAd6.LoadAd(request); // ���� �ε�

        rewardedAd6.OnUserEarnedReward += HandleUserEarnedReward6;
        // ����ڰ� ���� ������ ��û���� ��
        rewardedAd6.OnAdClosed += HandleRewardedAdClosed6;
        // ����ڰ� ���� �߰��� �ݾ��� ��

        rewardedAd7 = new RewardedAd(rewardID);
        AdRequest request7 = new AdRequest.Builder().Build();
        rewardedAd7.LoadAd(request); // ���� �ε�

        rewardedAd7.OnUserEarnedReward += HandleUserEarnedReward7;
        // ����ڰ� ���� ������ ��û���� ��
        rewardedAd7.OnAdClosed += HandleRewardedAdClosed7;
        // ����ڰ� ���� �߰��� �ݾ��� ��

        // �⼮üũ ������ ���� �� ---------



        // ����
        PlayerPrefs.GetInt("sound", 1);
        PlayerPrefs.GetInt("sfx", 1);

        // ó�� �÷��� ����
        PlayerPrefs.GetInt("Play", 0);
        // �� �������� Ŭ���� ���� - �ϵ���
        PlayerPrefs.GetInt("StageClear1", 0);
        PlayerPrefs.GetInt("StageClear2", 0);
        PlayerPrefs.GetInt("StageClear3", 0);
        PlayerPrefs.GetInt("StageClear4", 0);
        PlayerPrefs.GetInt("StageClear5", 0);
        // �� �������� Ŭ���� ���� - �������
        PlayerPrefs.GetInt("StageClearE1", 0);
        PlayerPrefs.GetInt("StageClearE2", 0);
        PlayerPrefs.GetInt("StageClearE3", 0);
        PlayerPrefs.GetInt("StageClearE4", 0);
        PlayerPrefs.GetInt("StageClearE5", 0);
        // ���Ĺ�, ������� ����
        D=PlayerPrefs.GetInt("Dopamine", 0);
        // ���� ���Ĺ�
        DD = PlayerPrefs.GetInt("DDopamine", 0);
        S =PlayerPrefs.GetInt("Serotonin", 0);
        // ���� �������
        SS =PlayerPrefs.GetInt("SSerotonin", 0);
        // �� �������� �ְ� ���� - �ϵ���
        PlayerPrefs.GetInt("BestScore1", 0);
        PlayerPrefs.GetInt("BestScore2", 0);
        PlayerPrefs.GetInt("BestScore3", 0);
        PlayerPrefs.GetInt("BestScore4", 0);
        PlayerPrefs.GetInt("BestScore5", 0);
        // �� �������� �ְ� ���� - �������
        PlayerPrefs.GetInt("BestScoreE1", 0);
        PlayerPrefs.GetInt("BestScoreE2", 0);
        PlayerPrefs.GetInt("BestScoreE3", 0);
        PlayerPrefs.GetInt("BestScoreE4", 0);
        PlayerPrefs.GetInt("BestScoreE5", 0);
        // ������ ��Ų ����
        PlayerPrefs.GetInt("Item1", 0);
        PlayerPrefs.GetInt("Item2", 0);
        PlayerPrefs.GetInt("Item3", 0);
        PlayerPrefs.GetInt("Item4", 0);
        PlayerPrefs.GetInt("Item5", 0);
        // �⼮üũ ����
        PlayerPrefs.GetInt("Day1", 0);
        PlayerPrefs.GetInt("Day2", 0);
        PlayerPrefs.GetInt("Day3", 0);
        PlayerPrefs.GetInt("Day4", 0);
        PlayerPrefs.GetInt("Day5", 0);
        PlayerPrefs.GetInt("Day6", 0);
        PlayerPrefs.GetInt("Day7", 0);
        // ��¥ �ٲ�� ����
        PlayerPrefs.GetInt("DayCheck", 0);
        PlayerPrefs.GetInt("DayCheck2", 0);
        PlayerPrefs.GetInt("MonthCheck", 0);
        PlayerPrefs.GetInt("YearCheck", 0);
        // ��Ų ���� ����
        PlayerPrefs.GetInt("Fit0", 0);
        PlayerPrefs.GetInt("Fit1", 0);
        PlayerPrefs.GetInt("Fit2", 0);
        PlayerPrefs.GetInt("Fit3", 0);
        PlayerPrefs.GetInt("Fit4", 0);
        PlayerPrefs.GetInt("Fit5", 0);
        PlayerPrefs.GetInt("Fit6", 0);
        PlayerPrefs.GetInt("Fit7", 0);
        PlayerPrefs.GetInt("Fit8", 0);
        PlayerPrefs.GetInt("Fit9", 0);
        PlayerPrefs.GetInt("Fit10", 0);
        PlayerPrefs.GetInt("Fit11", 0);
        PlayerPrefs.GetInt("Fit12", 0);
        PlayerPrefs.GetInt("Fit13", 0);
        PlayerPrefs.GetInt("Fit14", 0);
        PlayerPrefs.GetInt("Fit15", 0);
        PlayerPrefs.GetInt("Fit16", 0);
        PlayerPrefs.GetInt("Fit17", 0);
        PlayerPrefs.GetInt("Fit18", 0);
        // ��������
        PlayerPrefs.GetInt("TreasureEasy", 0);
        PlayerPrefs.GetInt("TreasureHard", 0);
        // ���� ����
        PlayerPrefs.GetInt("Noads", 0);

        if (PlayerPrefs.GetInt("Play") == 0)
        {
            PlayerPrefs.SetInt("Fit0", 1);
        }
        

        Count();

        for (int i = 1; i < 7; i++)
        {
            DayBtns[i].interactable = false;
        }
    }

    // �ʱ�ȭ ��ư
    public void ResetBtn()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // ����
        PlayerPrefs.SetInt("sound", 1);
        PlayerPrefs.SetInt("sfx", 1);
    }

    
    // �ð� �߰�
    public void AddDay()
    {
        /* // ��ư ������ 1�ð� �߰�
         Now = Now + ts;
         Debug.Log(Now);*/

        PlayerPrefs.SetInt("DayCheck", 10);
        PlayerPrefs.SetInt("DayCheck2", 10);
    }
    // ���� �ð� ��� ��ư
    public void TimeBtn()
    {
        Debug.Log(Now);
    }

    // Update is called once per frame
    void Update()
    {
        // ������ ����
        if (rewarded)
        {
            rewarded = false;
        }
        if (rewarded2)
        {
            rewarded2 = false;
        }
        if (rewarded3)
        {
            rewarded3 = false;
        }
        if (rewarded4)
        {
            rewarded4 = false;
        }
        if (rewarded5)
        {
            rewarded5 = false;
        }
        if (rewarded6)
        {
            rewarded6 = false;
        }
        if (rewarded7)
        {
            rewarded7 = false;
        }

        // ����
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            soundOff.SetActive(true);
            soundOn.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("sound") == 0)
        {
            soundOff.SetActive(false);
            soundOn.SetActive(true);
        }
        if (PlayerPrefs.GetInt("sfx") == 1)
        {
            sfxOff.SetActive(true);
            sfxOn.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("sfx") == 0)
        {
            sfxOff.SetActive(false);
            sfxOn.SetActive(true);
        }


            // 7���� ��� �޾��� ��
        if ((PlayerPrefs.GetInt("Day1") == 1) && (PlayerPrefs.GetInt("Day2") == 1) && (PlayerPrefs.GetInt("Day3") == 1) && (PlayerPrefs.GetInt("Day4") == 1) && 
            (PlayerPrefs.GetInt("Day5") == 1) && (PlayerPrefs.GetInt("Day6") == 1) && (PlayerPrefs.GetInt("Day7") == 1))
        {
            if (DateTime.Now.Day != PlayerPrefs.GetInt("DayCheck"))
            {
                PlayerPrefs.SetInt("Day1", 0);
                PlayerPrefs.SetInt("Day2", 0);
                PlayerPrefs.SetInt("Day3", 0);
                PlayerPrefs.SetInt("Day4", 0);
                PlayerPrefs.SetInt("Day5", 0);
                PlayerPrefs.SetInt("Day6", 0);
                PlayerPrefs.SetInt("Day7", 0);
                PlayerPrefs.SetInt("DayCheck1", DateTime.Now.Day);
            }

            /*if (DateTime.Now.Hour == 24)
            {
                PlayerPrefs.SetInt("Day1", 0);
                PlayerPrefs.SetInt("Day2", 0);
                PlayerPrefs.SetInt("Day3", 0);
                PlayerPrefs.SetInt("Day4", 0);
                PlayerPrefs.SetInt("Day5", 0);
                PlayerPrefs.SetInt("Day6", 0);
                PlayerPrefs.SetInt("Day7", 0);
            }*/

        }


        for (int i = 1; i < 7; i++)
        {

            //if (DateTime.Now.Day != PlayerPrefs.GetInt("DayCheck") || DateTime.Now.Month != PlayerPrefs.GetInt("MonthCheck") && (DayBtns[i - 1].interactable == true))
            //if ((DateTime.Now.Day != PlayerPrefs.GetInt("DayCheck")) && (DayBtns[i - 1].interactable == false))
            if ((DateTime.Now.Day != PlayerPrefs.GetInt("DayCheck")) && (PlayerPrefs.GetInt($"Day{i}") == 1))
            {
                DayBtns[i].interactable = true;
                PlayerPrefs.SetInt("DayCheck", DateTime.Now.Day);
                PlayerPrefs.SetInt("MonthCheck", DateTime.Now.Month);
            }

            /*if (DateTime.Now.Hour == 24 && (DayBtns[i - 1].interactable == true))
            {
                DayBtns[i].interactable = true;
            }*/


        }

        // �͸��� �������� �Ϸ� ������ �ʱ�ȭ
        if (DateTime.Now.Day != PlayerPrefs.GetInt("DayCheck2"))
        {
            PlayerPrefs.SetInt("OPEN", 0);
            PlayerPrefs.SetInt("DayCheck2", DateTime.Now.Day);
        }




        // ����� ��¥�� ���� ��¥�� �ٸ��ٸ�
        /*
        if (DateTime.Now.Day != PlayerPrefs.GetInt("DayCheck") || DateTime.Now.Month!=PlayerPrefs.GetInt("MonthCheck"))
        {
            DayBtns[0].interactable = true;
            PlayerPrefs.SetInt("DayCheck", DateTime.Now.Day);
            PlayerPrefs.SetInt("MonthCheck", DateTime.Now.Month);

        }*/


        // �ȵ���̵� back��ư���� ���� ����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscapeView.SetActive(true);
        }

        // �⼮üũ �Ϸ� ��ư ���� ����
        for (int i = 0; i < 7; i++)
        {
            int j = i + 1;
            if (PlayerPrefs.GetInt($"Day{j}") == 1)
            {
                DayBtns[i].interactable = false;
                Btnimg[i].SetActive(true);
            }
        }
        for (int i = 0; i < 7; i++)
        {
            int j = i + 1;
            if (PlayerPrefs.GetInt($"Day{j}") == 0)
            {
                Btnimg[i].SetActive(false);
            }
        }

        if (PlayerPrefs.GetInt("Day1") == 0)
        {
            DayBtns[0].interactable = true;
        }

    }

    // ��������
    public void ClickEscapeYes()
    {
        click.Play();
        Application.Quit();
    }
    public void ClickEscapeNo()
    {
        click.Play();
        EscapeView.SetActive(false);
    }

    // ���ӽ��� ��ư
    public void ClickStart()
    {
        click.Play();
        if (PlayerPrefs.GetInt("Play", 0) == 0)
        {
            PlayerPrefs.SetInt("Play", 1);
            SceneManager.LoadScene(8);
            Time.timeScale = 1;
        }
        else
        {
            SceneManager.LoadScene(11);
            Time.timeScale = 1;
        }
    }

    // ���� ��ư
    public void ClickStore()
    {
        click.Play();
        SceneManager.LoadScene(9);
    }

    // ���丮 ��ư
    public void ClickStory()
    {
        click.Play();
        SceneManager.LoadScene(7);
    }

    // ���� â ����
    public void ClickSetting()
    {
        click.Play();
        SettingView.SetActive(true);
    }

    // ���� â �ݱ�
    public void ClickSettingClose()
    {
        click.Play();
        SettingView.SetActive(false);
    }

    // ���� �Ű� â ����
    public void ClickHelp()
    {
        click.Play();
        HelpView.SetActive(true);
    }

    // ���� �Ű� â �ݱ�
    public void ClickHelpClose()
    {
        click.Play();
        HelpView.SetActive(false);
    }

    public void Count()
    {
        Dopamine.text = D.ToString();
        Serotonin.text = S.ToString();
    }

    // Ȩȭ�鿡�� �⼮üũ ��ư
    public void DayBtn()
    {
        click.Play();
        DayView.SetActive(true);
    }

    // �⼮üũ �� �ݱ� ��ư
    public void DayCloseBtn()
    {
        click.Play();
        DayView.SetActive(false);
    }

    // day��ư
    public void DayBtn1()
    {
        click.Play();
        Views1.SetActive(true);
    }

    // Views �ݱ� ��ư
    public void ViewsCloseBtn1()
    {
        click.Play();
        Views1.SetActive(false);
    }

    public void DayBtn2()
    {
        click.Play();
        Views2.SetActive(true);
    }
    public void ViewsCloseBtn2()
    {
        click.Play();
        Views2.SetActive(false);
    }

    public void DayBtn3()
    {
        click.Play();
        Views3.SetActive(true);
    }
    public void ViewsCloseBtn3()
    {
        click.Play();
        Views3.SetActive(false);
    }

    public void DayBtn4()
    {
        click.Play();
        Views4.SetActive(true);
    }
    public void ViewsCloseBtn4()
    {
        click.Play();
        Views4.SetActive(false);
    }

    public void DayBtn5()
    {
        click.Play();
        Views5.SetActive(true);
    }
    public void ViewsCloseBtn5()
    {
        click.Play();
        Views5.SetActive(false);
    }

    public void DayBtn6()
    {
        click.Play();
        Views6.SetActive(true);
    }
    public void ViewsCloseBtn6()
    {
        Views6.SetActive(false);
        click.Play();
    }

    public void DayBtn7()
    {
        Views7.SetActive(true);
        click.Play();
    }
    public void ViewsCloseBtn7()
    {
        Views7.SetActive(false);
        click.Play();
    }


    // �⼮üũ ������� ���� �ޱ�
    public void GetBtn1()
    {
        click.Play();
        PlayerPrefs.SetInt("Serotonin", S + 50);
        PlayerPrefs.SetInt("SSerotonin", SS + 50);
        Views1.SetActive(false);
        PlayerPrefs.SetInt("Day1", 1);
    }

    public void GetBtn2()
    {
        click.Play();
        PlayerPrefs.SetInt("Serotonin", S + 50);
        PlayerPrefs.SetInt("SSerotonin", SS + 50);
        Views2.SetActive(false);
        PlayerPrefs.SetInt("Day2", 1);
    }

    public void GetBtn3()
    {
        click.Play();
        PlayerPrefs.SetInt("Serotonin", S + 100);
        PlayerPrefs.SetInt("SSerotonin", SS + 100);
        Views3.SetActive(false);
        PlayerPrefs.SetInt("Day3", 1);
    }

    public void GetBtn4()
    {
        click.Play();
        PlayerPrefs.SetInt("Serotonin", S + 50);
        PlayerPrefs.SetInt("SSerotonin", SS + 50);
        Views4.SetActive(false);
        PlayerPrefs.SetInt("Day4", 1);
    }

    public void GetBtn5()
    {
        click.Play();
        PlayerPrefs.SetInt("Serotonin", S + 50);
        PlayerPrefs.SetInt("SSerotonin", SS + 50);
        Views5.SetActive(false);
        PlayerPrefs.SetInt("Day5", 1);
    }

    public void GetBtn6()
    {
        click.Play();
        PlayerPrefs.SetInt("Serotonin", S + 150);
        PlayerPrefs.SetInt("SSerotonin", SS + 150);
        Views6.SetActive(false);
        PlayerPrefs.SetInt("Day6", 1);
    }

    public void GetBtn7()
    {
        click.Play();
        PlayerPrefs.SetInt("Serotonin", S + 500);
        PlayerPrefs.SetInt("SSerotonin", SS + 500);
        Views7.SetActive(false);
        PlayerPrefs.SetInt("Day7", 1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //PlayerPrefs.SetInt("Set", 1);
    }

    // ����
    public void SoundOFF()
    {
        PlayerPrefs.SetInt("sound", 0);
        soundOff.SetActive(false);
        soundOn.SetActive(true);
        click.Play();
    }
    public void SoundON()
    {
        PlayerPrefs.SetInt("sound", 1);
        soundOff.SetActive(true);
        soundOn.SetActive(false);
        click.Play();
    }

    public void SfxOFF()
    {
        PlayerPrefs.SetInt("sfx", 0);
        sfxOff.SetActive(false);
        sfxOn.SetActive(true);
        click.Play();
    }
    public void SfxON()
    {
        PlayerPrefs.SetInt("sfx", 1);
        sfxOff.SetActive(true);
        sfxOn.SetActive(false);
        click.Play();
    }

    public void Ranking()
    {
        click.Play();
        SceneManager.LoadScene(18);
    }
    
}
