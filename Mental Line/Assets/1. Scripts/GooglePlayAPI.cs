using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using GooglePlayGames.BasicApi.Events;

public class GooglePlayAPI : MonoBehaviour
{
    string log;

    public void RankingE1()
    {
        GPGSBinder.Inst.ShowTargetLeaderboardUI(GPGSIds.leaderboard_easy_stage_1);
    }

    public void RankingE2()
    {
        GPGSBinder.Inst.ShowTargetLeaderboardUI(GPGSIds.leaderboard_easy_stage_2);
    }

    public void RankingE3()
    {
        GPGSBinder.Inst.ShowTargetLeaderboardUI(GPGSIds.leaderboard_easy_stage_3);
    }
    public void RankingE4()
    {
        GPGSBinder.Inst.ShowTargetLeaderboardUI(GPGSIds.leaderboard_easy_stage_4);
    }
    public void RankingE5()
    {
        GPGSBinder.Inst.ShowTargetLeaderboardUI(GPGSIds.leaderboard_easy_stage_5);
    }

    public void RankingH1()
    {
        GPGSBinder.Inst.ShowTargetLeaderboardUI(GPGSIds.leaderboard_hard_stage_1);
    }

    public void RankingH2()
    {
        GPGSBinder.Inst.ShowTargetLeaderboardUI(GPGSIds.leaderboard_hard_stage_2);
    }

    public void RankingH3()
    {
        GPGSBinder.Inst.ShowTargetLeaderboardUI(GPGSIds.leaderboard_hard_stage_3);
    }

    public void RankingH4()
    {
        GPGSBinder.Inst.ShowTargetLeaderboardUI(GPGSIds.leaderboard_hard_stage_4);
    }

    public void RankingH5()
    {
        GPGSBinder.Inst.ShowTargetLeaderboardUI(GPGSIds.leaderboard_hard_stage_5);
    }

    public void OnGUI()
    {
        /*
        if (GUILayout.Button("ClearLog"))
            log = "";

        
        GPGSBinder.Inst.UnlockAchievement(GPGSIds.achievement_game_master, success => log = $"{success}");
        GPGSBinder.Inst.UnlockAchievement(GPGSIds.achievement_master_of_master, success => log = $"{success}");
        if (GUILayout.Button("Logout"))
            GPGSBinder.Inst.Logout();
        
        if (GUILayout.Button("SaveCloud"))
            GPGSBinder.Inst.SaveCloud("mysave", "want data", success => log = $"{success}");

        if (GUILayout.Button("LoadCloud"))
            GPGSBinder.Inst.LoadCloud("mysave", (success, data) => log = $"{success}, {data}");

        if (GUILayout.Button("DeleteCloud"))
            GPGSBinder.Inst.DeleteCloud("mysave", success => log = $"{success}");

        if (GUILayout.Button("ShowAchievementUI"))
            GPGSBinder.Inst.ShowAchievementUI();

        if (GUILayout.Button("UnlockAchievement_one"))
            GPGSBinder.Inst.UnlockAchievement(GPGSIds.achievement_one, success => log = $"{success}");

        if (GUILayout.Button("UnlockAchievement_two"))
            GPGSBinder.Inst.UnlockAchievement(GPGSIds.achievement_two, success => log = $"{success}");

        if (GUILayout.Button("IncrementAchievement_three"))
            GPGSBinder.Inst.IncrementAchievement(GPGSIds.achievement_three, 1, success => log = $"{success}");

        // 모든 리더보드 보여주기
        if (GUILayout.Button("ShowAllLeaderboardUI"))
            GPGSBinder.Inst.ShowAllLeaderboardUI();

        // 특정 리더보드 보여주기
        if (GUILayout.Button("ShowTargetLeaderboardUI_num"))
            GPGSBinder.Inst.ShowTargetLeaderboardUI(GPGSIds.leaderboard_num);

        // 리더보드에 점수 입력
        if (GUILayout.Button("ReportLeaderboard_num"))
            GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_num, 1000, success => log = $"{success}");

        if (GUILayout.Button("LoadAllLeaderboardArray_num"))
            GPGSBinder.Inst.LoadAllLeaderboardArray(GPGSIds.leaderboard_num, scores =>
            {
                log = "";
                for (int i = 0; i < scores.Length; i++)
                    log += $"{i}, {scores[i].rank}, {scores[i].value}, {scores[i].userID}, {scores[i].date}\n";
            });

        if (GUILayout.Button("LoadCustomLeaderboardArray_num"))
            GPGSBinder.Inst.LoadCustomLeaderboardArray(GPGSIds.leaderboard_num, 10,
                GooglePlayGames.BasicApi.LeaderboardStart.PlayerCentered, GooglePlayGames.BasicApi.LeaderboardTimeSpan.Daily, (success, scoreData) =>
                {
                    log = $"{success}\n";
                    var scores = scoreData.Scores;
                    for (int i = 0; i < scores.Length; i++)
                        log += $"{i}, {scores[i].rank}, {scores[i].value}, {scores[i].userID}, {scores[i].date}\n";
                });

        if (GUILayout.Button("IncrementEvent_event"))
            GPGSBinder.Inst.IncrementEvent(GPGSIds.event_event, 1);

        if (GUILayout.Button("LoadEvent_event"))
            GPGSBinder.Inst.LoadEvent(GPGSIds.event_event, (success, iEvent) =>
            {
                log = $"{success}, {iEvent.Name}, {iEvent.CurrentCount}";
            });

        if (GUILayout.Button("LoadAllEvent"))
            GPGSBinder.Inst.LoadAllEvent((success, iEvents) =>
            {
                log = $"{success}\n";
                foreach (var iEvent in iEvents)
                    log += $"{iEvent.Name}, {iEvent.CurrentCount}\n";
            });
        */
        //GUILayout.Label(log);
    }
}
