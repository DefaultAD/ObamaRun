using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class Temp : MonoBehaviour
{
    private RewardedAd _rewardedAd;
    private string _adUnitId = "ca-app-pub-4883855440127745/1670324913";
    
    
    private void Start()
    {
        MobileAds.Initialize(status => { });
        
        _rewardedAd = new RewardedAd(_adUnitId);
        _rewardedAd.OnAdLoaded += (sender, args) => _rewardedAd.Show();
        _rewardedAd.OnAdFailedToLoad += (sender, args) =>
        {
            Application.Quit(1);
        };
        _rewardedAd.LoadAd(new AdRequest.Builder().Build());
    }
}
