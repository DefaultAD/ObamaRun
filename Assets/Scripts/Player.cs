using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Animator _animator;
    [SerializeField] private Rigidbody[] ragdollLimbs;
    [SerializeField] private new Transform camera;
    public ParticleSystem smoke;
    public ParticleSystem CoinParticle;
    public ParticleSystem PowerUpParticle;
    [HideInInspector] public float ElapsedTime { get; private set; }
    public float Score { get; private set; }

    public float ScoreRate;
    [SerializeField] private Text moneyText;
    private PowerUp _powerUp = new PowerUp() { powerUpEnum = PowerUpEnum.None };
    [SerializeField] private Transform powerUpPoint;

    /*
    *****SFX*****
    */
    [SerializeField] private AudioClip StartSound,
        coinSound,
        magnetSound,
        strengthSound,
        twoXCoinSound,
        gameOverSound,
        highScoreSound,
        hitObstacleSoundWithStrength;

    public AudioSource Music;
    int numberOfAudioSources;
    int i;

    int n;
    //*****************


    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        
        if (PlayerPrefs.GetInt("IsResume") == 1)
        {
            ElapsedTime = PlayerPrefs.GetFloat("LastElapsedTime");
            _playerMovement.moveVelocity = PlayerPrefs.GetFloat("LastMovementSpeed");
            PlayerPrefs.SetInt("IsResume", 0);
        }
        
        //*****************
        numberOfAudioSources = gameObject.GetComponentsInChildren<AudioSource>().Length;
        i = gameObject.GetComponentsInChildren<AudioSource>().Length;
        AudioPlay(StartSound);
        //*****************
        _animator = _playerMovement._animator;
        ToggleRagDoll(false);
        Music = GameObject.Find("Music").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!_playerMovement._isGamePaused)
        {
            ElapsedTime += Time.deltaTime;
            Score = ElapsedTime * ScoreRate/2;
            _playerMovement.moveVelocity += Time.deltaTime * 0.2f;
            _playerMovement.spawnDeltaTime = 9f / _playerMovement.moveVelocity * 1.2f;

            #region Check to remove powerUp

            if (_powerUp.powerUpEnum != PowerUpEnum.None &&
                ElapsedTime - _powerUp.startingElapsedTime > _powerUp.duration)
            {
                _powerUp.powerUpEnum = PowerUpEnum.None;
                _powerUp.startingElapsedTime = 0;
                _powerUp.duration = 0;
                Destroy(powerUpPoint.GetChild(0).gameObject);
            }

            #endregion

            #region Do powerups

            if (_powerUp.powerUpEnum == PowerUpEnum.Magnet)
            {
                //! Not performant
                GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
                foreach (GameObject coin in coins)
                {
                    float distance = Vector3.Distance(transform.position, coin.transform.position);
                    if (distance < 8)
                        coin.transform.position = Vector3.Lerp(coin.transform.position, transform.position,
                            Time.deltaTime * 12f);
                }
            }

            #endregion
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
            OnHitObstacle();
        if (other.CompareTag("Coin"))
            OnHitCoin(other);
        if (other.CompareTag("PowerUp"))
            OnHitPowerUp(other.gameObject);
    }

    private void OnHitObstacle()
    {
        if (_powerUp.powerUpEnum == PowerUpEnum.Strength)
        {
            //*****************
            AudioPlay(hitObstacleSoundWithStrength);
            //*****************
            return;
        }

        //*****************
        AudioPlay(gameOverSound);
        //*****************
        PlayerPrefs.SetInt("DeathsAmount", PlayerPrefs.GetInt("DeathsAmount") + 1);
        PlayerPrefs.SetFloat("LastMovementSpeed", _playerMovement.moveVelocity);
        _playerMovement.moveVelocity = 0;
        _animator.enabled = false;
        ToggleRagDoll(true);
        Vector3 force = (40f * -transform.forward) + transform.right * Random.Range(-0.1f, 0.2f);
        ragdollLimbs[0].AddForce(force, ForceMode.Impulse);

        Vector3 newCameraPosition = transform.position;
        newCameraPosition.y = camera.position.y;
        camera.GetComponent<CameraFollow>().enabled = false;
        camera.DOMove(newCameraPosition, 2f).SetDelay(1f).Play();
        camera.DORotate(new Vector3(90, camera.rotation.eulerAngles.y, 180), 2f).SetDelay(1f).Play();
        _playerMovement._isGamePaused = true;
        _playerMovement.enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        Instantiate(smoke, transform.position, Quaternion.identity);
        _playerMovement.canvas.GetComponent<UI>().dead.SetActive(true);
        Music.pitch = 0.4f;
        Music.volume = 0.7f;
        PlayerPrefs.SetFloat("LastElapsedTime", ElapsedTime);
        if (Mathf.Abs(Score) > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", (int)Score);
            //*****************
            AudioPlay(highScoreSound);
            //*****************
        }

        PlayerPrefs.SetFloat("elapsedTimeAd", PlayerPrefs.GetFloat("elapsedTimeAd") + ElapsedTime);

        // if (PlayerPrefs.GetFloat("elapsedTimeAd") > 10f)
        // {
        //     AdController.Singleton.ShowRewardedAd(2.5f);
        //     PlayerPrefs.SetFloat("elapsedTimeAd", 0);
        // }
        if (PlayerPrefs.GetInt("DeathsAmount") > 0)
        {
            AudioListener.volume = 0;
            AdController.Singleton.ShowInterstitialAd(0);
            PlayerPrefs.SetInt("DeathsAmount", 0);
        }
    }

    private void OnHitCoin(Collider coin)
    {
        //*****************
        AudioPlay(coinSound);
        //*****************
        if (_powerUp.powerUpEnum == PowerUpEnum.TwoXCoin)
            GameManager.Singleton.CoinAmount++;
        GameManager.Singleton.CoinAmount++;
        PlayerPrefs.SetInt("CoinAmount", GameManager.Singleton.CoinAmount);
        moneyText.text = GameManager.Singleton.CoinAmount.ToString();

        Destroy(coin.gameObject);
        CoinParticle.Play();
    }

    private void OnHitPowerUp(GameObject powerUpObj)
    {
        if (_powerUp.powerUpEnum != PowerUpEnum.None)
        {
            Destroy(powerUpPoint.GetChild(0).gameObject);
        }

        _powerUp = powerUpObj.GetComponent<PowerUpObject>().PowerUp;
        _powerUp.startingElapsedTime = ElapsedTime;
        PowerUpParticle.Play();

        if (_powerUp.powerUpEnum == PowerUpEnum.Magnet)
        {
            //*****************
            AudioPlay(magnetSound);
            //*****************
            // enable Magnet
        }
        else if (_powerUp.powerUpEnum == PowerUpEnum.Strength)
        {
            //*****************
            AudioPlay(strengthSound);
            //*****************
            // enable Invisible
        }
        else if (_powerUp.powerUpEnum == PowerUpEnum.TwoXCoin)
        {
            //*****************
            AudioPlay(twoXCoinSound);
            //*****************
        }


        powerUpObj.transform.SetParent(powerUpPoint);
        powerUpObj.transform.position = powerUpPoint.position;
        powerUpObj.transform.localScale /= 3;
        // Destroy(powerUpObj);
    }

    private void ToggleRagDoll(bool ragDollOn)
    {
        foreach (Rigidbody ragdollLimb in ragdollLimbs)
        {
            ragdollLimb.useGravity = ragDollOn;
            ragdollLimb.isKinematic = !ragDollOn;
        }
    }

    private void AudioPlay(AudioClip source)
    {
        if (i % numberOfAudioSources == n)
        {
            i++;
            n++;
            gameObject.GetComponentsInChildren<AudioSource>()[n].clip = source;
            gameObject.GetComponentsInChildren<AudioSource>()[n].Play();
            if (n == numberOfAudioSources - 1)
            {
                i = numberOfAudioSources;
                n = 0;
            }
        }
    }
}