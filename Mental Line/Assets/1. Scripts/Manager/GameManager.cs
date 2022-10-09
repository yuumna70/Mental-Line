using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject FirstDestinationView;
    public GameObject DestinaionView;
    public GameObject[] Player;
    public GameObject PauseView;
    public Text TimeCount;
    public AudioSource click;

    public GameObject StarView;
    void Awake()
    {
        if (Player != null)
        {
            // 스킨 장착 여부
            for (int i = 0; i < Player.Length; i++)
            {
                if (PlayerPrefs.GetInt($"Fit{i}") == 1)
                {
                    Player[i].SetActive(true);
                }
                else
                {
                    Player[i].SetActive(false);
                }
            }
        }
    }

    public void ClickHome()
    {
        click.Play();
        // 홈씬 불러오기
        SceneManager.LoadScene(0);
    }

    public void ClickRestart()
    {
        click.Play();
        // 플레이씬 불러오기
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void ClickRestart2()
    {
        click.Play();
        // 플레이씬 불러오기
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }

    public void ClickRestart3()
    {
        click.Play();
        // 플레이씬 불러오기
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }

    public void ClickRestart4()
    {
        click.Play();
        // 플레이씬 불러오기
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
    }

    public void ClickRestart5()
    {
        click.Play();
        // 플레이씬 불러오기
        SceneManager.LoadScene(6);
        Time.timeScale = 1;
    }

    // 이지모드
    public void ClickRestartE()
    {
        click.Play();
        // 플레이씬 불러오기
        SceneManager.LoadScene(13);
        Time.timeScale = 1;
    }

    public void ClickRestartE2()
    {
        click.Play();
        // 플레이씬 불러오기
        SceneManager.LoadScene(14);
        Time.timeScale = 1;
    }

    public void ClickRestartE3()
    {
        click.Play();
        // 플레이씬 불러오기
        SceneManager.LoadScene(15);
        Time.timeScale = 1;
    }

    public void ClickRestartE4()
    {
        click.Play();
        // 플레이씬 불러오기
        SceneManager.LoadScene(16);
        Time.timeScale = 1;
    }

    public void ClickRestartE5()
    {
        click.Play();
        // 플레이씬 불러오기
        SceneManager.LoadScene(17);
        Time.timeScale = 1;
    }

    public void ClickStory()
    {
        click.Play();
        // 스토리 씬 불러오기
        SceneManager.LoadScene(7);
    }

    public void ClickNext()
    {
        click.Play();
        int nexSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nexSceneLoad);
        Time.timeScale = 1;
        //SceneManager.LoadScene(11);
    }

    public void FirstDestination()
    {
        click.Play();
        FirstDestinationView.SetActive(false);
        DestinaionView.SetActive(true);
    }

    // 5스테이지에서 스테이지 선택 버튼 - DestinationView
    public void Stage()
    {
        click.Play();
        SceneManager.LoadScene(11);
    }

    public void Stop()
    {
        click.Play();
        PauseView.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        click.Play();
        PauseView.SetActive(false);
        StartCoroutine("BeforeStart");
    }

    IEnumerator BeforeStart()
    {
        Time.timeScale = 0.01f;
        TimeCount.text = "3";
        TimeCount.gameObject.SetActive(true);
        yield return YieldInstructionCache.WaitForSeconds(0.01f);
        TimeCount.text = "2";
        yield return YieldInstructionCache.WaitForSeconds(0.01f);
        TimeCount.text = "1";
        yield return YieldInstructionCache.WaitForSeconds(0.01f);
        TimeCount.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void StarBtn()
    {
        click.Play();
        StarView.SetActive(true);
    }
    public void StarCloseBtn()
    {
        click.Play();
        StarView.SetActive(false);
    }
}
