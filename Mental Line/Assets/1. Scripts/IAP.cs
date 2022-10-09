using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAP : MonoBehaviour
{
    
    //public IAPButton Btnp;
    //public IAPButton BtnFail;
    // Start is called before the first frame update
    void Start()
    {
        /*this.Btnp.onPurchaseComplete.AddListener(new UnityAction<Product>((Product) =>
       {
           Debug.LogFormat("[구매 성공] 광고가 제거되었습니다. : ", Product.transactionID);
           PlayerPrefs.SetInt("Noads", 1);
       }));

        this.Btnp.onPurchaseFailed.AddListener(new UnityAction<Product, PurchaseFailureReason>((Product, reason) =>
        {
            Debug.LogFormat("[구매 실패]", Product.transactionID, reason);
        }));*/
    }

    public void Reward()
    {
        //print("성공");
        PlayerPrefs.SetInt("Noads", 1);
    }

    public void Fail()
    {
        //print("실패");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
