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

    // ���Ϳ��� �״� ����
    public VideoPlayer MonsterDeadVideo;

    private float Speed = 6.5f;
    private SpringJoint spring;
    private Grappling grappling;
    private Rigidbody rig;

    private bool save1=false;
    private bool save2=false;
    private bool save3=false;

    // �ִϸ�����
    private Animator PlayerAnimator;

    // ���������� ���� �ؽ�Ʈ
    public Text SuccessScore;

    // ����
    public int targetScore;

    // �׾��� ��
    public GameObject DeadView;
    public GameObject hook;

    // ������
    public GameObject DestinaionView;
    public Text TotalScore;
    [HideInInspector]
    public bool Clear;

    // ���Ĺ�, �������
    public Text Dopamine;
    public Text Dopamine2;
    public Text Serotonin;
    public Text Serotonin2;
    public int scoreSum = 0;
    private int itemCount;
    private int itemCount2;

    // ���� ���
    public GameObject Warning;

    // �޺�
    private int ComboCount;
    public GameObject ComboView;

    // ����Ʈ
    public ParticleSystem particle;

    // ������ ��ư
    public GameObject Exit;

    // 1���� ���̵� ��
    public GameObject View1Btn1;

    // ���̵� 2����
    public GameObject View1Btn2;

    // ���̵� 3����
    public GameObject View1Btn3;

    // ���̵� 3_2����
    public GameObject View1Btn3_2;

    // ���� ��ġ
    public GameObject Mon;

    // ������ Ȱ��ȭ
    public GameObject[] Items;

    public TutorialManager tm;

    // ����
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
        // ���� �浹 �� ����Ʈ ȿ�� (�÷��̾��� ��ġ���� �޺� ȿ�� �߻�)
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

    
    private void OnTriggerEnter(Collider collision)
    {

        switch (collision.gameObject.tag)
        {
            // ���̵� 2����
            case "Respawn":
                collision.gameObject.SetActive(false);
                gp.isPlay = false;
                save1 = true;
                Respawn();
                break;

            // ���̵� 3����
            case "Respawn1":
                collision.gameObject.SetActive(false);
                save2 = true;
                Respawn();
                break;

            // ���̵� 3����
            case "Respawn2":
                collision.gameObject.SetActive(false);
                save3 = true;
                Respawn();
                break;

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
                // ���Ĺ� ����
                itemCount = itemCount-(itemCount/10);
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
                StartCoroutine("Time1");
                break;

            // �޺�
            case "Combo":
                ComboCount = 0;
                break;
        }
    }

    public void Combo()
    {
        // ���Ĺ��� 5�� ������ �޺� ȿ���� �߻��ϵ���
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

    // �޺� �� ����Ʈ ȿ��
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
        // ���� ����
        Clear = false;

        // �ð� ����
        UnityEngine.Time.timeScale = 0;
        DeadView.SetActive(true);
        hook.SetActive(false);
    }

    public void Destination()
    {
        // ���� ����
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
            // 1�����϶�
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
            // 2�����϶�
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
            // 3�����϶�
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
            // 3���� �������϶�
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
