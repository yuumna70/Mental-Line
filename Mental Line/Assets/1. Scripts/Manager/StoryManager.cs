using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    // 스토리 뷰
    public GameObject IntroView;
    public GameObject[] MainStory;
    public GameObject[] EasyStory;
    /*public GameObject[] AddStory;
    public GameObject[] ChaStory;
    public GameObject[] HiddenStory;
    public GameObject[] HiddenBuy;
    public GameObject[] Buy;*/

    // 기본 스토리 버튼
    public GameObject IntroBtn;
    public Button[] StyBtns;
    public Button[] EasyStyBtns;
    /*public Button[] AddBtns;
    public Button[] ChaBtns;
    public Button[] HiddenBtns;*/

    // 텍스트
    public Text[] MainT;
    public Text[] EasyT;


    // 세로토닌 부족
    public GameObject SerotoninDe;

    public AudioSource click;

    int d;
    int s;
    private void Update()
    {
    
    }

    // Start is called before the first frame update
    void Start()
    {
        d=PlayerPrefs.GetInt("DDopamine");
        s= PlayerPrefs.GetInt("SSerotonin");
        //int StoryAt = PlayerPrefs.GetInt("StoryAt", 1);
        int StoryAtE = PlayerPrefs.GetInt("StoryAtE", 1);

        /*for (int i = 0; i < StyBtns.Length; i++)
        {
            if (i + 2 > StoryAt)
            {
                StyBtns[i].interactable = false;
                MainT[i].text = $"하드모드 {i + 1}스테이지 클리어시 오픈";
            }
                
        }*/
        for (int i = 0; i < 2; i++)
        {
            if (PlayerPrefs.GetInt("SSerotonin") < 50 * (i + 1))
            {
                StyBtns[i].interactable = false;
                MainT[i].text = $"멘탈 수정 누적 {s}/{50 * (i + 1)}개 획득시 오픈";
                MainT[i].fontSize = 45;
            }
        }
        for (int i = 2; i < 5; i++)
        {
            if (PlayerPrefs.GetInt("DDopamine") < 2500 * (i - 1))
            {
                StyBtns[i].interactable = false;
                MainT[i].text = $"맨탈 조각 누적 {d}/{2500 * (i - 1)}개 획득시 오픈";
                MainT[i].fontSize = 45;
            }
        }
        for (int i = 0; i < EasyStyBtns.Length; i++)
        {
            if (i + 13 > StoryAtE)
            {
                EasyStyBtns[i].interactable = false;
                EasyT[i].text = $"이지모드 {i + 1}스테이지 클리어시 오픈";
            }

        }




        /*for (int i = 0; i < AddBtns.Length; i++)
        {
            if (PlayerPrefs.GetInt("Add" + (i + 1)) == 0)
                AddBtns[i].interactable = false;
        }
        for (int i = 0; i < ChaBtns.Length; i++)
        {
            if (PlayerPrefs.GetInt("Item" + (i + 1)) == 0)
                ChaBtns[i].interactable = false;
        }
        for (int i = 0; i < HiddenBtns.Length; i++)
        {
            if (PlayerPrefs.GetInt("Hidden" + (i + 1)) == 0)
            {
                HiddenBtns[i].interactable = false;
            }
            else
            {
                Buy[i].SetActive(false);
            }
                
        }*/
    }

    // 스토리 씬 닫기
    public void ClickClose()
    {
        click.Play();
        SceneManager.LoadScene(0);
    }

    // 인트로 스토리 창 열고 닫기
    public void IntroClickStory1()
    {
        click.Play();
        IntroView.SetActive(true);
    }

    public void IntroClickStory1Close()
    {
        click.Play();
        IntroView.SetActive(false);
    }

    // 메인 스토리 창 열고 닫기
    public void MainClickStory1()
    {
        click.Play();
        MainStory[0].SetActive(true);
    }

    public void MainClickStory1Close()
    {
        click.Play();
        MainStory[0].SetActive(false);
    }

    public void MainClickStory2()
    {
        click.Play();
        MainStory[1].SetActive(true);
    }

    public void MainClickStory2Close()
    {
        click.Play();
        MainStory[1].SetActive(false);
    }

    public void MainClickStory3()
    {
        click.Play();
        MainStory[2].SetActive(true);
    }

    public void MainClickStory3Close()
    {
        click.Play();
        MainStory[2].SetActive(false);
    }

    public void MainClickStory4()
    {
        click.Play();
        MainStory[3].SetActive(true);
    }

    public void MainClickStory4Close()
    {
        click.Play();
        MainStory[3].SetActive(false);
    }

    public void MainClickStory5()
    {
        click.Play();
        MainStory[4].SetActive(true);
    }

    public void MainClickStory5Close()
    {
        click.Play();
        MainStory[4].SetActive(false);
    }

    // 이지모드 스토리
    public void EasyClickStory1()
    {
        click.Play();
        EasyStory[0].SetActive(true);
    }

    public void EasyClickStory1Close()
    {
        click.Play();
        EasyStory[0].SetActive(false);
    }
    public void EasyClickStory2()
    {
        click.Play();
        EasyStory[1].SetActive(true);
    }

    public void EasyClickStory2Close()
    {
        click.Play();
        EasyStory[1].SetActive(false);
    }
    public void EasyClickStory3()
    {
        click.Play();
        EasyStory[2].SetActive(true);
    }

    public void EasyClickStory3Close()
    {
        click.Play();
        EasyStory[2].SetActive(false);
    }
    public void EasyClickStory4()
    {
        click.Play();
        EasyStory[3].SetActive(true);
    }

    public void EasyClickStory4Close()
    {
        click.Play();
        EasyStory[3].SetActive(false);
    }
    public void EasyClickStory5()
    {
        click.Play();
        EasyStory[4].SetActive(true);
    }

    public void EasyClickStory5Close()
    {
        click.Play();
        EasyStory[4].SetActive(false);
    }

    /* // 부가 스토리 창 열고 닫기
     public void AddClickStory1()
     {
         AddStory[0].SetActive(true);
     }

     public void AddClickStory1Close()
     {
         AddStory[0].SetActive(false);
     }

     public void AddClickStory2()
     {
         AddStory[1].SetActive(true);
     }

     public void AddClickStory2Close()
     {
         AddStory[1].SetActive(false);
     }

     public void AddClickStory3()
     {
         AddStory[2].SetActive(true);
     }

     public void AddClickStory3Close()
     {
         AddStory[2].SetActive(false);
     }

     public void AddClickStory4()
     {
         AddStory[3].SetActive(true);
     }

     public void AddClickStory4Close()
     {
         AddStory[3].SetActive(false);
     }

     public void AddClickStory5()
     {
         AddStory[4].SetActive(true);
     }

     public void AddClickStory5Close()
     {
         AddStory[4].SetActive(false);
     }

     // 캐릭터 스토리 창 열고 닫기

     public void ChaClickStory1()
     {
         ChaStory[0].SetActive(true);
     }

     public void ChaClickStory1Close()
     {
         ChaStory[0].SetActive(false);
     }

     // 히든 스토리 창 열고 닫기

     public void ChaClickStory2()
     {
         ChaStory[1].SetActive(true);
     }

     public void ChaClickStory2Close()
     {
         ChaStory[1].SetActive(false);
     }

     public void ChaClickStory3()
     {
         ChaStory[2].SetActive(true);
     }

     public void ChaClickStory3Close()
     {
         ChaStory[2].SetActive(false);
     }

     public void ChaClickStory4()
     {
         ChaStory[3].SetActive(true);
     }

     public void ChaClickStory4Close()
     {
         ChaStory[3].SetActive(false);
     }

     public void ChaClickStory5()
     {
         ChaStory[4].SetActive(true);
     }

     public void ChaClickStory5Close()
     {
         ChaStory[4].SetActive(false);
     }

     public void HiddenClickStory1()
     {
         HiddenStory[0].SetActive(true);
     }

     public void HiddenClickStory1Close()
     {
         HiddenStory[0].SetActive(false);
     }

     public void HiddenClickStory2()
     {
         HiddenStory[1].SetActive(true);
     }

     public void HiddenClickStory2Close()
     {
         HiddenStory[1].SetActive(false);
     }

     public void HiddenClickStory3()
     {
         HiddenStory[2].SetActive(true);
     }

     public void HiddenClickStory3Close()
     {
         HiddenStory[2].SetActive(false);
     }

     public void HiddenClickStory4()
     {
         HiddenStory[3].SetActive(true);
     }

     public void HiddenClickStory4Close()
     {
         HiddenStory[3].SetActive(false);
     }

     public void HiddenClickStory5()
     {
         HiddenStory[4].SetActive(true);
     }

     public void HiddenClickStory5Close()
     {
         HiddenStory[4].SetActive(false);
     }

     // 히든 스토리 구매 창 열기
     public void HiddenBuy1()
     {
         HiddenBuy[0].SetActive(true);
     }

     public void HiddenBuy2()
     {
         HiddenBuy[1].SetActive(true);
     }
     public void HiddenBuy3()
     {
         HiddenBuy[2].SetActive(true);
     }
     public void HiddenBuy4()
     {
         HiddenBuy[3].SetActive(true);
     }
     public void HiddenBuy5()
     {
         HiddenBuy[4].SetActive(true);
     }

     // 히든 스토리 구매하기
     public void HiddenBuyBtn1()
     {
         if (S >= 10)
         {
             PlayerPrefs.SetInt("Serotonin", S-10);
             PlayerPrefs.SetInt("Hidden1", 1);
             Buy[0].SetActive(false);
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         }
         else if (S < 10)
         {
             SerotoninDe.SetActive(true);
         }
     }

     public void HiddenBuyBtn2()
     {
         if (S >= 10)
         {
             PlayerPrefs.SetInt("Serotonin", S - 10);
             PlayerPrefs.SetInt("Hidden2", 1);
             Buy[1].SetActive(false);
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         }
         else if (S < 10)
         {
             SerotoninDe.SetActive(true);
         }
     }

     public void HiddenBuyBtn3()
     {
         if (S >= 10)
         {
             PlayerPrefs.SetInt("Serotonin", S - 10);
             PlayerPrefs.SetInt("Hidden3", 1);
             Buy[2].SetActive(false);
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         }
         else if (S < 10)
         {
             SerotoninDe.SetActive(true);
         }
     }
     public void HiddenBuyBtn4()
     {
         if (S >= 10)
         {
             PlayerPrefs.SetInt("Serotonin", S - 10);
             PlayerPrefs.SetInt("Hidden4", 1);
             Buy[3].SetActive(false);
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         }
         else if (S < 10)
         {
             SerotoninDe.SetActive(true);
         }
     }
     public void HiddenBuyBtn5()
     {
         if (S >= 10)
         {
             PlayerPrefs.SetInt("Serotonin", S - 10);
             PlayerPrefs.SetInt("Hidden5", 1);
             Buy[4].SetActive(false);
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         }
         else if (S < 10)
         {
             SerotoninDe.SetActive(true);
         }
     }
     // 히든 스토리 구매 취소하기
     public void HiddenBuyClose1()
     {
         HiddenBuy[0].SetActive(false);
     }

     public void HiddenBuyClose2()
     {
         HiddenBuy[1].SetActive(false);
     }
     public void HiddenBuyClose3()
     {
         HiddenBuy[2].SetActive(false);
     }
     public void HiddenBuyClose4()
     {
         HiddenBuy[3].SetActive(false);
     }

     public void HiddenBuyClose5()
     {
         HiddenBuy[4].SetActive(false);
     }
 }*/
}