using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject characterSelection;
    public GameObject mapSelection;
    public Animation loading;
    public Text BestRecord;
    public int money;

    public Text moneyTxt;
    public GameObject[] CharacterinMenu;


    public Transform CScamera;
    public Transform[] CSCpoints;
    int currentCharacter;
    public int equipedCharacter;
    public Image Equip;
    public Sprite[] CSbuttons;
    public int[] characterPrices;
    public Text characterPriceTXT;

    public GameObject unlockCharacter;
    public GameObject freeCharacter;

    int currentMap;
    public int selectedMap;
    public Sprite[] MapsSprite;
    public Image Select;
    public Image MapImage;
    public Sprite[] MSbuttons;
    public int[] mapPrices;
    public Text mapPriceTXT;
    public GameObject unlockMap;

    private RewardedAd _rewardedAd;
    private RewardedAd _mapRewardedAd;


    private void Start()
    {
        Application.targetFrameRate = 60;

        //resetProgress();
        if (PlayerPrefs.GetInt("First") == 0)
        {
            resetProgress();
            PlayerPrefs.SetInt("First", 1);
        }

        money = PlayerPrefs.GetInt("CoinAmount");
        moneyTxt.text = money.ToString();
        BestRecord.text = PlayerPrefs.GetInt("HighScore").ToString();

        checkEquipedCharacter();
        checkSelectedMap();
        currentCharacter = PlayerPrefs.GetInt("SelectedCharacter");
        equipedCharacter = currentCharacter;

        foreach (GameObject a in CharacterinMenu)
            a.SetActive(false);

        CharacterinMenu[currentCharacter].SetActive(true);

        currentMap = PlayerPrefs.GetInt("SelectedMap");
        selectedMap = currentMap;
        MapImage.sprite = MapsSprite[currentMap];

        _rewardedAd = new RewardedAd(AdController.Singleton.RewardedAdUnitId);
        _rewardedAd.OnAdFailedToLoad += (sender, args) => _rewardedAd.LoadAd(new AdRequest.Builder().Build());
        _rewardedAd.OnAdClosed += (sender, args) => _rewardedAd.LoadAd(new AdRequest.Builder().Build());
        _rewardedAd.LoadAd(new AdRequest.Builder().Build());

        _mapRewardedAd = new RewardedAd(AdController.Singleton.RewardedAdUnitId);
        _mapRewardedAd.OnAdFailedToLoad += (sender, args) => _mapRewardedAd.LoadAd(new AdRequest.Builder().Build());
        _mapRewardedAd.OnAdClosed += (sender, args) => _mapRewardedAd.LoadAd(new AdRequest.Builder().Build());
        _mapRewardedAd.LoadAd(new AdRequest.Builder().Build());
    }

    public void resetProgress()
    {
        PlayerPrefs.SetInt("SelectedCharacter", 0);
        PlayerPrefs.SetInt("SelectedMap", 0);

        PlayerPrefs.SetInt("Character_0", 1);
        PlayerPrefs.SetInt("Map_0", 1);
        for (int i = 1; i < CSCpoints.Length; i++)
            PlayerPrefs.SetInt("Character_" + i, 0);

        for (int i = 1; i < MapsSprite.Length; i++)
            PlayerPrefs.SetInt("Map_" + i, 0);
    }


    bool _switch;

    public void CharacterSelection()
    {
        if (!_switch)
        {
            characterSelection.SetActive(true);
            _switch = true;
        }
        else
        {
            characterSelection.SetActive(false);
            _switch = false;
        }
    }

    bool _switch2;

    public void MapSelection()
    {
        if (!_switch2)
        {
            mapSelection.SetActive(true);
            _switch2 = true;
        }
        else
        {
            mapSelection.SetActive(false);
            _switch2 = false;
        }
    }


    public void nextCharacter()
    {
        if (currentCharacter < CSCpoints.Length - 1)
        {
            currentCharacter++;
            checkEquipedCharacter();
        }
    }

    public void previousCharacter()
    {
        if (currentCharacter > 0)
        {
            currentCharacter--;
            checkEquipedCharacter();
        }
    }

    void checkEquipedCharacter()
    {
        if (PlayerPrefs.GetInt("Character_" + currentCharacter) == 0)
        {
            Equip.gameObject.SetActive(false);

            if (currentCharacter == 2 || currentCharacter == 5)
            {
                freeCharacter.SetActive(true);
                unlockCharacter.SetActive(false);

                return;
            }

            unlockCharacter.SetActive(true);
            freeCharacter.SetActive(false);

            characterPriceTXT.text = characterPrices[currentCharacter].ToString();
            return;
        }
        else
        {
            Equip.gameObject.SetActive(true);
            unlockCharacter.SetActive(false);
            freeCharacter.SetActive(false);
        }


        if (currentCharacter == equipedCharacter)
            Equip.sprite = CSbuttons[0];
        else
            Equip.sprite = CSbuttons[1];
    }

    public void equipCharacter()
    {
        if (currentCharacter == equipedCharacter)
            return;

        equipedCharacter = currentCharacter;
        Equip.sprite = CSbuttons[0];
        PlayerPrefs.SetInt("SelectedCharacter", currentCharacter);
        foreach (GameObject a in CharacterinMenu)
            a.SetActive(false);

        CharacterinMenu[currentCharacter].SetActive(true);


    }

    public void UnlockCharacter()
    {
        if (characterPrices[currentCharacter] > money)
            return;

        money -= characterPrices[currentCharacter];
        moneyTxt.text = money.ToString();
        PlayerPrefs.SetInt("CoinAmount", money);
        PlayerPrefs.SetInt("Character_" + currentCharacter, 1);
        Equip.gameObject.SetActive(true);
        unlockCharacter.SetActive(false);
        freeCharacter.SetActive(false);
        Equip.sprite = CSbuttons[0];
        equipedCharacter = currentCharacter;
        PlayerPrefs.SetInt("SelectedCharacter", currentCharacter);
        foreach (GameObject a in CharacterinMenu)
            a.SetActive(false);

        CharacterinMenu[currentCharacter].SetActive(true);

    }

    public void UnlockCharacterFree()
    {
        // play video. if player watches it to the end, then unlock the character
        if (!_rewardedAd.IsLoaded())
            _rewardedAd.LoadAd(new AdRequest.Builder().Build());
        _rewardedAd.OnUserEarnedReward += (sender, reward) =>
        {
            PlayerPrefs.SetInt("CoinAmount", money);
            PlayerPrefs.SetInt("Character_" + currentCharacter, 1);
            Equip.gameObject.SetActive(true);
            unlockCharacter.SetActive(false);
            freeCharacter.SetActive(false);
            Equip.sprite = CSbuttons[0];
            equipedCharacter = currentCharacter;
            PlayerPrefs.SetInt("SelectedCharacter", currentCharacter);
        };
        if (_rewardedAd.IsLoaded())
            _rewardedAd.Show();
    }

    private void Update()
    {
        CScamera.position = Vector3.Lerp(CScamera.position, CSCpoints[currentCharacter].position, Time.deltaTime * 7);
    }

    public void start()
    {
        loading.Play("Loading");
        StartCoroutine(wait());

        IEnumerator wait()
        {
            yield return new WaitForSeconds(0.30f);
            SceneManager.LoadScene("GamePlay");
        }
    }


    public void nextMap()
    {
        if (currentMap < MapsSprite.Length - 1)
        {
            currentMap++;
            MapImage.sprite = MapsSprite[currentMap];
            checkSelectedMap();
        }
    }

    public void previousMap()
    {
        if (currentMap > 0)
        {
            currentMap--;
            MapImage.sprite = MapsSprite[currentMap];

            checkSelectedMap();
        }
    }

    void checkSelectedMap()
    {
        if (PlayerPrefs.GetInt("Map_" + currentMap) == 0)
        {
            Select.gameObject.SetActive(false);
            unlockMap.SetActive(true);
            mapPriceTXT.text = mapPrices[currentMap].ToString();
            return;
        }
        else
        {
            Select.gameObject.SetActive(true);
            unlockMap.SetActive(false);
        }

        if (currentMap == selectedMap)
            Select.sprite = MSbuttons[0];
        else
            Select.sprite = MSbuttons[1];
    }

    public void selectMap()
    {
        if (currentMap == selectedMap)
            return;

        selectedMap = currentMap;
        Select.sprite = MSbuttons[0];

        PlayerPrefs.SetInt("SelectedMap", currentMap);
    }

    public void UnlockMap()
    {
        if (mapPrices[currentMap] > money)
            return;

        money -= mapPrices[currentMap];
        moneyTxt.text = money.ToString();
        PlayerPrefs.SetInt("CoinAmount", money);
        PlayerPrefs.SetInt("Map_" + currentMap, 1);
        Select.gameObject.SetActive(true);
        unlockMap.SetActive(false);
        Select.sprite = MSbuttons[0];
        selectedMap = currentMap;
        PlayerPrefs.SetInt("SelectedMap", currentMap);
    }

    public void UnlockMapFree()
    {
        if (!_mapRewardedAd.IsLoaded())
            _mapRewardedAd.LoadAd(new AdRequest.Builder().Build());
        _mapRewardedAd.OnUserEarnedReward += (sender, reward) =>
        {
            PlayerPrefs.SetInt("Map_" + currentMap, 1);
            Select.gameObject.SetActive(true);
            unlockMap.SetActive(false);
            Select.sprite = MSbuttons[0];
            selectedMap = currentMap;
            PlayerPrefs.SetInt("SelectedMap", currentMap);
        };
        
        if(_mapRewardedAd.IsLoaded())
            _mapRewardedAd.Show();
    }
}