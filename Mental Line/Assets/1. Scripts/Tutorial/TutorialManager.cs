using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class TutorialManager : MonoBehaviour
{
    // 1���� ���̵� ��
    public GameObject Player;
    public GameObject View1Btn1;
    public GameObject View2Btn1;
    public GameObject View3Btn1;
    public GameObject View4Btn1;
    public GameObject View5Btn1;
    public VideoPlayer SwingVideo;
    public VideoPlayer SwingDeadVideo;

    // 2���� ���̵� ��
    public GameObject View1Btn2;
    public GameObject View2Btn2;
    public GameObject View3Btn2;

    // 3���� ���̵� ��
    public GameObject View1Btn3;
    public VideoPlayer MonsterDeadVideo;

    // 3-2���� ���̵� ��
    public GameObject View1Btn3_2;

    // ���� �˾� ��
    public GameObject Exit;
    public GameObject CloseView;


    // ���̵� �並 �����ϰ� ���� ����
    public bool isPlay;

    public AudioSource click;

    public Grappling gp;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �������� ������ 
    public void Before()
    {
        click.Play();
        SceneManager.LoadScene(11);
    }

    // �Ϸ� - ���� �������� ��ư
    public void Stage()
    {
        click.Play();
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    // Dead�� - �����
    public void Restart()
    {
        click.Play();
        SceneManager.LoadScene(10);
    }

    // ������ ��ư
    public void CloseYesBtn()
    {
        click.Play();
        SceneManager.LoadScene(0);
    }

    public void CloseNoBtn()
    {
        click.Play();
        CloseView.SetActive(false);
        if(isPlay == true)
        {
            Time.timeScale = 1;
        }
    }

    // ������ �˾�
    public void CloseBtn()
    {
        click.Play();
        Time.timeScale = 0;
        CloseView.SetActive(true);
    }

    // 1���� ���̵� �� ��ư
    public void View1Btn()
    {
        click.Play();
        Time.timeScale = 0;
        View1Btn1.SetActive(false);
        View2Btn1.SetActive(true);
        isPlay = false;
    }

    public void View2Btn()
    {
        click.Play();
        Time.timeScale = 0;
        View2Btn1.SetActive(false);
        View3Btn1.SetActive(true);
        isPlay = false;
    }

    public void View3Btn()
    {
        click.Play();
        Time.timeScale = 0;
        View3Btn1.SetActive(false);
        View4Btn1.SetActive(true);
        SwingVideo.Play();
        isPlay = false;
    }
    public void View4Btn()
    {
        click.Play();
        Time.timeScale = 0;
        SwingVideo.Stop();
        View4Btn1.SetActive(false);
        View5Btn1.SetActive(true);
        SwingDeadVideo.Play();
        isPlay = false;
    }
    public void View5Btn()
    {
        Player.SetActive(true);
        Player.transform.rotation = new Quaternion(0, 90, 0, 0);
        click.Play();
        Time.timeScale = 0;
        Exit.SetActive(false);
        SwingDeadVideo.Stop();
        View5Btn1.SetActive(false);
        Time.timeScale = 1;
        isPlay = true;
    }

    // 2���� ���̵� ��
    public void View1Btn222()
    {
        click.Play();
        Time.timeScale = 0;
        View1Btn2.SetActive(false);
        View2Btn2.SetActive(true);
        isPlay = false;
    }

    public void View2Btn222()
    {
        click.Play();
        Time.timeScale = 0;
        View2Btn2.SetActive(false);
        View3Btn2.SetActive(true);
        isPlay = false;
    }
    public void View3Btn222()
    {
        Player.SetActive(true);
        Player.transform.rotation = new Quaternion(0, 90, 0, 0);
        click.Play();
        Time.timeScale = 0;
        Exit.SetActive(false);
        View3Btn2.SetActive(false);
        gp.isPlay = true;
        Time.timeScale = 1;
        isPlay = true;
    }

    // 3���� ���̵� ��
    public void View1Btn333()
    {
        Player.SetActive(true);
        Player.transform.rotation = new Quaternion(0, 90, 0, 0);
        click.Play();
        Time.timeScale = 0;
        Exit.SetActive(false);
        MonsterDeadVideo.Stop();
        View1Btn3.SetActive(false);
        Time.timeScale = 1;
        isPlay = true;
    }

    // 3-2���� ���̵� ��
    public void View1Btn333_2()
    {
        click.Play();
        Time.timeScale = 0;
        Exit.SetActive(false);
        View1Btn3_2.SetActive(false);
        Time.timeScale = 1;
        isPlay = true;
    }
}
