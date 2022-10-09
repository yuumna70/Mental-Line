using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;  // ���鱤��

public class Player : MonoBehaviour
{
    public GameObject startBlock;
    string log;

    private float Speed=6.5f;
    private SpringJoint spring;
    private Grappling grappling;
    private Rigidbody rig;
    private int start;
    private int index;
    private int indexE;
    private int dopamine;
    private int serotonin;
    private GameObject hook;

    // ����
    public AudioSource dead;
    public AudioSource clear;
    public AudioSource[] BGM;
    public AudioSource Mon;
    public AudioSource com;

    // �ִϸ�����
    private Animator PlayerAnimator;

    // �ְ� ���� �ؽ�Ʈ
    private int BestScore;
    private int BestScoreE;

    // ���������� ���� �ؽ�Ʈ
    public Text SuccessScore;

    // ����
    public int targetScore;

    // �׾��� ��
    public GameObject DeadView;
    
    // ������
    public GameObject FirstDestinationView;
    public GameObject DestinaionView;
    public Text TotalScore;
    [HideInInspector]
    public bool Clear;

    // ���Ĺ�, �������
    public Text Dopamine;
    public Text Dopamine2;
    public Text Serotonin;
    public Text Serotonin2;
    public int scoreSum=0;
    private int itemCount;
    private int itemCount2;

    

    // ���� ���
    public GameObject Warning;

    // �޺�
    private int ComboCount;
    public GameObject ComboView;

    // ����Ʈ
    public ParticleSystem particle;

    // ���� �� ī��Ʈ 3, 2, 1
    public Text TimeCount;
    public Text ClearText;
    public Grappling gp;
    public GameObject img;

    // ���� ����UI
    public GameObject[] Stars;

    private void Awake()
    {
        index = PlayerPrefs.GetInt("StageClear" + (SceneManager.GetActiveScene().buildIndex - 1));
        indexE = PlayerPrefs.GetInt("StageClearE" + (SceneManager.GetActiveScene().buildIndex - 12));
        start = PlayerPrefs.GetInt("Play");
        dopamine = PlayerPrefs.GetInt("Dopamine");
        serotonin = PlayerPrefs.GetInt("Serotonin");
        BestScore = PlayerPrefs.GetInt("BestScore" + (SceneManager.GetActiveScene().buildIndex - 1));
        BestScoreE = PlayerPrefs.GetInt("BestScoreE" + (SceneManager.GetActiveScene().buildIndex - 12));
    }

    // Start is called before the first frame update
    void Start()
    {
        hook = GameObject.FindWithTag("Hook");
        rig = GetComponent<Rigidbody>();
        grappling = hook.GetComponent<Grappling>();
        PlayerPrefs.SetInt("Play", start + 1);
        rig.velocity = new Vector3(0, 0);
        PlayerAnimator = GetComponent<Animator>();
        //BGM.Play();

        // BGM ����
        for (int i = 0; i < 18; i++)
        {
            if (PlayerPrefs.GetInt($"Fit{i}") == 1)
            {
                BGM[i].Play();
            }
            
        }
        StartCoroutine(BeforeStart());
    }

    // Update is called once per frame
    void Update()
    {

        // ���� �浹 �� ����Ʈ ȿ�� (�÷��̾��� ��ġ���� �޺� ȿ�� �߻�)
        particle.transform.position = transform.position; // + new Vector3(2,1,0);

        if (grappling.IsGrappling() && gp.isPlay == true)
        {
            PlayerAnimator.SetTrigger("Fly");

        }
        if (!Input.GetMouseButton(0))
        {
            spring = gameObject.GetComponent<SpringJoint>();
            if (spring != null)
            {
                Destroy(spring);
            }
        }
        else
        {
            if (transform.position.y > grappling.GetGrapplePoint().y)
            {
                transform.LookAt(new Vector3(transform.position.x - 1, ((grappling.GetGrapplePoint().x - transform.position.x) / (grappling.GetGrapplePoint().y - transform.position.y)) + transform.position.y));
            }
            else
            {
                transform.LookAt(new Vector3(transform.position.x + 1, ((transform.position.x - grappling.GetGrapplePoint().x) / (grappling.GetGrapplePoint().y - transform.position.y)) + transform.position.y));
            }
        }


    }
    

    private void FixedUpdate()
    {
        // �ӵ� ���� �� ���
        float xClamp = Mathf.Clamp(rig.velocity.x, -Speed, Speed);
        float yClamp = Mathf.Clamp(rig.velocity.y, -Speed, Speed);

        // ���� �� ����
        rig.velocity = new Vector3(xClamp, yClamp);

        if (grappling.IsGrappling())
        {
            rig.AddForce(transform.forward * 12.5f);
        }
    }

