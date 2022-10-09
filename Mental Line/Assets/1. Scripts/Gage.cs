using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gage : MonoBehaviour
{
    [SerializeField] Slider slider = null;

    [HideInInspector]
    public Player player;

    private float current;
    private float start;
    private float finish;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        finish = 290f;
        current = player.gameObject.transform.position.x;
        //start = -2.5f;
        Set_FillAmount(0);
    }

    // Update is called once per frame
    void Update()
    {
        Loading();   
    }

    void Loading()
    {
        current = player.gameObject.transform.position.x;
        if (current <finish)
        {
            Set_FillAmount(current / finish);

        }
        else
        {
            End_Loading();
        }
    }

    void End_Loading()
    {
        Set_FillAmount(1);
    }

    private void Set_FillAmount(float _value)
    {
        slider.value = _value;
    }
}
