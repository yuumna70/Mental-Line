using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingManager : MonoBehaviour
{
    public GameObject EasyView;
    public GameObject HardView;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Easy()
    {
        HardView.SetActive(false);
        EasyView.SetActive(true);
    }

    public void Hard()
    {
        EasyView.SetActive(false);
        HardView.SetActive(true);
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
