using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public AudioSource click;

    //ó�� �÷������� ��
    public GameObject StoryIntroUI;
    public GameObject GuideUI;

    public void Skip()
    {
        click.Play();
        SceneManager.LoadScene(11);
    }

    public void CloseBtn()
    {
        click.Play();
        SceneManager.LoadScene(11);
    }
}
