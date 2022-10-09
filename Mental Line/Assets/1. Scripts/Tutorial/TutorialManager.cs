using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class TutorialManager : MonoBehaviour
{
    // 1구역 가이드 뷰
    public GameObject Player;
    public GameObject View1Btn1;
    public GameObject View2Btn1;
    public GameObject View3Btn1;
    public GameObject View4Btn1;
    public GameObject View5Btn1;
    public VideoPlayer SwingVideo;
    public VideoPlayer SwingDeadVideo;

    // 2구역 가이드 뷰
    public GameObject View1Btn2;
    public GameObject View2Btn2;
    public GameObject View3Btn2;

    // 3구역 가이드 뷰
    public GameObject View1Btn3;
    public VideoPlayer MonsterDeadVideo;

    // 3-2구역 가이드 뷰
    public GameObject View1Btn3_2;

    // 종료 팝업 뷰
    public GameObject Exit;
    public GameObject CloseView;


    // 가이드 뷰를 종료하고 게임 시작
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

    // 스테이지 씬으로 
    public void Before()
    {
        click.Play();
        SceneManager.LoadScene(11);
    }

    // 완료 - 다음 스테이지 버튼
    public void Stage()
    {
        click.Play();
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    // Dead뷰 - 재시작
    public void Restart()
    {
        click.Play();
        SceneManager.LoadScene(10);
    }

    // 나가기 버튼
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

    // 나가기 팝업
    public void CloseBtn()
    {
        click.Play();
        Time.timeScale = 0;
        CloseView.SetActive(true);
    }

    // 1구역 가이드 뷰 버튼
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

    // 2구역 가이드 뷰
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

    // 3구역 가이드 뷰
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

    // 3-2구역 가이드 뷰
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
