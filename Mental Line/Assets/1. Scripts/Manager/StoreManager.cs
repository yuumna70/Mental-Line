using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class StoreManager : MonoBehaviour
{
    // 탭 내용 뷰
    public GameObject TapView1;
    public GameObject TapView2;
    public GameObject TapView3;
    public GameObject TapView4;

    public Text Dopamine;
    int docount, secount;
    public Text Serotonin;

    private int D;
    private int S;
    private int O;

    // 스킨 선택 뷰
    public GameObject[] View1;

    // 환전소 - 도파민 세로토닌
    public GameObject d;
    public GameObject d2;
    // 환전소 - 도파민 부족 창
    public GameObject dd;

    // 아이템 구매 - 장착하기, 스토리 버튼 비활성화
    // 스킨 -> 스킨 선택 -> 금액 버튼
    public Button[] BuyItemBtn1;
    // 스킨 -> 스킨 선택 -> 장착하기 버튼
    public Button[] BuyFitBtn1;
    // 스킨 -> 스킨 선택 버튼
    public Button[] BuyBtns;
    // 스킨 장착했을 때 스킨 버튼 우측 상단에 표시되는 이미지
    public GameObject[] FitImages;
    // 스킨 -> 스킨 선택 -> 구매하기 팝업창들
    public GameObject[] BuyView;
    // 스킨 -> 스킨 선택 -> 구매하기 -> 구매 완료 팝업창들
    public GameObject[] BuyComView;
    // 스킨 구매 시 세로토닌 부족 팝업창
    public GameObject noView;
    // 스킨 -> 스킨 선택 -> 구매 시 스토리 버튼
    public Button[] StoryBtns;
    // 스토리 뷰
    public GameObject[] StoryViews;

    // 보물상자 시처하기 뷰
    public GameObject OpenView;
    // 보물상자 세로토닌 결과 뷰
    public GameObject[] Rewards;
    // 오픈 남은 개수
    public Text Open;
    // 보물상자 버튼
    public Button OpenBtn;

    public AudioSource click;
    public AudioSource buy;

    // 히든 스킨 이름 
    public Text h16;
    public Text h17;
    public GameObject h6;
    public GameObject h7;

    // 히든 팝업창
    public GameObject hd;
    int H;

    // 재화 정보창
    public GameObject Doview;
    public GameObject Seview;

    // 리워드 광고
    //private RewardedAd rewardedAd;
    public Canvas myCan;

    // 실제 광고 ID
    private string rewardID; // = "ca-app-pub-4101740431730513/5910670487";

    private RewardedAd rewardedAd;

    private bool rewarded = false;

    // 스킨 구매하기 창 조각 이미지
    public Image[] img;

    // 누적 세로토닌
    int s;

    public Button Noads;

    private void Start()
    {
        rewardedAd = new RewardedAd(rewardID);
        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request); // 광고 로드

        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // 사용자가 광고를 끝까지 시청했을 때
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        // 사용자가 광고를 중간에 닫았을 때

        Time.timeScale = 1;

        D = PlayerPrefs.GetInt("Dopamine", 0);
        S = PlayerPrefs.GetInt("Serotonin", 0);
        s = PlayerPrefs.GetInt("SSerotonin");
        // 아이템 스킨 저장
        PlayerPrefs.GetInt("Item0", 0);
        PlayerPrefs.SetInt("Item0", 1);
        PlayerPrefs.GetInt("Item1", 0);
        PlayerPrefs.GetInt("Item2", 0);
        PlayerPrefs.GetInt("Item3", 0);
        PlayerPrefs.GetInt("Item4", 0);
        PlayerPrefs.GetInt("Item6", 0);
        PlayerPrefs.GetInt("Item7", 0);
        PlayerPrefs.GetInt("Item8", 0);
        PlayerPrefs.GetInt("Item9", 0);
        PlayerPrefs.GetInt("Item10", 0);
        PlayerPrefs.GetInt("Item11", 0);
        PlayerPrefs.GetInt("Item12", 0);
        PlayerPrefs.GetInt("Item13", 0);
        PlayerPrefs.GetInt("Item14", 0);
        PlayerPrefs.GetInt("Item15", 0);
        //PlayerPrefs.GetInt("Item16", 0);
        //PlayerPrefs.GetInt("Item17", 0);
        //PlayerPrefs.SetInt("Item17", 1);
        // 스킨 장착했는지 확인
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
        // 해금 스킨 팝업창
        H = PlayerPrefs.GetInt("HD", 0);
        // 오픈 남은 개수
        O = PlayerPrefs.GetInt("OPEN", 0);

        Count();
        OpenCount();

        // 아이템 구매 전 장착하기, 스토리 버튼 비활성화
        for (int i = 0; i < 18; i++)
        {
            BuyFitBtn1[i].interactable = false;
            StoryBtns[i].interactable = false;
        }

        // 환전소
        PlayerPrefs.GetInt("Change", 0);

        BuyBtns[16].interactable = false;
        BuyBtns[17].interactable = false;


    }

    // 리워드 광고
    public void UserChoseToWatchAd()
    {
        click.Play();
        if (PlayerPrefs.GetInt("Noads") == 1)
        {
            Ran();
            PlayerPrefs.SetInt("OPEN", O + 1);
            OpenCount();
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
        Time.timeScale = 1;
        Ran();
        PlayerPrefs.SetInt("OPEN", O + 1);
        OpenCount();
    }


    // 아이템 1번 샀을 때 버튼들의 활성화 / 비활성화와 버튼 색깔 변경
    private void Update()
    {
        if (PlayerPrefs.GetInt("Noads") == 1)
        {
            Noads.interactable = false;
        }

        // 와르르 보물상자 초기화
        if (System.DateTime.Now.Hour == 24)
        {
            PlayerPrefs.SetInt("OPEN", 0);
        }

        // 리워드 광고
        if (rewarded)
        {
            rewarded = false;
        }

        // 히든 팝업창 닫기
        if (PlayerPrefs.GetInt("HD")>=1)
        {
            hd.SetActive(false);
        }

        // 보물상자 3회
        if(PlayerPrefs.GetInt("OPEN") == 3)
        {
            OpenBtn.interactable = false;
        }


        // 히든 스킨
        for (int i = 16; i < 18; i++)
        {
            BuyItemBtn1[i].interactable = false;
            BuyFitBtn1[i].interactable = true;
            StoryBtns[i].interactable = true;
        }

        // 히든 스킨 열리는 조건
        if ((PlayerPrefs.GetInt("Item1") == 1) && (PlayerPrefs.GetInt("Item2") == 1) && (PlayerPrefs.GetInt("Item3") == 1) && (PlayerPrefs.GetInt("Item4") == 1) && (PlayerPrefs.GetInt("Item5") == 1)
            && (PlayerPrefs.GetInt("Item6") == 1) && (PlayerPrefs.GetInt("Item7") == 1) && (PlayerPrefs.GetInt("Item8") == 1) && (PlayerPrefs.GetInt("Item9") == 1) && (PlayerPrefs.GetInt("Item10") == 1)
            && (PlayerPrefs.GetInt("Item11") == 1) && (PlayerPrefs.GetInt("Item12") == 1) && (PlayerPrefs.GetInt("Item13") == 1) && (PlayerPrefs.GetInt("Item14") == 1) && (PlayerPrefs.GetInt("Item15") == 1))
        {
            BuyBtns[16].interactable = true;
            h6.SetActive(true);
            BuyBtns[17].interactable = true;
            h7.SetActive(true);

            if (PlayerPrefs.GetInt("HD") == 0)
            {
                hd.SetActive(true);
            }
               
        }

        if (PlayerPrefs.GetInt("Noads") == 1)
        {
            BuyBtns[16].interactable = true;
            h6.SetActive(true);
            BuyBtns[17].interactable = true;
            h7.SetActive(true);

            if (PlayerPrefs.GetInt("HD") == 0)
            {
                hd.SetActive(true);
            }
        }



            if (BuyBtns[16].interactable == false)
        {
            h16.text = "???";
        }
        if (BuyBtns[17].interactable == false)
        {
            h17.text = "???";
        }

        // 스킨 샀을 때 장착하기, 스토리 버튼 활성화 + 구매하기 버튼 비활성화 + 구매한 버튼의 색상 변경
        for (int i = 0; i < 16; i++)
        {
            int j = i + 1;
            if (PlayerPrefs.GetInt($"Item{i}") == 1)
            {
                BuyItemBtn1[i].interactable = false;
                
                BuyFitBtn1[i].interactable = true;
                StoryBtns[i].interactable = true;

                ColorBlock colorBlock = BuyBtns[i].colors;
                colorBlock.normalColor = new Color(1f, 0.8f, 0.4f, 1f);
                colorBlock.highlightedColor = new Color(0.9f, 0.5f, 0.2f, 1f);
                colorBlock.pressedColor = new Color(0.9f, 0.5f, 0.2f, 1f);
                colorBlock.selectedColor = new Color(1f, 0.8f, 0.4f, 1f);
                BuyBtns[i].colors = colorBlock;

            }
        }
        // 장착했을 때 버튼에 표시 이미지 1 - 5
        for (int i = 0; i < 18; i++)
        {
            if (PlayerPrefs.GetInt($"Fit{i}") == 1)
            {
                BuyComView[i].SetActive(false);
                
                for (int j = 0; j < 18; j++)
                {
                    FitImages[j].SetActive(false);
                }
                FitImages[i].SetActive(true);
            }
        }
        

    }
    // 히든 팝업창 닫기
    public void hdClose()
    {
        PlayerPrefs.SetInt("HD", H + 1);
        hd.SetActive(false);
    }

    // 상점 창 닫기
    public void ClickStoreClose()
    {
        click.Play();
        SceneManager.LoadScene(0);
    }

    // 탭 선택 -> 내용 true / false
    public void Btn1()
    {
        click.Play();
        TapView1.SetActive(true);
        TapView2.SetActive(false);
        TapView3.SetActive(false);
        TapView4.SetActive(false);
    }

    public void Btn2()
    {
        click.Play();
        TapView2.SetActive(true);
        TapView1.SetActive(false);
        TapView3.SetActive(false);
        TapView4.SetActive(false);
    }

    public void Btn3()
    {
        click.Play();
        TapView3.SetActive(true);
        TapView2.SetActive(false);
        TapView1.SetActive(false);
        TapView4.SetActive(false);
    }

    public void Btn4()
    {
        click.Play();
        TapView4.SetActive(true);
        TapView2.SetActive(false);
        TapView3.SetActive(false);
        TapView1.SetActive(false);
    }



    // ClickBuyView = 스킨 구매하기 팝업창 보기 + 닫기
    public void ClickBuyView0() // 스킨 구매하기 팝업창 보기
    {
        click.Play();
        BuyView[0].SetActive(true);
    }

    public void ClickBuyViewClose0() // 스킨 구매하기 팝업창 닫기
    {
        click.Play();
        BuyView[0].SetActive(false);
    }
    public void ClickBuyView1() // 스킨 구매하기 팝업창 보기
    {
        click.Play();
        BuyView[1].SetActive(true);
    }

    public void ClickBuyViewClose1() // 스킨 구매하기 팝업창 닫기
    {
        click.Play();
        BuyView[1].SetActive(false);
    }
    public void ClickBuyView2() // 스킨 구매하기 팝업창 보기 
    {
        click.Play();
        BuyView[2].SetActive(true);
        
    }
    public void ClickBuyViewClose2()
    {
        click.Play();
        BuyView[2].SetActive(false);
    }
    public void ClickBuyView3()
    {
        click.Play();

        BuyView[3].SetActive(true);
        
    }
    public void ClickBuyViewClose3()
    {
        click.Play();
        BuyView[3].SetActive(false);
    }
    public void ClickBuyView4()
    {
        click.Play();
        BuyView[4].SetActive(true);
    }
    public void ClickBuyViewClose4()
    {
        click.Play();
        BuyView[4].SetActive(false);
    }
    public void ClickBuyView5()
    {
        click.Play();
        BuyView[5].SetActive(true);
        
    }
    public void ClickBuyViewClose5()
    {
        click.Play();
        BuyView[5].SetActive(false);
    }
    public void ClickBuyView6()
    {
        click.Play();
        BuyView[6].SetActive(true);

    }
    public void ClickBuyViewClose6()
    {
        click.Play();
        BuyView[6].SetActive(false);
    }
    public void ClickBuyView7()
    {
        click.Play();
        BuyView[7].SetActive(true);

    }
    public void ClickBuyViewClose7()
    {
        click.Play();
        BuyView[7].SetActive(false);
    }
    public void ClickBuyView8()
    {
        click.Play();
        BuyView[8].SetActive(true);

    }
    public void ClickBuyViewClose8()
    {
        click.Play();
        BuyView[8].SetActive(false);
    }
    public void ClickBuyView9()
    {
        click.Play();
        BuyView[9].SetActive(true);

    }
    public void ClickBuyViewClose9()
    {
        click.Play();
        BuyView[9].SetActive(false);
    }
    public void ClickBuyView10()
    {
        click.Play();
        BuyView[10].SetActive(true);

    }
    public void ClickBuyViewClose10()
    {
        click.Play();
        BuyView[10].SetActive(false);
    }
    public void ClickBuyView11()
    {
        click.Play();
        BuyView[11].SetActive(true);

    }
    public void ClickBuyViewClose11()
    {
        click.Play();
        BuyView[11].SetActive(false);
    }
    public void ClickBuyView12()
    {
        click.Play();
        BuyView[12].SetActive(true);

    }
    public void ClickBuyViewClose12()
    {
        click.Play();
        BuyView[12].SetActive(false);
    }
    public void ClickBuyView13()
    {
        click.Play();
        BuyView[13].SetActive(true);

    }
    public void ClickBuyViewClose13()
    {
        click.Play();
        BuyView[13].SetActive(false);
    }
    public void ClickBuyView14()
    {
        click.Play();
        BuyView[14].SetActive(true);

    }
    public void ClickBuyViewClose14()
    {
        click.Play();
        BuyView[14].SetActive(false);
    }
    public void ClickBuyView15()
    {
        click.Play();
        BuyView[15].SetActive(true);

    }
    public void ClickBuyViewClose15()
    {
        click.Play();
        BuyView[15].SetActive(false);
    }
    public void ClickBuyView16()
    {
        click.Play();
        BuyView[16].SetActive(true);

    }
    public void ClickBuyViewClose16()
    {
        click.Play();
        BuyView[16].SetActive(false);
    }
    public void ClickBuyView17()
    {
        click.Play();
        BuyView[17].SetActive(true);

    }
    public void ClickBuyViewClose17()
    {
        click.Play();
        BuyView[17].SetActive(false);
    }
    public void ClickBuyView18()
    {
        click.Play();
        BuyView[18].SetActive(true);

    }
    public void ClickBuyViewClose18()
    {
        click.Play();
        BuyView[18].SetActive(false);
    }

    // 스킨 구매하기 팝업창 끝


    // 스킨 구매하기 완료 팝업창 나가기 버튼
    public void ClickBuyComClose0()
    {
        click.Play();
        BuyComView[0].SetActive(false);
        // 씬 새로고침
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ClickBuyComClose1()
    {
        click.Play();
        BuyComView[1].SetActive(false);
        // 씬 새로고침
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ClickBuyComClose2()
    {
        click.Play();
        BuyComView[2].SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ClickBuyComClose3()
    {
        click.Play();
        BuyComView[3].SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ClickBuyComClose4()
    {
        click.Play();
        BuyComView[4].SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ClickBuyComClose5()
    {
        click.Play();
        BuyComView[5].SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ClickBuyComClose6()
    {
        click.Play();
        BuyComView[6].SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ClickBuyComClose7()
    {
        click.Play();
        BuyComView[7].SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ClickBuyComClose8()
    {
        click.Play();
        BuyComView[8].SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ClickBuyComClose9()
    {
        click.Play();
        BuyComView[9].SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ClickBuyComClose10()
    {
        click.Play();
        BuyComView[10].SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ClickBuyComClose11()
    {
        click.Play();
        BuyComView[11].SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ClickBuyComClose12()
    {
        click.Play();
        BuyComView[12].SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ClickBuyComClose13()
    {
        click.Play();
        BuyComView[13].SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ClickBuyComClose14()
    {
        click.Play();
        BuyComView[14].SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ClickBuyComClose15()
    {
        click.Play();
        BuyComView[15].SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ClickBuyComClose16()
    {
        click.Play();
        BuyComView[16].SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ClickBuyComClose17()
    {
        click.Play();
        BuyComView[17].SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ClickBuyComClose18()
    {
        click.Play();
        BuyComView[18].SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    // 스킨 구매하기 완료 나가기 버튼 끝




    // ClickBtn1 = 스킨 탭에서 캐릭터 스킨 선택 버튼
    public void ClickBtn0()
    {
        click.Play();
        // 스킨 설명창 나오도록 (이름 + 이미지 + 구매하기 + 장착하기 + 스토리형식 창)
        View1[0].SetActive(true);
    }
    // 스킨 탭에서 캐릭터 스킨창 좌측 상단 닫기 버튼
    public void CloseBtn0()
    {
        click.Play();
        View1[0].SetActive(false);
    }
    public void ClickBtn1()
    {
        click.Play();
        // 스킨 설명창 나오도록 (이름 + 이미지 + 구매하기 + 장착하기 + 스토리형식 창)
        View1[1].SetActive(true);
    }
    // 스킨 탭에서 캐릭터 스킨창 좌측 상단 닫기 버튼
    public void CloseBtn1()
    {
        click.Play();
        View1[1].SetActive(false);
    }
    public void ClickBtn2()
    {
        click.Play();
        View1[2].SetActive(true);
    }
    public void CloseBtn2()
    {
        click.Play();
        View1[2].SetActive(false);
    }
    public void ClickBtn3()
    {
        click.Play();
        View1[3].SetActive(true);
    }
    public void CloseBtn3()
    {
        click.Play();
        View1[3].SetActive(false);
    }
    public void ClickBtn4()
    {
        click.Play();
        View1[4].SetActive(true);
    }
    public void CloseBtn4()
    {
        click.Play();
        View1[4].SetActive(false);
    }
    public void ClickBtn5()
    {
        click.Play();
        View1[5].SetActive(true);
    }
    public void CloseBtn5()
    {
        click.Play();
        View1[5].SetActive(false);
    }
    public void ClickBtn6()
    {
        click.Play();
        View1[6].SetActive(true);
    }
    public void CloseBtn6()
    {
        click.Play();
        View1[6].SetActive(false);
    }
    public void ClickBtn7()
    {
        click.Play();
        View1[7].SetActive(true);
    }
    public void CloseBtn7()
    {
        click.Play();
        View1[7].SetActive(false);
    }
    public void ClickBtn8()
    {
        click.Play();
        View1[8].SetActive(true);
    }
    public void CloseBtn8()
    {
        click.Play();
        View1[8].SetActive(false);
    }
    public void ClickBtn9()
    {
        click.Play();
        View1[9].SetActive(true);
    }
    public void CloseBtn9()
    {
        click.Play();
        View1[9].SetActive(false);
    }
    public void ClickBtn10()
    {
        click.Play();
        View1[10].SetActive(true);
    }
    public void CloseBtn10()
    {
        click.Play();
        View1[10].SetActive(false);
    }
    public void ClickBtn11()
    {
        click.Play();
        View1[11].SetActive(true);
    }
    public void CloseBtn11()
    {
        click.Play();
        View1[11].SetActive(false);
    }
    public void ClickBtn12()
    {
        click.Play();
        View1[12].SetActive(true);
    }
    public void CloseBtn12()
    {
        click.Play();
        View1[12].SetActive(false);
    }
    public void ClickBtn13()
    {
        click.Play();
        View1[13].SetActive(true);
    }
    public void CloseBtn13()
    {
        click.Play();
        View1[13].SetActive(false);
    }
    public void ClickBtn14()
    {
        click.Play();
        View1[14].SetActive(true);
    }
    public void CloseBtn14()
    {
        click.Play();
        View1[14].SetActive(false);
    }
    public void ClickBtn15()
    {
        click.Play();
        View1[15].SetActive(true);
    }
    public void CloseBtn15()
    {
        click.Play();
        View1[15].SetActive(false);
    }
    public void ClickBtn16()
    {
        click.Play();
        View1[16].SetActive(true);
    }
    public void CloseBtn16()
    {
        click.Play();
        View1[16].SetActive(false);
    }
    public void ClickBtn17()
    {
        click.Play();
        View1[17].SetActive(true);
    }
    public void CloseBtn17()
    {
        click.Play();
        View1[17].SetActive(false);
    }
    public void ClickBtn18()
    {
        click.Play();
        View1[18].SetActive(true);
    }
    public void CloseBtn18()
    {
        click.Play();
        View1[18].SetActive(false);
    }


    // 스킨 팝업창 9개 끝






    // 보물상자
    public void ClickAds()
    {
        click.Play();
        OpenView.SetActive(true);
    }
    // 보물상자 - 시청하기 버튼
    public void ClickAdsBtn()
    {
        click.Play();
        
        /*RewardAds();
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
            myCan.sortingOrder = -1;
        }*/

        if(PlayerPrefs.GetInt("Noads") == 1)
        {
            Ran();
            PlayerPrefs.SetInt("OPEN", O + 1);
            OpenCount();
        }
        else if (PlayerPrefs.GetInt("Noads") == 0)
        {
            /*RewardAds();
            if (this.rewardedAd.IsLoaded())
            {
                this.rewardedAd.Show();
                myCan.sortingOrder = -1;
            }*/
        }
        /*Ran();
        PlayerPrefs.SetInt("OPEN", O + 1);
        OpenCount();*/
        
    }

    // 세로토닌 랜덤으로 확률....
    public void Ran()
    {
        int a = Random.Range(0, 100);

        switch (a)
        {
            case 0:
                Rewards[5].SetActive(true);
                break;

            case 1:
            case 2:
            case 3:
           
                Rewards[4].SetActive(true);
                break;

            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
            
                Rewards[3].SetActive(true);
                break;

            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
            case 21:
            case 22:
            case 23:
            case 24:
            case 25:
            case 26:
            case 27:
            case 28:
            
                Rewards[2].SetActive(true);
                break;
            case 29:
            case 30:
            case 31:
            case 32:
            case 33:
            case 34:
            case 35:
            case 36:
            case 37:
            case 38:
            case 39:
            case 40:
            case 41:
            case 42:
            case 43:
            case 44:
            case 45:
            case 46:
            case 47:
            case 48:
            case 49:
            case 50:
            case 51:
            case 52:
            case 53:
            case 54:
            case 55:
            case 56:
            case 57:
            case 58:
            
                Rewards[1].SetActive(true);
                break;
            case 59:
            case 60:
            case 61:
            case 62:
            case 63:
            case 64:
            case 65:
            case 66:
            case 67:
            case 68:
            case 69:
            case 70:
            case 71:
            case 72:
            case 73:
            case 74:
            case 75:
            case 76:
            case 77:
            case 78:
            case 79:
            case 80:
            case 81:
            case 82:
            case 83:
            case 84:
            case 85:
            case 86:
            case 87:
            case 88:
            case 89:
            case 90:
            case 91:
            case 92:
            case 93:
            case 94:
            case 95:
            case 96:
            case 97:
            case 98:
            case 99:
                Rewards[0].SetActive(true);
                break;
        }

    }

    public void OpenCount()
    {
        Open.text = PlayerPrefs.GetInt("OPEN", O).ToString();
        O = PlayerPrefs.GetInt("OPEN", O);
    }

    // 세로토닌 보상 닫기 + 세로토닌 플러스
    public void RewardClose1()
    {
        click.Play();
        Rewards[0].SetActive(false);
        OpenView.SetActive(false);
        PlayerPrefs.SetInt("Serotonin", S + 50);
        PlayerPrefs.SetInt("SSerotonin", s + 50);
        OpenCount();
        Count();
    }
    public void RewardClose2()
    {
        click.Play();
        Rewards[1].SetActive(false);
        OpenView.SetActive(false);
        PlayerPrefs.SetInt("Serotonin", S + 100);
        PlayerPrefs.SetInt("SSerotonin", s + 100);
        OpenCount();
        Count();
    }
    public void RewardClose3()
    {
        click.Play();
        Rewards[2].SetActive(false);
        OpenView.SetActive(false);
        PlayerPrefs.SetInt("Serotonin", S + 300);
        PlayerPrefs.SetInt("SSerotonin", s + 300);
        OpenCount();
        Count();
    }
    public void RewardClose4()
    {
        click.Play();
        Rewards[3].SetActive(false);
        OpenView.SetActive(false);
        PlayerPrefs.SetInt("Serotonin", S + 500);
        PlayerPrefs.SetInt("SSerotonin", s + 500);
        OpenCount();
        Count();
    }
    public void RewardClose5()
    {
        click.Play();
        Rewards[4].SetActive(false);
        OpenView.SetActive(false);
        PlayerPrefs.SetInt("Serotonin", S + 1000);
        PlayerPrefs.SetInt("SSerotonin", s + 1000);
        OpenCount();
        Count();
    }
    public void RewardClose6()
    {
        click.Play();
        Rewards[5].SetActive(false);
        OpenView.SetActive(false);
        PlayerPrefs.SetInt("Serotonin", S + 2000);
        PlayerPrefs.SetInt("SSerotonin", s + 2000);
        OpenCount();
        Count();
    }



    // 포춘쿠키 - 광고 취고 버튼
    public void ClickAdsClose()
    {
        click.Play();
        OpenView.SetActive(false);
    }

    



    // 환전소
    public void Clickdopamine1() // 도파민 100개 환전 버튼
    {
        click.Play();
        // 도파민 100개 세로토닌 환전 뷰 열기
        d.SetActive(true);
    }

    public void ClickdopamineClose()
    {
        click.Play();
        // 도파민 100개 세로토닌 환전 뷰 닫기
        d.SetActive(false);
    }

    public void Clickdopamine2() // 도파민 1000개 환전 버튼
    {
        click.Play();
        // 도파민 1000개 세로토닌 환전 뷰 열기
        d2.SetActive(true);
    }

    public void ClickdopamineClose2()
    {
        click.Play();
        // 도파민 1000개 세로토닌 환전 뷰 닫기
        d2.SetActive(false);
    }

    public void Count()
    {
        //Dopamine.text = D.ToString();
        Dopamine.text = PlayerPrefs.GetInt("Dopamine", D).ToString();
        //Serotonin.text = S.ToString();
        Serotonin.text = PlayerPrefs.GetInt("Serotonin", S).ToString();
        D = PlayerPrefs.GetInt("Dopamine", D);
        S = PlayerPrefs.GetInt("Serotonin", S);
    }
    

    // 환전소 도파민 100개 -> 세로토닌 1개
    public void dopamineChange1()
    {
        click.Play();
        if (D >= 100)
        {
            PlayerPrefs.SetInt("Dopamine", D - 100);
            PlayerPrefs.SetInt("Serotonin", S + 1);
            PlayerPrefs.SetInt("SSerotonin", s + 1);
            Count();
            d.SetActive(false);
        }
        // 도파민 부족할 때
        else if(D <100)
        {
            d.SetActive(false);
            dd.SetActive(true);
        }
    }
   

    // 도파민 부족 창 닫기
    public void ddCloseBtn1()
    {
        click.Play();
        dd.SetActive(false);
    }
    
    // 환전소 도파민 1000개 -> 세로토닌 1개
    public void dopamineChange2()
    {
        click.Play();
        if (D >= 1000)
        {
            PlayerPrefs.SetInt("Dopamine", D - 1000);
            PlayerPrefs.SetInt("Serotonin", S + 10);
            PlayerPrefs.SetInt("SSerotonin", s + 10);
            Count();
            d2.SetActive(false);
        }
        else if(D < 1000)
        {
            d2.SetActive(false);
            dd.SetActive(true);
        }
        
    }

    // 스킨 ->  스킨 팝업창 -> 스킨 구매하기 팝업창에서 구매하기 버튼 선택 시 
    public void BuyBtn0()
    {
        if(S >= 500)
        {
            buy.Play();
            PlayerPrefs.SetInt("Serotonin", S - 500);
            PlayerPrefs.SetInt("Item0", 1);
            Count();
            // 스킨 구매하기 팝업창 닫기
            BuyView[0].SetActive(false);
            // 스킨 구매하기 완료 팝업창 열기
            BuyComView[0].SetActive(true);
        }
        else if(S < 500)
        {
            click.Play();
            // 도파민 부족 창
            noView.SetActive(true);
        }
    }
    public void BuyBtn1()
    {
        if (S >= 500)
        {
            buy.Play();
            PlayerPrefs.SetInt("Serotonin", S - 500);
            PlayerPrefs.SetInt("Item1", 1);
            Count();
            // 스킨 구매하기 팝업창 닫기
            BuyView[1].SetActive(false);
            // 스킨 구매하기 완료 팝업창 열기
            BuyComView[1].SetActive(true);
        }
        else if (S < 500)
        {
            click.Play();
            // 도파민 부족 창
            noView.SetActive(true);
        }
    }

    public void BuyBtn2()
    {
        if (S >= 500)
        {
            buy.Play();
            PlayerPrefs.SetInt("Serotonin", S - 500);
            PlayerPrefs.SetInt("Item2", 1);
            Count();
            BuyView[2].SetActive(false);
            BuyComView[2].SetActive(true);
        }
        else if (S < 500)
        {
            click.Play();
            // 도파민 부족 창
            noView.SetActive(true);
        }
    }
    public void BuyBtn3()
    {
        if (S >= 500)
        {
            buy.Play();
            PlayerPrefs.SetInt("Serotonin", S - 500);
            PlayerPrefs.SetInt("Item3", 1);
            Count();
            BuyView[3].SetActive(false);
            BuyComView[3].SetActive(true);
            
        }
        else if (S < 500)
        {
            click.Play();
            // 도파민 부족 창
            noView.SetActive(true);
        }
    }
    public void BuyBtn4()
    {
        if (S >= 500)
        {
            buy.Play();
            PlayerPrefs.SetInt("Serotonin", S - 500);
            PlayerPrefs.SetInt("Item4", 1);
            Count();
            BuyView[4].SetActive(false);
            BuyComView[4].SetActive(true);
            
        }
        else if (S < 500)
        {
            click.Play();
            // 도파민 부족 창
            noView.SetActive(true);
        }
    }
    public void BuyBtn5()
    {
        if (S >= 500)
        {
            buy.Play();
            PlayerPrefs.SetInt("Serotonin", S - 500);
            PlayerPrefs.SetInt("Item5", 1);
            Count();
            BuyView[5].SetActive(false);
            BuyComView[5].SetActive(true);
        }
        else if (S < 500)
        {
            click.Play();
            // 도파민 부족 창
            noView.SetActive(true);
        }
    }
    public void BuyBtn6()
    {
        if (S >= 500)
        {
            buy.Play();
            PlayerPrefs.SetInt("Serotonin", S - 500);
            PlayerPrefs.SetInt("Item6", 1);
            Count();
            BuyView[6].SetActive(false);
            BuyComView[6].SetActive(true);
        }
        else if (S < 500)
        {
            click.Play();
            // 도파민 부족 창
            noView.SetActive(true);
        }
    }
    public void BuyBtn7()
    {
        if (S >= 500)
        {
            buy.Play();
            PlayerPrefs.SetInt("Serotonin", S - 500);
            PlayerPrefs.SetInt("Item7", 1);
            Count();
            BuyView[7].SetActive(false);
            BuyComView[7].SetActive(true);
        }
        else if (S < 500)
        {
            click.Play();
            // 도파민 부족 창
            noView.SetActive(true);
        }
    }
    public void BuyBtn8()
    {
        if (S >= 500)
        {
            buy.Play();
            PlayerPrefs.SetInt("Serotonin", S - 500);
            PlayerPrefs.SetInt("Item8", 1);
            Count();
            BuyView[8].SetActive(false);
            BuyComView[8].SetActive(true);
        }
        else if (S < 500)
        {
            click.Play();
            // 도파민 부족 창
            noView.SetActive(true);
        }
    }
    public void BuyBtn9()
    {
        if (S >= 500)
        {
            buy.Play();
            PlayerPrefs.SetInt("Serotonin", S - 500);
            PlayerPrefs.SetInt("Item9", 1);
            Count();
            BuyView[9].SetActive(false);
            BuyComView[9].SetActive(true);
        }
        else if (S < 500)
        {
            click.Play();
            // 도파민 부족 창
            noView.SetActive(true);
        }
    }
    public void BuyBtn10()
    {
        if (S >= 500)
        {
            buy.Play();
            PlayerPrefs.SetInt("Serotonin", S - 500);
            PlayerPrefs.SetInt("Item10", 1);
            Count();
            BuyView[10].SetActive(false);
            BuyComView[10].SetActive(true);
        }
        else if (S < 500)
        {
            click.Play();
            // 도파민 부족 창
            noView.SetActive(true);
        }
    }
    public void BuyBtn11()
    {
        if (S >= 500)
        {
            buy.Play();
            PlayerPrefs.SetInt("Serotonin", S - 500);
            PlayerPrefs.SetInt("Item11", 1);
            Count();
            BuyView[11].SetActive(false);
            BuyComView[11].SetActive(true);
        }
        else if (S < 500)
        {
            click.Play();
            // 도파민 부족 창
            noView.SetActive(true);
        }
    }
    public void BuyBtn12()
    {
        if (S >= 500)
        {
            buy.Play();
            PlayerPrefs.SetInt("Serotonin", S - 500);
            PlayerPrefs.SetInt("Item12", 1);
            Count();
            BuyView[12].SetActive(false);
            BuyComView[12].SetActive(true);
        }
        else if (S < 500)
        {
            click.Play();
            // 도파민 부족 창
            noView.SetActive(true);
        }
    }
    public void BuyBtn13()
    {
        if (S >= 500)
        {
            buy.Play();
            PlayerPrefs.SetInt("Serotonin", S - 500);
            PlayerPrefs.SetInt("Item13", 1);
            Count();
            BuyView[13].SetActive(false);
            BuyComView[13].SetActive(true);
        }
        else if (S < 500)
        {
            click.Play();
            // 도파민 부족 창
            noView.SetActive(true);
        }
    }
    public void BuyBtn14()
    {
        if (S >= 500)
        {
            buy.Play();
            PlayerPrefs.SetInt("Serotonin", S - 500);
            PlayerPrefs.SetInt("Item14", 1);
            Count();
            BuyView[14].SetActive(false);
            BuyComView[14].SetActive(true);
        }
        else if (S < 500)
        {
            click.Play();
            // 도파민 부족 창
            noView.SetActive(true);
        }
    }
    public void BuyBtn15()
    {
        if (S >= 500)
        {
            buy.Play();
            PlayerPrefs.SetInt("Serotonin", S - 500);
            PlayerPrefs.SetInt("Item15", 1);
            Count();
            BuyView[15].SetActive(false);
            BuyComView[15].SetActive(true);
        }
        else if (S < 500)
        {
            click.Play();
            // 도파민 부족 창
            noView.SetActive(true);
        }
    }
    public void BuyBtn16()
    {
        if (S >= 500)
        {
            buy.Play();
            PlayerPrefs.SetInt("Serotonin", S - 500);
            PlayerPrefs.SetInt("Item16", 1);
            Count();
            BuyView[16].SetActive(false);
            BuyComView[16].SetActive(true);
        }
        else if (S < 500)
        {
            click.Play();
            // 도파민 부족 창
            noView.SetActive(true);
        }
    }
    public void BuyBtn17()
    {
        if (S >= 500)
        {
            buy.Play();
            PlayerPrefs.SetInt("Serotonin", S - 500);
            PlayerPrefs.SetInt("Item17", 1);
            Count();
            BuyView[17].SetActive(false);
            BuyComView[17].SetActive(true);
        }
        else if (S < 500)
        {
            click.Play();
            // 도파민 부족 창
            noView.SetActive(true);
        }
    }
    public void BuyBtn18()
    {
        if (S >= 500)
        {
            buy.Play();
            PlayerPrefs.SetInt("Serotonin", S - 500);
            PlayerPrefs.SetInt("Item18", 1);
            Count();
            BuyView[18].SetActive(false);
            BuyComView[18].SetActive(true);
        }
        else if (S < 500)
        {
            click.Play();
            // 도파민 부족 창
            noView.SetActive(true);
        }
    }





    // 1. 스킨 -> 스킨 팝업창 -> 장착하기 버튼 선택시 
    // 2. 스킨 -> 스킨 팝업창 -> 스킨 구매하기 팝업창 -> 스킨 구매하기 완료 팝업창에서 장착하기 버튼 선택시
    public void ClickBuyFitBtn0()
    {
        click.Play();
        //PlayerPrefs.SetInt("Fit0", 1);
        for (int i = 0; i < 19; i++)
        {
            PlayerPrefs.SetInt($"Fit{i}", 0);
        }
        PlayerPrefs.SetInt("Fit0", 1);
        CloseBtn0();
    }
    public void ClickBuyFitBtn1()
    {
        click.Play();
        for (int i = 0; i < 19; i++)
        {
            PlayerPrefs.SetInt($"Fit{i}", 0);
        }
        PlayerPrefs.SetInt("Fit1", 1);
        CloseBtn1();
        // 씬 새로고침
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ClickBuyFitBtn2()
    {
        click.Play();
        for (int i = 0; i < 19; i++)
        {
            PlayerPrefs.SetInt($"Fit{i}", 0);
        }
        PlayerPrefs.SetInt("Fit2", 1);
        CloseBtn2();
    }
    public void ClickBuyFitBtn3()
    {
        click.Play();
        for (int i = 0; i < 19; i++)
        {
            PlayerPrefs.SetInt($"Fit{i}", 0);
        }
        PlayerPrefs.SetInt("Fit3", 1);
        CloseBtn3();
    }
    public void ClickBuyFitBtn4()
    {
        click.Play();
        for (int i = 0; i < 19; i++)
        {
            PlayerPrefs.SetInt($"Fit{i}", 0);
        }
        PlayerPrefs.SetInt("Fit4", 1);
        CloseBtn4();
    }
    public void ClickBuyFitBtn5()
    {
        click.Play();
        for (int i = 0; i < 19; i++)
        {
            PlayerPrefs.SetInt($"Fit{i}", 0);
        }
        PlayerPrefs.SetInt("Fit5", 1);
        CloseBtn5();
    }
    public void ClickBuyFitBtn6()
    {
        click.Play();
        for (int i = 0; i < 19; i++)
        {
            PlayerPrefs.SetInt($"Fit{i}", 0);
        }
        PlayerPrefs.SetInt("Fit6", 1);
        CloseBtn6();
    }
    public void ClickBuyFitBtn7()
    {
        click.Play();
        for (int i = 0; i < 19; i++)
        {
            PlayerPrefs.SetInt($"Fit{i}", 0);
        }
        PlayerPrefs.SetInt("Fit7", 1);
        CloseBtn7();
    }
    public void ClickBuyFitBtn8()
    {
        click.Play();
        for (int i = 0; i < 19; i++)
        {
            PlayerPrefs.SetInt($"Fit{i}", 0);
        }
        PlayerPrefs.SetInt("Fit8", 1);
        CloseBtn8();
    }
    public void ClickBuyFitBtn9()
    {
        click.Play();
        for (int i = 0; i < 19; i++)
        {
            PlayerPrefs.SetInt($"Fit{i}", 0);
        }
        PlayerPrefs.SetInt("Fit9", 1);
        CloseBtn9();
    }
    public void ClickBuyFitBtn10()
    {
        click.Play();
        for (int i = 0; i < 19; i++)
        {
            PlayerPrefs.SetInt($"Fit{i}", 0);
        }
        PlayerPrefs.SetInt("Fit10", 1);
        CloseBtn10();
    }
    public void ClickBuyFitBtn11()
    {
        click.Play();
        for (int i = 0; i < 19; i++)
        {
            PlayerPrefs.SetInt($"Fit{i}", 0);
        }
        PlayerPrefs.SetInt("Fit11", 1);
        CloseBtn11();
    }
    public void ClickBuyFitBtn12()
    {
        click.Play();
        for (int i = 0; i < 19; i++)
        {
            PlayerPrefs.SetInt($"Fit{i}", 0);
        }
        PlayerPrefs.SetInt("Fit12", 1);
        CloseBtn12();
    }
    public void ClickBuyFitBtn13()
    {
        click.Play();
        for (int i = 0; i < 19; i++)
        {
            PlayerPrefs.SetInt($"Fit{i}", 0);
        }
        PlayerPrefs.SetInt("Fit13", 1);
        CloseBtn13();
    }
    public void ClickBuyFitBtn14()
    {
        click.Play();
        for (int i = 0; i < 19; i++)
        {
            PlayerPrefs.SetInt($"Fit{i}", 0);
        }
        PlayerPrefs.SetInt("Fit14", 1);
        CloseBtn14();
    }
    public void ClickBuyFitBtn15()
    {
        click.Play();
        for (int i = 0; i < 19; i++)
        {
            PlayerPrefs.SetInt($"Fit{i}", 0);
        }
        PlayerPrefs.SetInt("Fit15", 1);
        CloseBtn15();
    }
    public void ClickBuyFitBtn16()
    {
        click.Play();
        for (int i = 0; i < 19; i++)
        {
            PlayerPrefs.SetInt($"Fit{i}", 0);
        }
        PlayerPrefs.SetInt("Fit16", 1);
        CloseBtn16();
    }
    public void ClickBuyFitBtn17()
    {
        click.Play();
        for (int i = 0; i < 19; i++)
        {
            PlayerPrefs.SetInt($"Fit{i}", 0);
        }
        PlayerPrefs.SetInt("Fit17", 1);
        CloseBtn17();
    }
    public void ClickBuyFitBtn18()
    {
        click.Play();
        for (int i = 0; i < 19; i++)
        {
            PlayerPrefs.SetInt($"Fit{i}", 0);
        }
        PlayerPrefs.SetInt("Fit18", 1);
        CloseBtn18();
    }

    // 도파민 부족 창 닫기
    public void noViewClose()
    {
        click.Play();
        noView.SetActive(false);
    }

    public void ADoView()
    {
        click.Play();
        Doview.SetActive(true);
    }
    public void ASeView()
    {
        click.Play();
        Seview.SetActive(true);
    }
    // 재화 정보창
    public void ADoViewClose()
    {
        click.Play();
        Doview.SetActive(false);
    }
    public void ASeViewClose()
    {
        click.Play();
        Seview.SetActive(false);
    }


    // 스킨 구매 시 스토리 뷰 버튼 선택   /  스토리 뷰 닫기
    public void StoryBtn0()
    {
        StoryViews[0].SetActive(true);
    }
    public void aStoryCloseBtn0()
    {
        StoryViews[0].SetActive(false);
    }
    public void StoryBtn1()
    {
        StoryViews[1].SetActive(true);
    }
    public void aStoryCloseBtn1()
    {
        StoryViews[1].SetActive(false);
    }
    public void StoryBtn2()
    {
        StoryViews[2].SetActive(true);
    }
    public void aStoryCloseBtn2()
    {
        StoryViews[2].SetActive(false);
    }
    public void StoryBtn3()
    {
        StoryViews[3].SetActive(true);
    }
    public void aStoryCloseBtn3()
    {
        StoryViews[3].SetActive(false);
    }
    public void StoryBtn4()
    {
        StoryViews[4].SetActive(true);
    }
    public void aStoryCloseBtn4()
    {
        StoryViews[4].SetActive(false);
    }
    public void StoryBtn5()
    {
        StoryViews[5].SetActive(true);
    }
    public void aStoryCloseBtn5()
    {
        StoryViews[5].SetActive(false);
    }
    public void StoryBtn6()
    {
        StoryViews[6].SetActive(true);
    }
    public void aStoryCloseBtn6()
    {
        StoryViews[6].SetActive(false);
    }
    public void StoryBtn7()
    {
        StoryViews[7].SetActive(true);
    }
    public void aStoryCloseBtn7()
    {
        StoryViews[7].SetActive(false);
    }
    public void StoryBtn8()
    {
        StoryViews[8].SetActive(true);
    }
    public void aStoryCloseBtn8()
    {
        StoryViews[8].SetActive(false);
    }
    public void StoryBtn9()
    {
        StoryViews[9].SetActive(true);
    }
    public void aStoryCloseBtn9()
    {
        StoryViews[9].SetActive(false);
    }
    public void StoryBtn10()
    {
        StoryViews[10].SetActive(true);
    }
    public void aStoryCloseBtn10()
    {
        StoryViews[10].SetActive(false);
    }
    public void StoryBtn11()
    {
        StoryViews[11].SetActive(true);
    }
    public void aStoryCloseBtn11()
    {
        StoryViews[11].SetActive(false);
    }
    public void StoryBtn12()
    {
        StoryViews[12].SetActive(true);
    }
    public void aStoryCloseBtn12()
    {
        StoryViews[12].SetActive(false);
    }
    public void StoryBtn13()
    {
        StoryViews[13].SetActive(true);
    }
    public void aStoryCloseBtn13()
    {
        StoryViews[13].SetActive(false);
    }
    public void StoryBtn14()
    {
        StoryViews[14].SetActive(true);
    }
    public void aStoryCloseBtn14()
    {
        StoryViews[14].SetActive(false);
    }
    public void StoryBtn15()
    {
        StoryViews[15].SetActive(true);
    }
    public void aStoryCloseBtn15()
    {
        StoryViews[15].SetActive(false);
    }
    public void StoryBtn16()
    {
        StoryViews[16].SetActive(true);
    }
    public void aStoryCloseBtn16()
    {
        StoryViews[16].SetActive(false);
    }
    public void StoryBtn17()
    {
        StoryViews[17].SetActive(true);
    }
    public void aStoryCloseBtn17()
    {
        StoryViews[17].SetActive(false);
    }



}