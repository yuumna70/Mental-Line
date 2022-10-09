using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using GoogleMobileAds.Api;

public class MainManager : MonoBehaviour
{
    // 설정
    public GameObject SettingView;
    public GameObject HelpView;

    // 종료
    public GameObject EscapeView;

    // 사운드
    [SerializeField] AudioSource music;
    public GameObject soundOn;
    public GameObject soundOff;
    public GameObject sfxOn;
    public GameObject sfxOff;
    public GameObject shakeOn;
    public GameObject shakeOff;

    // 도파민 세로토민 개수
    public Text Dopamine;
    public Text Serotonin;
    private int D;
    private int DD;
    private int S;
    private int SS;

    // 출석체크 뷰 / 버튼
    public Button[] DayBtns;
    public GameObject DayView;
    public GameObject View1;
    public GameObject View2;
    // 출석체크 완료 이미지
    public GameObject[] Btnimg;

    // *일차 뷰
    public GameObject Views1;
    public GameObject Views2;
    public GameObject Views3;
    public GameObject Views4;
    public GameObject Views5;
    public GameObject Views6;
    public GameObject Views7;

    // 사운드
    public AudioSource click;

    // day = 다음 00시
    DateTime day = DateTime.Today.AddDays(1);
    TimeSpan ts = new TimeSpan(10, 0, 0);
    DateTime Now = DateTime.Now;

    // 리워드 광고
    private RewardedAd rewardedAd;
    private RewardedAd rewardedAd2;
    private RewardedAd rewardedAd3;
    private RewardedAd rewardedAd4;
    private RewardedAd rewardedAd5;
    private RewardedAd rewardedAd6;
    private RewardedAd rewardedAd7;
    public Canvas myCan;

    // 실제 광고 ID
    private string rewardID; // = "ca-app-pub-4101740431730513/5910670487";

    private bool rewarded = false;
    private bool rewarded2 = false;
    private bool rewarded3 = false;
    private bool rewarded4 = false;
    private bool rewarded5 = false;
    private bool rewarded6 = false;
    private bool rewarded7 = false;

    DateTime dtNowTime = DateTime.Now;

