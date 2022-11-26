using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public PlayerMovement player;
    public Player _player;
    public GameObject dead;
    public GameObject win;
    public GameObject startEvent;
    public Text BestRecord;
    public Text currentRecord;
    public Text money;
    public Animation taptostart;
    public Animation Loading;
    public Animation Restart;
    public Animation Claim;
    public GameObject MoneyPack;
    public Text winMoney;


    private void Awake()
    {
        currentRecord.gameObject.SetActive(true);
    }

    public void Start()
    {
      //  player.enabled = true;
      //  player.moveVelocity = player.startVelocity;
      //  player.GetComponent<Player>().enabled = true;
        startEvent.SetActive(false);
        taptostart.Play();
        currentRecord.gameObject.SetActive(true);
        //GM.sfx.start();
        money.text = PlayerPrefs.GetInt("CoinAmount").ToString();

        // if (AnalyticsManager.instance != null)
        //      AnalyticsManager.instance.SendLevelStartEvent(GM.currentLevel);
        BestRecord.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    private void Update()
    {
        currentRecord.text = ((int)_player.Score).ToString();
    }


    public void mainMenu()
    {
        Loading.Play("Loading");
        StartCoroutine(wait());
        IEnumerator wait()
        {
            yield return new WaitForSeconds(0.30f);
            SceneManager.LoadScene("Menu");

        }
    }

    public void restart()
    {
        Restart.Play();
        Loading.Play("Loading");

        StartCoroutine(wait());
        IEnumerator wait()
        {
            yield return new WaitForSeconds(0.30f);
            SceneManager.LoadScene("GamePlay");
        }
    }
}