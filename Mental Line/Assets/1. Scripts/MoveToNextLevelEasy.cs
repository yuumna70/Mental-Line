using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevelEasy : MonoBehaviour
{
    int nexSceneLoad;

    [HideInInspector]
    public Player player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        nexSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (player.scoreSum >= player.targetScore)
            {
                if (nexSceneLoad-11 > PlayerPrefs.GetInt("levelAtE"))
                {
                    // 스테이지
                    PlayerPrefs.SetInt("levelAtE", nexSceneLoad-11);
                    PlayerPrefs.Save();

                    // 스토리
                    PlayerPrefs.SetInt("StoryAtE", nexSceneLoad - 1);
                    // PlayerPrefs.Save();
                }
            }
        }
    }
}
