using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using GooglePlayGames.BasicApi.Events;

public class GooglePlayLogin : MonoBehaviour
{

    string log;

    private void Start()
    {
        Login();
    }


    public void Login()
    {
        GPGSBinder.Inst.Login((success, localUser) =>
        log = $"{success}, {localUser.userName}, {localUser.id}, {localUser.state}, {localUser.underage}");
    }
}
