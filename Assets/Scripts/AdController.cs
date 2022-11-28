using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class AdController : MonoBehaviour
{
    #region Singleton

    private static AdController instance;

    public static AdController Singleton
    {
        get => instance;
        private set => instance = value;
    }

    #endregion

    public GameObject loadingScreen;
    public GameObject loseButtons;

    private RewardedAd _rewardedAd;
    private InterstitialAd _interstitialAd;
    public string RewardedAdUnitId { get; private set; } 
    public string InterstitialAdUnitId { get; private set; }
    
    
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
        DontDestroyOnLoad(gameObject);

        //PlayerPrefs.DeleteAll();
    }
    void Update()
    {
        loseButtons = GameObject.Find("Canvas/LoseButtons/Buttons");
    }
    void Start()
    {
#if UNITY_EDITOR
        RewardedAdUnitId = "unused";
         InterstitialAdUnitId = "unused";
         #elif UNITY_ANDROID
         RewardedAdUnitId = "ca-app-pub-6067100235232087/1938711780";
         InterstitialAdUnitId = "ca-app-pub-6067100235232087/5300152547";
         #elif UNITY_IPHONE
         RewardedAdUnitId = "ca-app-pub-6067100235232087/8517929553";
         InterstitialAdUnitId = "ca-app-pub-6067100235232087/9706301410";
         #else
         RewardedAdUnitId = "unkown platform";
         InterstitialAdUnitId = "unkown platform";
#endif
        // RewardedAdUnitId = "ca-app-pub-3940256099942544/5224354917";
        // InterstitialAdUnitId = "ca-app-pub-3940256099942544/1033173712";

        MobileAds.Initialize(status =>
        {
            // foreach (AdapterStatus adapterStatus in status.getAdapterStatusMap().Values)
            // {
            //     if (adapterStatus.InitializationState == AdapterState.NotReady)
            //     {
            //         MobileAds.Initialize(initializationStatus => { });
            //         break;
            //     }
            // }
        });
        _rewardedAd = new RewardedAd(RewardedAdUnitId);
        _interstitialAd = new InterstitialAd(InterstitialAdUnitId);
        SetRewardedAdEvents();
        SetInterstitialAdEvent();
        _rewardedAd.LoadAd(new AdRequest.Builder().Build());
        _interstitialAd.LoadAd(new AdRequest.Builder().Build());
    }

    private void SetRewardedAdEvents()
    {
        _rewardedAd.OnAdClosed += (sender, args) =>
        {
            AudioListener.volume = 0.7f;
            // _rewardedAd = new RewardedAd(RewardedAdUnitId);
            _rewardedAd.LoadAd(new AdRequest.Builder().Build());
        };
        _rewardedAd.OnAdFailedToLoad += (sender, args) =>
        {
            AudioListener.volume = 0.7f;
            // _rewardedAd = new RewardedAd(RewardedAdUnitId);
            _rewardedAd.LoadAd(new AdRequest.Builder().Build());
        };
    }

    private void SetInterstitialAdEvent()
    {
        _interstitialAd.OnAdClosed += (sender, args) =>
        {
            // _interstitialAd = new InterstitialAd(InterstitialAdUnitId);
            AudioListener.volume = 0.7f;
            loseButtons.SetActive(true);
            _interstitialAd.LoadAd(new AdRequest.Builder().Build());
        };
        _interstitialAd.OnAdFailedToLoad += (sender, args) =>
        {
            AudioListener.volume = 0.7f;
            // _interstitialAd = new InterstitialAd(InterstitialAdUnitId);
            _interstitialAd.LoadAd(new AdRequest.Builder().Build());
        };
    }

    public void ShowRewardedAd(float delay = 0f)
    {
        IEnumerator ShowAd()
        {
            yield return new WaitForSeconds(delay);
            if (_rewardedAd.IsLoaded())
            {
                loadingScreen.SetActive(false);
                // Debug.Log("showing rewarded ad...");
                _rewardedAd.Show();
            }
        }

        StartCoroutine(ShowAd());
    }

    public void ShowInterstitialAd(float delay = 0f)
    {
        IEnumerator ShowAd()
        {
            yield return new WaitForSeconds(delay);
            if (_interstitialAd.IsLoaded())
            {
                Debug.Log("showing interstitial ad...");
                _interstitialAd.Show();
            }
        }

        StartCoroutine(ShowAd());
    }
}