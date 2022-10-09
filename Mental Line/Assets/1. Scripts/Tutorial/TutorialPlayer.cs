using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class TutorialPlayer : MonoBehaviour
{
    public GameObject startBlock;
    public GameObject monster;

    // 몬스터에게 죽는 비디오
    public VideoPlayer MonsterDeadVideo;

    private float Speed = 6.5f;
    private SpringJoint spring;
    private Grappling grappling;
    private Rigidbody rig;

    private bool save1=false;
    private bool save2=false;
    private bool save3=false;

    // 애니메이터
    private Animator PlayerAnimator;

    // 성공했을때 점수 텍스트
    public Text SuccessScore;

    // 점수
    public int targetScore;

    // 죽었을 때
    public GameObject DeadView;
    public GameObject hook;

    // 도착지
    public GameObject DestinaionView;
    public Text TotalScore;
    [HideInInspector]
    public bool Clear;

    // 도파민, 세로토민
    public Text Dopamine;
    public Text Dopamine2;
    public Text Serotonin;
    public Text Serotonin2;
    public int scoreSum = 0;
    private int itemCount;
    private int itemCount2;

    // 몬스터 경고
    public GameObject Warning;

    // 콤보
    private int ComboCount;
    public GameObject ComboView;

    // 이펙트
    public ParticleSystem particle;

    // 나가기 버튼
    public GameObject Exit;

    // 1구역 가이드 뷰
    public GameObject View1Btn1;

    // 가이드 2구역
    public GameObject View1Btn2;

    // 가이드 3구역
    public GameObject View1Btn3;

    // 가이드 3_2구역
    public GameObject View1Btn3_2;

    // 몬스터 위치
    public GameObject Mon;

    // 아이템 활성화
    public GameObject[] Items;

    public TutorialManager tm;

    // 사운드
    public AudioSource dead;
    public AudioSource clear;
    public AudioSource BGM;
    public AudioSource MonS;

    public Grappling gp;

    public GameObject[] Map;
    public GameObject[] StartBlocks;

    // Start is called before the first frame update
    void Start()
    {
        BGM.Play();

        rig = GetComponent<Rigidbody>();
        grappling = hook.GetComponent<Grappling>();
        rig.velocity = new Vector3(0, 0);
        PlayerAnimator = GetComponent<Animator>();
        gp.isPlay = true;
    }

    // Update is called once per frame
    void Update()
    {
        // 몬스터 충돌 시 이펙트 효과 (플레이어의 위치에서 콤보 효과 발생)
        particle.transform.position = transform.position; // + new Vector3(2,1,0);
        if (grappling.IsGrappling())
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
        // 속도 제한 값 계산
        float xClamp = Mathf.Clamp(rig.velocity.x, -Speed, Speed);
        float yClamp = Mathf.Clamp(rig.velocity.y, -Speed, Speed);

        // 제한 값 적용
        rig.velocity = new Vector3(xClamp, yClamp);

        if (grappling.IsGrappling())
        {
            rig.AddForce(transform.forward * 12.5f);
        }
    }

    
    private void OnTriggerEnter(Collider collision)
    {

        switch (collision.gameObject.tag)
        {
            // 가이드 2구역
            case "Respawn":
                collision.gameObject.SetActive(false);
                gp.isPlay = false;
                save1 = true;
                Respawn();
                break;

            // 가이드 3구역
            case "Respawn1":
                collision.gameObject.SetActive(false);
                save2 = true;
                Respawn();
                break;

            // 가이드 3구역
            case "Respawn2":
                collision.gameObject.SetActive(false);
                save3 = true;
                Respawn();
                break;

            // 도파민
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
                Respawn();
                break;
            case "Finish":
                if (scoreSum >= targetScore)
                {
                    BGM.Stop();
                    clear.Play();
                    Destination();
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
                Respawn();
                break;

            case "Move":
                MonS.Play();

                playpar();
                // 도파민 차감
                itemCount = itemCount-(itemCount/10);
                Item_();

                // 스코어 점수 차감
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
                StartCoroutine("Time1");
                break;

            // 콤보
            case "Combo":
                ComboCount = 0;
                break;
        }
    }

    public void Combo()
    {
        // 도파민을 5번 먹으면 콤보 효과가 발생하도록
        for (int i = 1; i < 50; i++)
        {
            if (ComboCount == i * 5)
            {
                scoreSum = scoreSum + 20 + i * 10;
                ComboView.GetComponent<Text>().text = i + " Combo!";
                StartCoroutine("Time11");
            }
        }
    }

    // 콤보 시 이펙트 효과
    public void playpar()
    {
        particle.Play();
    }

    IEnumerator Time1()
    {
        Warning.SetActive(true);
        yield return YieldInstructionCache.WaitForSeconds(1);
        Warning.SetActive(false);
    }

    IEnumerator Time11()
    {
        ComboView.SetActive(true);
        yield return YieldInstructionCache.WaitForSeconds(1);
        ComboView.SetActive(false);
    }

    void Dead()
    {
        // 게임 실패
        Clear = false;

        // 시간 멈춤
        UnityEngine.Time.timeScale = 0;
        DeadView.SetActive(true);
        hook.SetActive(false);
    }

    public void Destination()
    {
        // 게임 성공
        Clear = true;
        UnityEngine.Time.timeScale = 0;
        SuccessScore.text = TotalScore.text;
        DestinaionView.SetActive(true);

        hook.SetActive(false);
    }

    public void Num()
    {
        // string b = " / " + targetScore.ToString();
        scoreSum += 10;
        TotalScore.text = scoreSum.ToString();
    }

    // 도파민
    public void Item_()
    {
        // 화면에 텍스트 출력
        Dopamine.text = itemCount.ToString();
        Dopamine2.text = itemCount.ToString();
    }

    public void Item_2()
    {
        // 화면에 텍스트 출력
        Serotonin.text = itemCount2.ToString();
        Serotonin2.text = itemCount2.ToString();
    }

    public void set()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].SetActive(true);
        }
    }

    void Respawn()
    {
        rig.velocity = new Vector3(0, 0, 0);
        gameObject.SetActive(false);
        if(!save1 && !save2 && !save3)
        {
            // 1구역일때
            Time.timeScale = 0;
            Exit.SetActive(true);
            View1Btn1.SetActive(true);
            tm.isPlay = false;
            transform.position = new Vector3(3.2f, -8, 0);
            startBlock.SetActive(true);
            startBlock.transform.position = new Vector3(3.2f, -9, 0);
            monster.transform.position = new Vector3(150, -10, 0);
            set();
            ComboView.SetActive(false);

        }
        else if (save1 && !save2 && !save3)
        {
            // 2구역일때
            Map[0].SetActive(false);
            Map[2].SetActive(true);
            StartBlocks[0].SetActive(true);
            Time.timeScale = 0;
            Exit.SetActive(true);
            View1Btn2.SetActive(true);
            tm.isPlay = false;
            transform.position = new Vector3(59, -8, 0);
            startBlock.SetActive(true);
            startBlock.transform.position = new Vector3(59, -9, 0);
            monster.transform.position = new Vector3(150, -10, 0);
            set();
            ComboView.SetActive(false);
        }
        else if (save2 && !save3)
        {
            // 3구역일때
            Map[1].SetActive(false);
            StartBlocks[0].SetActive(false);
            StartBlocks[1].SetActive(true);
            Time.timeScale = 0;
            Exit.SetActive(true);
            MonsterDeadVideo.Play();
            View1Btn3.SetActive(true);
            tm.isPlay = false;
            transform.position = new Vector3(119, -9, 0);
            startBlock.SetActive(true);
            startBlock.transform.position = new Vector3(119, -10, 0);
            monster.transform.position = new Vector3(150, -10, 0);
            monster.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            set();
            ComboView.SetActive(false);
        }
        else
        {
            // 3구역 마지막일때
            Time.timeScale = 0;
            Exit.SetActive(true);
            View1Btn3_2.SetActive(true);
            tm.isPlay = false;
            transform.position = new Vector3(175, -9, 0);
            startBlock.SetActive(true);
            startBlock.transform.position = new Vector3(175, -10, 0);
            monster.transform.position = new Vector3(150, -10, 0);
            set();
            ComboView.SetActive(false);
        }
    }
    
}
