using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectionEasy : MonoBehaviour
{
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
    [System.Serializable]
    public class Array2D
    {
        public GameObject[] arr = new GameObject[3];
    }
    public Array2D[] Stars = new Array2D[5];


    [HideInInspector]
    public int levelAt;
    [HideInInspector]
    public int count;
    [HideInInspector]
    public int start;

    public GameObject StarView;

    // Start is called before the first frame update
    void Start()
    {
        count = PlayerPrefs.GetInt("StageClearE1");
        start = PlayerPrefs.GetInt("Play");
        levelAt = PlayerPrefs.GetInt("levelAtE", 2);
        S = PlayerPrefs.GetInt("Serotonin", 0);
        for (int i = 0; i < lvlbuttons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                textBestScores[i].text = "";
                LockImages[i].SetActive(true);
            }
            else
            {
                textBestScores[i].text = $"{i + 1}스테이지 / 최고 점수 " + PlayerPrefs.GetInt("BestScoreE" + (i + 1).ToString()).ToString();
                if (PlayerPrefs.GetInt("BestScoreE" + (i + 1).ToString()) >= 2700)
                {
                    Stars[i].arr[2].SetActive(true);
                    Check += 3;
                }
                else if (PlayerPrefs.GetInt("BestScoreE" + (i + 1).ToString()) >= 2200)
                {
                    Stars[i].arr[1].SetActive(true);
                    Check += 2;
                }
                else if (PlayerPrefs.GetInt("BestScoreE" + (i + 1).ToString()) >= 1700)
                {
                    Stars[i].arr[0].SetActive(true);
                    Check += 1;
                }
            }
        }
        StarCheck.text = Check.ToString();

        if (Check != 15)
        {
            TreasureGetButton.interactable=false;
        }
        else
        {
            if (PlayerPrefs.GetInt("TreasureEasy", 0) == 0)
            {
                TreasureButton.GetComponent<Image>().sprite = OpenTreasure;
            }
            else if (PlayerPrefs.GetInt("TreasureEasy", 0) == 1)
            {
                TreasureButton.GetComponent<Image>().sprite = EmptyTreasure;
            }
        }

    }



    public void Btn1()
    {
        SceneManager.LoadScene(13);
        Time.timeScale = 1;
    }

    public void Btn2()
    {
        if (PlayerPrefs.GetInt("StageClearE1") == 0)
        {
            View.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(14);
            Time.timeScale = 1;
        }
    }

    public void Btn3()
    {
        if (PlayerPrefs.GetInt("StageClearE2") == 0)
        {
            View.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(15);
            Time.timeScale = 1;
        }
    }

    public void Btn4()
    {
        if (PlayerPrefs.GetInt("StageClearE3") == 0)
        {
            View.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(16);
            Time.timeScale = 1;
        }
    }

    public void Btn5()
    {
        if (PlayerPrefs.GetInt("StageClearE4") == 0)
        {
            View.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(17);
            Time.timeScale = 1;
        }
    }

    public void BackBtn()
    {
        SceneManager.LoadScene(0);
    }

    public void CloseBtn()
    {
        View.SetActive(false);
    }

    // 홈버튼
    public void HomeBtn()
    {
        SceneManager.LoadScene(0);
    }
    // 이전 버튼
    public void BeforeBtn()
    {
        SceneManager.LoadScene(11);
    }

    public void StarBtn()
    {
        StarView.SetActive(true);
    }

    public void StarCloseBtn()
    {
        StarView.SetActive(false);
    }

    public void TreasureBtn()
    {
        if (PlayerPrefs.GetInt("TreasureEasy") == 0)
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
        PlayerPrefs.SetInt("TreasureEasy", 1);
        TreasureButton.GetComponent<Image>().sprite = EmptyTreasure;
        TreasureView.SetActive(false);
    }
}