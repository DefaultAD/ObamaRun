using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text moneyTxt;
    private RewardedAd _rewardedAdToResume;
    
    
    public int CoinAmount { get; set; }

    #region Singleton

    private static GameManager _singleton;
    public static GameManager Singleton => _singleton;

    #endregion

    public Texture Map;
    [SerializeField] private GameObject[] world;

    private void Awake()
    {
        _singleton = this;
        CoinAmount = PlayerPrefs.GetInt("CoinAmount");
    }

    private void Start()
    {
        _rewardedAdToResume = new RewardedAd(AdController.Singleton.RewardedAdUnitId);
        _rewardedAdToResume.OnAdFailedToLoad +=
            (sender, args) => _rewardedAdToResume.LoadAd(new AdRequest.Builder().Build());
        _rewardedAdToResume.LoadAd(new AdRequest.Builder().Build());
        moneyTxt.text = PlayerPrefs.GetInt("CoinAmount").ToString();
        world = GameObject.FindGameObjectsWithTag("Ground");
        foreach (GameObject Cube in world)
        {
            Cube.transform.Find("Cube").GetComponent<Renderer>().material.mainTexture = Map;
        }
    }

    public void ResumeWithAd()
    {
        _rewardedAdToResume.OnUserEarnedReward += (sender, reward) => ResumeGame();
            
        if (_rewardedAdToResume.IsLoaded())
            _rewardedAdToResume.Show();
    }

    private void ResumeGame()
    {
        Debug.Log("resuming game...");
        PlayerPrefs.SetInt("IsResume", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
