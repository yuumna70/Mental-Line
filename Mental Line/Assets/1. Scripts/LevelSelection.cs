using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    string log;
    public Button[] lvlbuttons;
    public Text[] textBestScores;
    public GameObject View;
    public GameObject[] LockImages;
    public Sprite Lock;
    public Text StarCheck;
    public GameObject TreasureView;
    public GameObject TreasureButton;
    public Button TreasureGetButton;
    public Sprite OpenTreasure;
    public Sprite EmptyTreasure;
    int Check;
    int S;

    // 버튼 뷰
    [HideInInspector]
    public int levelAt;
    [HideInInspector]
    public int count;
    [HideInInspector]
    public int start;

    // 2차원 배열
    [System.Serializable]
    public class Array2D
    {
        public GameObject[] arr = new GameObject[3];
    }
    public Array2D[] Stars = new Array2D[5];

    
    public AudioSource click;

    // Start is called before the first frame update
    void Start()
    {
        count = PlayerPrefs.GetInt("StageClear1");
        start= PlayerPrefs.GetInt("Play");
        levelAt = PlayerPrefs.GetInt("levelAt", 2);
        S = PlayerPrefs.GetInt("Serotonin", 0);
        for (int i = 0; i<lvlbuttons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                textBestScores[i].text = "";
                LockImages[i].SetActive(true);
            }
            else
            {
                textBestScores[i].text = $"{i+1}스테이지 / 최고 점수 " + PlayerPrefs.GetInt("BestScore"+(i+1).ToString()).ToString();
                if (PlayerPrefs.GetInt("BestScore" + (i + 1).ToString()) >= 3000)
                {
                    Stars[i].arr[2].SetActive(true);
                    Check += 3;

                }
                else if (PlayerPrefs.GetInt("BestScore" + (i + 1).ToString()) >= 2500)
                {
                    Stars[i].arr[1].SetActive(true);
                    Check += 2;
                }
                else if (PlayerPrefs.GetInt("BestScore" + (i + 1).ToString()) >= 2000)
                {
                    Stars[i].arr[0].SetActive(true);
                    Check += 1;
                }
            }
        }
        StarCheck.text = Check.ToString();

        if (Check != 15)
        {
            TreasureGetButton.interactable = false;
        }
        else
        {
            if (PlayerPrefs.GetInt("TreasureHard", 0) == 0)
            {
                TreasureButton.GetComponent<Image>().sprite = OpenTreasure;
                GPGSBinder.Inst.UnlockAchievement(GPGSIds.achievement_master_of_master, success => log = $"{success}");
            }
            else if (PlayerPrefs.GetInt("TreasureHard", 0) == 1)
            {
                TreasureButton.GetComponent<Image>().sprite = EmptyTreasure;
            }
        }
        
    }


    public void Btn1()
    {
        click.Play();
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void Btn2()
    {
        click.Play();
        if (PlayerPrefs.GetInt("StageClear1") == 0)
        {
            View.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(3);
            Time.timeScale = 1;
        }
    }

    public void Btn3()
    {
        click.Play();
        if (PlayerPrefs.GetInt("StageClear2") == 0)
        {
            View.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(4);
            Time.timeScale = 1;
        }   
    }

    public void Btn4()
    {
        click.Play();
        if (PlayerPrefs.GetInt("StageClear3") == 0)
        {
            View.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(5);
            Time.timeScale = 1;
        }
    }

    public void Btn5()
    {
        click.Play();
        if (PlayerPrefs.GetInt("StageClear4") == 0)
        {
            View.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(6);
            Time.timeScale = 1;
        }
    }

    public void BackBtn()
    {
        click.Play();
        SceneManager.LoadScene(0);
    }

    public void CloseBtn()
    {
        click.Play();
        View.SetActive(false);
    }

    // 홈버튼
    public void HomeBtn()
    {
        click.Play();
        SceneManager.LoadScene(0);
    }
    // 이전 버튼
    public void BeforeBtn()
    {
        click.Play();
        SceneManager.LoadScene(11);
    }

    public void TreasureBtn()
    {
        if (PlayerPrefs.GetInt("TreasureHard", 0) == 0)
        {
            TreasureView.SetActive(true);
        }
    }

    public void TreasureCloseBtn()
    {
        TreasureView.SetActive(false);
    }

    public void TreasureGetBtn()
    {
        S += 500;
        PlayerPrefs.SetInt("Serotonin", S);
        PlayerPrefs.SetInt("TreasureHard", 1);
        TreasureButton.GetComponent<Image>().sprite = EmptyTreasure;
        TreasureView.SetActive(false);
    }
}
