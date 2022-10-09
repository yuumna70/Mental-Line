using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage0Manager : MonoBehaviour
{
    public AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 0. Stage0 스테이지 선택 버튼
    public void TutorialBtn()
    {
        click.Play();
        SceneManager.LoadScene(10);
    }
    public void HomeBtn()
    {
        click.Play();
        SceneManager.LoadScene(0);
    }
    public void EasyBtn()
    {
        click.Play();
        SceneManager.LoadScene(12);
    }
    public void HardBtn()
    {
        click.Play();
        SceneManager.LoadScene(1);
    }



}