    // 출석체크 리워드 광고 
    // 리워드 광고
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
            if (rewardedAd.IsLoaded()) // 광고가 로드 되었을 때
            {
                rewardedAd.Show(); // 광고 보여주기
                myCan.sortingOrder = -1;
            }
        }
    }

    public void CreateAndLoadRewardedAd() // 광고 다시 로드하는 함수
    {
        rewardedAd = new RewardedAd(rewardID);

        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);
    }

    public void HandleRewardedAdClosed(object sender, System.EventArgs args)
    {  // 사용자가 광고를 닫았을 때
        CreateAndLoadRewardedAd();  // 광고 다시 로드
    }

    private void HandleUserEarnedReward(object sender, Reward e)
    {  // 광고를 다 봤을 때
        rewarded = true; // 변수 true
        PlayerPrefs.SetInt("Serotonin", S + 100);
        PlayerPrefs.SetInt("SSerotonin", SS + 100);
        Views1.SetActive(false);
        PlayerPrefs.SetInt("Day1", 1);
    }

    // 리워드 광고  2
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
            if (rewardedAd2.IsLoaded()) // 광고가 로드 되었을 때
            {
                rewardedAd2.Show(); // 광고 보여주기
                myCan.sortingOrder = -1;
            }
        }
    }

    public void CreateAndLoadRewardedAd2() // 광고 다시 로드하는 함수
    {
        rewardedAd2 = new RewardedAd(rewardID);

        rewardedAd2.OnUserEarnedReward += HandleUserEarnedReward2;
        rewardedAd2.OnAdClosed += HandleRewardedAdClosed2;

        AdRequest request2 = new AdRequest.Builder().Build();
        rewardedAd2.LoadAd(request2);
    }

    public void HandleRewardedAdClosed2(object sender, System.EventArgs args)
    {  // 사용자가 광고를 닫았을 때
        CreateAndLoadRewardedAd2();  // 광고 다시 로드
    }

    private void HandleUserEarnedReward2(object sender, Reward e)
    {  // 광고를 다 봤을 때
        rewarded2 = true; // 변수 true
        PlayerPrefs.SetInt("Serotonin", S + 100);
        PlayerPrefs.SetInt("SSerotonin", SS + 100);
        Views2.SetActive(false);
        PlayerPrefs.SetInt("Day2", 1);
    }

    // 리워드 광고  3
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
            if (rewardedAd3.IsLoaded()) // 광고가 로드 되었을 때
            {
                rewardedAd3.Show(); // 광고 보여주기
                myCan.sortingOrder = -1;
            }
        }
    }

    public void CreateAndLoadRewardedAd3() // 광고 다시 로드하는 함수
    {
        rewardedAd3 = new RewardedAd(rewardID);

        rewardedAd3.OnUserEarnedReward += HandleUserEarnedReward3;
        rewardedAd3.OnAdClosed += HandleRewardedAdClosed3;

        AdRequest request3 = new AdRequest.Builder().Build();
        rewardedAd3.LoadAd(request3);
    }

    public void HandleRewardedAdClosed3(object sender, System.EventArgs args)
    {  // 사용자가 광고를 닫았을 때
        CreateAndLoadRewardedAd3();  // 광고 다시 로드
    }

    private void HandleUserEarnedReward3(object sender, Reward e)
    {  // 광고를 다 봤을 때
        rewarded3 = true; // 변수 true
        PlayerPrefs.SetInt("Serotonin", S + 200);
        PlayerPrefs.SetInt("SSerotonin", SS + 200);
        Views3.SetActive(false);
        PlayerPrefs.SetInt("Day3", 1);
    }

    // 리워드 광고  4
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
            if (rewardedAd4.IsLoaded()) // 광고가 로드 되었을 때
            {
                rewardedAd4.Show(); // 광고 보여주기
                myCan.sortingOrder = -1;
            }
        }
    }

    public void CreateAndLoadRewardedAd4() // 광고 다시 로드하는 함수
    {
        rewardedAd4 = new RewardedAd(rewardID);

        rewardedAd4.OnUserEarnedReward += HandleUserEarnedReward4;
        rewardedAd4.OnAdClosed += HandleRewardedAdClosed4;

        AdRequest request4 = new AdRequest.Builder().Build();
        rewardedAd4.LoadAd(request4);
    }

    public void HandleRewardedAdClosed4(object sender, System.EventArgs args)
    {  // 사용자가 광고를 닫았을 때
        CreateAndLoadRewardedAd4();  // 광고 다시 로드
    }

    private void HandleUserEarnedReward4(object sender, Reward e)
    {  // 광고를 다 봤을 때
        rewarded4 = true; // 변수 true
        PlayerPrefs.SetInt("Serotonin", S + 100);
        PlayerPrefs.SetInt("SSerotonin", SS + 100);
        Views4.SetActive(false);
        PlayerPrefs.SetInt("Day4", 1);
    }

    // 리워드 광고  5
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
            if (rewardedAd5.IsLoaded()) // 광고가 로드 되었을 때
            {
                rewardedAd5.Show(); // 광고 보여주기
                myCan.sortingOrder = -1;
            }
        }
    }

    public void CreateAndLoadRewardedAd5() // 광고 다시 로드하는 함수
    {
        rewardedAd5 = new RewardedAd(rewardID);

        rewardedAd5.OnUserEarnedReward += HandleUserEarnedReward5;
        rewardedAd5.OnAdClosed += HandleRewardedAdClosed5;

        AdRequest request5 = new AdRequest.Builder().Build();
        rewardedAd5.LoadAd(request5);
    }

    public void HandleRewardedAdClosed5(object sender, System.EventArgs args)
    {  // 사용자가 광고를 닫았을 때
        CreateAndLoadRewardedAd5();  // 광고 다시 로드
    }

    private void HandleUserEarnedReward5(object sender, Reward e)
    {  // 광고를 다 봤을 때
        rewarded5 = true; // 변수 true
        PlayerPrefs.SetInt("Serotonin", S + 100);
        PlayerPrefs.SetInt("SSerotonin", SS + 100);
        Views5.SetActive(false);
        PlayerPrefs.SetInt("Day5", 1);
    }

    // 리워드 광고  6
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
            if (rewardedAd6.IsLoaded()) // 광고가 로드 되었을 때
            {
                rewardedAd6.Show(); // 광고 보여주기
                myCan.sortingOrder = -1;
            }
        }
    }

    public void CreateAndLoadRewardedAd6() // 광고 다시 로드하는 함수
    {
        rewardedAd6 = new RewardedAd(rewardID);

        rewardedAd6.OnUserEarnedReward += HandleUserEarnedReward6;
        rewardedAd6.OnAdClosed += HandleRewardedAdClosed6;

        AdRequest request6 = new AdRequest.Builder().Build();
        rewardedAd6.LoadAd(request6);
    }

    public void HandleRewardedAdClosed6(object sender, System.EventArgs args)
    {  // 사용자가 광고를 닫았을 때
        CreateAndLoadRewardedAd6();  // 광고 다시 로드
    }

    private void HandleUserEarnedReward6(object sender, Reward e)
    {  // 광고를 다 봤을 때
        rewarded6 = true; // 변수 true
        PlayerPrefs.SetInt("Serotonin", S + 300);
        PlayerPrefs.SetInt("SSerotonin", SS + 300);
        Views6.SetActive(false);
        PlayerPrefs.SetInt("Day6", 1);
    }

    // 리워드 광고  7
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
            if (rewardedAd7.IsLoaded()) // 광고가 로드 되었을 때
            {
                rewardedAd7.Show(); // 광고 보여주기
                myCan.sortingOrder = -1;
            }
        }
    }

    public void CreateAndLoadRewardedAd7() // 광고 다시 로드하는 함수
    {
        rewardedAd7 = new RewardedAd(rewardID);

        rewardedAd7.OnUserEarnedReward += HandleUserEarnedReward7;
        rewardedAd7.OnAdClosed += HandleRewardedAdClosed7;

        AdRequest request7 = new AdRequest.Builder().Build();
        rewardedAd7.LoadAd(request7);
    }

    public void HandleRewardedAdClosed7(object sender, System.EventArgs args)
    {  // 사용자가 광고를 닫았을 때
        CreateAndLoadRewardedAd7();  // 광고 다시 로드
    }

    private void HandleUserEarnedReward7(object sender, Reward e)
    {  // 광고를 다 봤을 때
        rewarded7 = true; // 변수 true
        PlayerPrefs.SetInt("Serotonin", S + 1000);
        PlayerPrefs.SetInt("SSerotonin", SS + 1000);
        Views7.SetActive(false);
        PlayerPrefs.SetInt("Day7", 1);
    }



    // Start is called before the first frame update
    void Start()
    {
        // 출석체크 리워드 광고 
        rewardedAd = new RewardedAd(rewardID);
        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request); // 광고 로드

        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // 사용자가 광고를 끝까지 시청했을 때
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        // 사용자가 광고를 중간에 닫았을 때

        rewardedAd2 = new RewardedAd(rewardID);
        AdRequest request2 = new AdRequest.Builder().Build();
        rewardedAd2.LoadAd(request); // 광고 로드

        rewardedAd2.OnUserEarnedReward += HandleUserEarnedReward2;
        // 사용자가 광고를 끝까지 시청했을 때
        rewardedAd2.OnAdClosed += HandleRewardedAdClosed2;
        // 사용자가 광고를 중간에 닫았을 때

        rewardedAd3 = new RewardedAd(rewardID);
        AdRequest request3 = new AdRequest.Builder().Build();
        rewardedAd3.LoadAd(request); // 광고 로드

        rewardedAd3.OnUserEarnedReward += HandleUserEarnedReward3;
        // 사용자가 광고를 끝까지 시청했을 때
        rewardedAd3.OnAdClosed += HandleRewardedAdClosed3;
        // 사용자가 광고를 중간에 닫았을 때

        rewardedAd4 = new RewardedAd(rewardID);
        AdRequest request4 = new AdRequest.Builder().Build();
        rewardedAd4.LoadAd(request); // 광고 로드

        rewardedAd4.OnUserEarnedReward += HandleUserEarnedReward4;
        // 사용자가 광고를 끝까지 시청했을 때
        rewardedAd4.OnAdClosed += HandleRewardedAdClosed4;
        // 사용자가 광고를 중간에 닫았을 때

        rewardedAd5 = new RewardedAd(rewardID);
        AdRequest request5 = new AdRequest.Builder().Build();
        rewardedAd5.LoadAd(request); // 광고 로드

        rewardedAd5.OnUserEarnedReward += HandleUserEarnedReward5;
        // 사용자가 광고를 끝까지 시청했을 때
        rewardedAd5.OnAdClosed += HandleRewardedAdClosed5;
        // 사용자가 광고를 중간에 닫았을 때

        rewardedAd6 = new RewardedAd(rewardID);
        AdRequest request6 = new AdRequest.Builder().Build();
        rewardedAd6.LoadAd(request); // 광고 로드

        rewardedAd6.OnUserEarnedReward += HandleUserEarnedReward6;
        // 사용자가 광고를 끝까지 시청했을 때
        rewardedAd6.OnAdClosed += HandleRewardedAdClosed6;
        // 사용자가 광고를 중간에 닫았을 때

        rewardedAd7 = new RewardedAd(rewardID);
        AdRequest request7 = new AdRequest.Builder().Build();
        rewardedAd7.LoadAd(request); // 광고 로드

        rewardedAd7.OnUserEarnedReward += HandleUserEarnedReward7;
        // 사용자가 광고를 끝까지 시청했을 때
        rewardedAd7.OnAdClosed += HandleRewardedAdClosed7;
        // 사용자가 광고를 중간에 닫았을 때

        // 출석체크 리워드 광고 끝 ---------



        // 사운드
        PlayerPrefs.GetInt("sound", 1);
        PlayerPrefs.GetInt("sfx", 1);

        // 처음 플레이 여부
        PlayerPrefs.GetInt("Play", 0);
        // 각 스테이지 클리어 여부 - 하드모드
        PlayerPrefs.GetInt("StageClear1", 0);
        PlayerPrefs.GetInt("StageClear2", 0);
        PlayerPrefs.GetInt("StageClear3", 0);
        PlayerPrefs.GetInt("StageClear4", 0);
        PlayerPrefs.GetInt("StageClear5", 0);
        // 각 스테이지 클리어 여부 - 이지모드
        PlayerPrefs.GetInt("StageClearE1", 0);
        PlayerPrefs.GetInt("StageClearE2", 0);
        PlayerPrefs.GetInt("StageClearE3", 0);
        PlayerPrefs.GetInt("StageClearE4", 0);
        PlayerPrefs.GetInt("StageClearE5", 0);
        // 도파민, 세로토닌 저장
        D=PlayerPrefs.GetInt("Dopamine", 0);
        // 누적 도파민
        DD = PlayerPrefs.GetInt("DDopamine", 0);
        S =PlayerPrefs.GetInt("Serotonin", 0);
        // 누적 세로토닌
        SS =PlayerPrefs.GetInt("SSerotonin", 0);
        // 각 스테이지 최고 점수 - 하드모드
        PlayerPrefs.GetInt("BestScore1", 0);
        PlayerPrefs.GetInt("BestScore2", 0);
        PlayerPrefs.GetInt("BestScore3", 0);
        PlayerPrefs.GetInt("BestScore4", 0);
        PlayerPrefs.GetInt("BestScore5", 0);
        // 각 스테이지 최고 점수 - 이지모드
        PlayerPrefs.GetInt("BestScoreE1", 0);
        PlayerPrefs.GetInt("BestScoreE2", 0);
        PlayerPrefs.GetInt("BestScoreE3", 0);
        PlayerPrefs.GetInt("BestScoreE4", 0);
        PlayerPrefs.GetInt("BestScoreE5", 0);
        // 아이템 스킨 저장
        PlayerPrefs.GetInt("Item1", 0);
        PlayerPrefs.GetInt("Item2", 0);
        PlayerPrefs.GetInt("Item3", 0);
        PlayerPrefs.GetInt("Item4", 0);
        PlayerPrefs.GetInt("Item5", 0);
        // 출석체크 저장
        PlayerPrefs.GetInt("Day1", 0);
        PlayerPrefs.GetInt("Day2", 0);
        PlayerPrefs.GetInt("Day3", 0);
        PlayerPrefs.GetInt("Day4", 0);
        PlayerPrefs.GetInt("Day5", 0);
        PlayerPrefs.GetInt("Day6", 0);
        PlayerPrefs.GetInt("Day7", 0);
        // 날짜 바뀌는 여부
        PlayerPrefs.GetInt("DayCheck", 0);
        PlayerPrefs.GetInt("DayCheck2", 0);
        PlayerPrefs.GetInt("MonthCheck", 0);
        PlayerPrefs.GetInt("YearCheck", 0);
        // 스킨 장착 여부
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
        // 보물상자
        PlayerPrefs.GetInt("TreasureEasy", 0);
        PlayerPrefs.GetInt("TreasureHard", 0);
        // 광고 제거
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

    // 초기화 버튼
    public void ResetBtn()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // 사운드
        PlayerPrefs.SetInt("sound", 1);
        PlayerPrefs.SetInt("sfx", 1);
    }

    
    // 시간 추가
    public void AddDay()
    {
        /* // 버튼 누르면 1시간 추가
         Now = Now + ts;
         Debug.Log(Now);*/

        PlayerPrefs.SetInt("DayCheck", 10);
        PlayerPrefs.SetInt("DayCheck2", 10);
    }
    // 현재 시간 출력 버튼
    public void TimeBtn()
    {
        Debug.Log(Now);
    }

    // Update is called once per frame
    void Update()
    {
        // 리워드 광고
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

        // 사운드
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


            // 7일차 모두 받았을 때
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

        // 와르르 보물상자 하루 지나면 초기화
        if (DateTime.Now.Day != PlayerPrefs.GetInt("DayCheck2"))
        {
            PlayerPrefs.SetInt("OPEN", 0);
            PlayerPrefs.SetInt("DayCheck2", DateTime.Now.Day);
        }




        // 저장된 날짜와 오늘 날짜가 다르다면
        /*
        if (DateTime.Now.Day != PlayerPrefs.GetInt("DayCheck") || DateTime.Now.Month!=PlayerPrefs.GetInt("MonthCheck"))
        {
            DayBtns[0].interactable = true;
            PlayerPrefs.SetInt("DayCheck", DateTime.Now.Day);
            PlayerPrefs.SetInt("MonthCheck", DateTime.Now.Month);

        }*/


        // 안드로이드 back버튼으로 게임 종료
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscapeView.SetActive(true);
        }

        // 출석체크 완료 버튼 색상 변경
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

    // 게임종료
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

    // 게임시작 버튼
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

    // 상점 버튼
    public void ClickStore()
    {
        click.Play();
        SceneManager.LoadScene(9);
    }

    // 스토리 버튼
    public void ClickStory()
    {
        click.Play();
        SceneManager.LoadScene(7);
    }

    // 설정 창 열기
    public void ClickSetting()
    {
        click.Play();
        SettingView.SetActive(true);
    }

    // 설정 창 닫기
    public void ClickSettingClose()
    {
        click.Play();
        SettingView.SetActive(false);
    }

    // 버그 신고 창 열기
    public void ClickHelp()
    {
        click.Play();
        HelpView.SetActive(true);
    }

    // 버그 신고 창 닫기
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

    // 홈화면에서 출석체크 버튼
    public void DayBtn()
    {
        click.Play();
        DayView.SetActive(true);
    }

    // 출석체크 뷰 닫기 버튼
    public void DayCloseBtn()
    {
        click.Play();
        DayView.SetActive(false);
    }

    // day버튼
    public void DayBtn1()
    {
        click.Play();
        Views1.SetActive(true);
    }

    // Views 닫기 버튼
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


    // 출석체크 세로토닌 보상 받기
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

    // 사운드
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
