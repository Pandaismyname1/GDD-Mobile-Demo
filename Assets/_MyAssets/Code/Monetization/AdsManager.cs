using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{

    public string AchievementID;
    private void Start()
    {
#if UNITY_ANDROID
        Advertisement.Initialize("2910208");
        Debug.Log("Android");
#elif UNITY_IOS
        Advertisement.Initialize("2910207");
        Debug.Log("iOS");
#endif
    }
    public void StartForcedAd()
    {
        Advertisement.Show();
    }
    public void StartRewardedAd()
    {
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleRewardedShowResult;

        Advertisement.Show("rewardedVideo");
    }
    void HandleRewardedShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            Social.ReportProgress(AchievementID, 100f, (bool success) =>
            {
            });
        }
    }
}