    // ���� ���� - Dead
    public Canvas myCan;
    private InterstitialAd interstitial;

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712"; // �׽�Ʈ �ڵ�
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void HandleOnAdClosed(object sender, System.EventArgs args)
    {
        gameObject.SetActive(false);
        DeadView.SetActive(true);
        hook.SetActive(false);
    }

    // ���� ���� - Clear �ϵ���
    private InterstitialAd interstitial2;

    private void RequestInterstitial2()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712"; // �׽�Ʈ �ڵ�
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial2 = new InterstitialAd(adUnitId);
        // Called when the ad is closed.
        this.interstitial2.OnAdClosed += HandleOnAdClosed2;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial2.LoadAd(request);
    }

    public void HandleOnAdClosed2(object sender, System.EventArgs args)
    {
        gameObject.SetActive(false);
        // ù Ŭ���� �� �ر� ���� �߻�
        /*if (index == 0 && SceneManager.GetActiveScene().buildIndex != 10)
        {
            FirstDestinationView.SetActive(true);
        }
        else
        {
            DestinaionView.SetActive(true);
        }*/
        DestinaionView.SetActive(true);
        hook.SetActive(false);
    }
    // ���� ���� - Clear �������
    private InterstitialAd interstitial3;
    private void RequestInterstitial3()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712"; // �׽�Ʈ �ڵ�
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial3 = new InterstitialAd(adUnitId);
        // Called when the ad is closed.
        this.interstitial3.OnAdClosed += HandleOnAdClosed3;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial3.LoadAd(request);
    }

    public void HandleOnAdClosed3(object sender, System.EventArgs args)
    {
        gameObject.SetActive(false);
        if (indexE == 0 && SceneManager.GetActiveScene().buildIndex != 10)
        {
            FirstDestinationView.SetActive(true);
        }
        else
        {
            DestinaionView.SetActive(true);
        }
        hook.SetActive(false);
    }



    private void OnTriggerEnter(Collider collision)
    {

        switch (collision.gameObject.tag)
        {   
            // ���Ĺ�
            case "item":
                itemCount++;
                ComboCount++;
                Combo();
                Item_();
                Num();
                collision.gameObject.SetActive(false);
                break;

            case "ItemB":
                itemCount2++;
                Item_2();
                collision.gameObject.SetActive(false);
                break;

            case "Ring":
            case "Wall":
                dead.Play();
                Dead();
                break;
            case "Finish":
                if (scoreSum>= targetScore)
                {
                    for (int i = 0; i < BGM.Length; i++)
                    {
                        BGM[i].Stop();
                    }

                    if (scoreSum >= 3000)
                    {
                        Stars[2].SetActive(true);
                    }
                    else if (scoreSum >= 2500)
                    {
                        Stars[1].SetActive(true);
                    }
                    else if (scoreSum >= 2000)
                    {
                        Stars[0].SetActive(true);
                    }

                    clear.Play();
                    if (scoreSum > BestScore)
                    {
                        PlayerPrefs.SetInt("BestScore"+ (SceneManager.GetActiveScene().buildIndex - 1), scoreSum);
                        if (SceneManager.GetActiveScene().buildIndex == 2)
                        {
                            GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_hard_stage_1, scoreSum, success => log = $"{success}");
                        }
                        else if (SceneManager.GetActiveScene().buildIndex==3)
                        {
                            GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_hard_stage_2, scoreSum, success => log = $"{success}");
                        }
                        else if (SceneManager.GetActiveScene().buildIndex==4)
                        {
                            GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_hard_stage_3, scoreSum, success => log = $"{success}");
                        }
                        else if (SceneManager.GetActiveScene().buildIndex==5)
                        {
                            GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_hard_stage_4, scoreSum, success => log = $"{success}");
                        }
                        else
                        {
                            if (index == 0)
                            {
                                GPGSBinder.Inst.UnlockAchievement(GPGSIds.achievement_game_master, success => log = $"{success}");
                            }
                            GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_hard_stage_5, scoreSum, success => log = $"{success}");
                        }
                        
                    }

                    Destination();
                    break;
                }
                else
                {
                    dead.Play();
                    Dead();
                    break;
                }
                //�������
            case "FinishEasy":
                if (scoreSum>= targetScore)
                {
                    for (int i = 0; i < BGM.Length; i++)
                    {
                        BGM[i].Stop();
                    }

                    if (scoreSum >= 2700)
                    {
                        Stars[2].SetActive(true);
                    }
                    else if (scoreSum >= 2200)
                    {
                        Stars[1].SetActive(true);
                    }
                    else if (scoreSum >= 1700)
                    {
                        Stars[0].SetActive(true);
                    }

                    clear.Play();
                    if (scoreSum > BestScoreE)
                    {
                        PlayerPrefs.SetInt("BestScoreE"+ (SceneManager.GetActiveScene().buildIndex - 12), scoreSum);
                        if (SceneManager.GetActiveScene().buildIndex == 13)
                        {
                            GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_easy_stage_1, scoreSum, success => log = $"{success}");
                        }
                        else if (SceneManager.GetActiveScene().buildIndex == 14)
                        {
                            GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_easy_stage_2, scoreSum, success => log = $"{success}");
                        }
                        else if (SceneManager.GetActiveScene().buildIndex == 15)
                        {
                            GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_easy_stage_3, scoreSum, success => log = $"{success}");
                        }
                        else if (SceneManager.GetActiveScene().buildIndex == 16)
                        {
                            GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_easy_stage_4, scoreSum, success => log = $"{success}");
                        }
                        else
                        {
                            GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_easy_stage_5, scoreSum, success => log = $"{success}");
                        }
                    }
                    
                    DestinationEasy();
                    break;
                }
                else
                {
                    dead.Play();
                    Dead();
                    break;
                }

            case "Monster":
                dead.Play();
                playpar();
                Dead();
                break;

            case "Move":
            case "MoveUp":
            case "MoveDown":
            case "MoveDownStage3":
            case "MoveUpStage3":
            case "MoveStage5":
                Mon.Play();   
                
                playpar();

                // ���Ĺ� ����
                itemCount = itemCount - (itemCount / 10);
                Item_();

                // ���ھ� ���� ����
                if (scoreSum == 0)
                {
                    scoreSum = 0;
                }
                else if (scoreSum >= 1 && scoreSum <= 50)
                {
                    scoreSum = 0;
                }
                else if (scoreSum > 50)
                {
                    scoreSum -= 50;
                }
                break;

            case "Trigger":
                StartCoroutine("Time_");
                break;

                // �޺�
            case "Combo":
                ComboCount = 0;
                break;

                // Ʃ�丮�� 2����
            case "Guide2":
                //
                break;
        }
    }

    public void Combo()
    {
        // ���Ĺ��� 5�� ������ �޺� ȿ���� �߻��ϵ���
        for (int i=1; i<50; i++)
        {
            if (ComboCount == i*5)
            {
                com.Play();
                scoreSum = scoreSum + 20 + i * 10;
                ComboView.GetComponent<Text>().text = i + " Combo!";
                StartCoroutine("Time1");
            }
        }
       
    }

    // �޺� �� ����Ʈ ȿ��
    public void playpar()
    {
        particle.Play();
    }

    IEnumerator Time_()
    {
        Warning.SetActive(true);

        // ����ȭ ���� �ڷ�ƾ �ڵ�
        yield return YieldInstructionCache.WaitForSeconds(1);
        //yield return new WaitForSecondsRealtime(1);
        Warning.SetActive(false);
    }

    IEnumerator Time1()
    {
        ComboView.SetActive(true);

        // ����ȭ ���� �ڷ�ƾ �ڵ�
        yield return YieldInstructionCache.WaitForSeconds(1);
        //yield return new WaitForSeconds(1);
        ComboView.SetActive(false);
    }

    void Dead()
    {
        

        // ���� ����
        Clear = false;

        // �ð� ����
        UnityEngine.Time.timeScale = 0;

        PlayerPrefs.SetInt("Dopamine", dopamine + itemCount);
        PlayerPrefs.SetInt("DDopamine", dopamine + itemCount);
        PlayerPrefs.SetInt("Serotonin", serotonin + itemCount2);
        PlayerPrefs.SetInt("SSerotonin", serotonin + itemCount2);

        /*// ���� ����
        RequestInterstitial();
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
            myCan.sortingOrder = -1;
        }*/

        if (PlayerPrefs.GetInt("Noads") == 1)
        {
            DeadView.SetActive(true);
            hook.SetActive(false);
        }
        else //if (PlayerPrefs.GetInt("Noads") == 0)
        {
            // ���� ����
            RequestInterstitial();
            if (this.interstitial.IsLoaded())
            {
                this.interstitial.Show();
                myCan.sortingOrder = -1;
            }
            DeadView.SetActive(true);
            hook.SetActive(false);
        }
    }

    public void Destination()
    {
        // ���� ����
        Clear = true;
        UnityEngine.Time.timeScale = 0;
        SuccessScore.text = TotalScore.text;

        PlayerPrefs.SetInt("Dopamine", dopamine + itemCount);
        PlayerPrefs.SetInt("DDopamine", dopamine + itemCount);
        PlayerPrefs.SetInt("Serotonin", serotonin + itemCount2);
        PlayerPrefs.SetInt("SSerotonin", serotonin + itemCount2);
        PlayerPrefs.SetInt("StageClear" + (SceneManager.GetActiveScene().buildIndex - 1), index + 1);

        /*RequestInterstitial2();
        if (this.interstitial2.IsLoaded())
        {
            this.interstitial2.Show();
            myCan.sortingOrder = -1;
        }*/

        if (PlayerPrefs.GetInt("Noads") == 1)
        {
            DestinaionView.SetActive(true);
            hook.SetActive(false);
        }
        else //if (PlayerPrefs.GetInt("Noads") == 0)
        {
            RequestInterstitial2();
            if (this.interstitial2.IsLoaded())
            {
                this.interstitial2.Show();
                myCan.sortingOrder = -1;

            }
            DestinaionView.SetActive(true);
            hook.SetActive(false);
        }
            /*DestinaionView.SetActive(true);
        PlayerPrefs.SetInt("StageClear" + (SceneManager.GetActiveScene().buildIndex - 1), index + 1);
        hook.SetActive(false);*/
    }
    // �������
    public void DestinationEasy()
    {
        // ���� ����
        Clear = true;
        UnityEngine.Time.timeScale = 0;
        SuccessScore.text = TotalScore.text;

        PlayerPrefs.SetInt("Dopamine", dopamine + itemCount);
        PlayerPrefs.SetInt("DDopamine", dopamine + itemCount);
        PlayerPrefs.SetInt("Serotonin", serotonin + itemCount2);
        PlayerPrefs.SetInt("SSerotonin", serotonin + itemCount2);

        PlayerPrefs.SetInt("StageClearE" + (SceneManager.GetActiveScene().buildIndex - 12), index + 1);
        /*RequestInterstitial3();
        if (this.interstitial3.IsLoaded())
        {
            this.interstitial3.Show();
            myCan.sortingOrder = -1;
        }*/

        if (PlayerPrefs.GetInt("Noads") == 1)
        {
            // ù Ŭ���� �� �ر� ���� �߻�
            if (indexE == 0 && SceneManager.GetActiveScene().buildIndex != 10)
            {
                FirstDestinationView.SetActive(true);
            }
            else
            {
                DestinaionView.SetActive(true);
            }
            //PlayerPrefs.SetInt("StageClearE" + (SceneManager.GetActiveScene().buildIndex - 12), index + 1);
            hook.SetActive(false);
        }
        else //if(PlayerPrefs.GetInt("Noads") == 0)
        {
            RequestInterstitial3();
            if (this.interstitial3.IsLoaded())
            {
                this.interstitial3.Show();
                myCan.sortingOrder = -1;

            }
            // ù Ŭ���� �� �ر� ���� �߻�
            if (indexE == 0 && SceneManager.GetActiveScene().buildIndex != 10)
            {
                FirstDestinationView.SetActive(true);
            }
            else
            {
                DestinaionView.SetActive(true);
            }
            hook.SetActive(false);
        }
            
    }


    public void Num()
    {
        scoreSum += 10;
        TotalScore.text = scoreSum.ToString();
    }

    

    // ���Ĺ�
    public void Item_()
    {
        // ȭ�鿡 �ؽ�Ʈ ���
        Dopamine.text = itemCount.ToString();
        Dopamine2.text = itemCount.ToString();
    }

    public void Item_2()
    {
        // ȭ�鿡 �ؽ�Ʈ ���
        Serotonin.text = itemCount2.ToString();
        Serotonin2.text = itemCount2.ToString();
    }

    // ���� ���� �� ī��Ʈ
    IEnumerator BeforeStart()
    {
        yield return new WaitForSeconds(1);
        TimeCount.text = "2";
        yield return new WaitForSeconds(1);
        TimeCount.text = "1";
        yield return new WaitForSeconds(1);
        TimeCount.gameObject.SetActive(false);
        ClearText.gameObject.SetActive(false);
        img.gameObject.SetActive(false);

        gp.isPlay = true;

    }

}
