using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackEnd : MonoBehaviour
{
    public PlayerMovement PM;
    public Transform[] Characters;
    public Transform[] Maps;
    public Material[] SkyBox;

    public GameObject[] Obstacles;
    public GameObject[] PowerUps;
    public GameObject Ground;
    public Transform SpawnPoint;
    public Transform CurrentMap;

    public Color[] fogColor;
    public float[] fogMin;
    public float[] fogMax;
    public GameObject birdParticle;

    public float speed;

    public UI ui;
    private void Start()
    {
        int cMap = PlayerPrefs.GetInt("SelectedMap");
        CurrentMap = Maps[cMap];
        RenderSettings.skybox = SkyBox[cMap];
        Maps[cMap].gameObject.SetActive(true);
        RenderSettings.fogColor = fogColor[cMap];
        RenderSettings.fogStartDistance = fogMin[cMap];
        RenderSettings.fogEndDistance = fogMax[cMap];
        if (cMap == 0)
            birdParticle.SetActive(true);
        int cCharacter = PlayerPrefs.GetInt("SelectedCharacter");
        PM = Characters[cCharacter].GetComponent<PlayerMovement>();
        Characters[cCharacter].gameObject.SetActive(true);
        ui._player = Characters[cCharacter].GetComponent<Player>();
        SpawnPoint = CurrentMap.GetChild(CurrentMap.childCount-1).transform.GetChild(0);

        int a = 0;
        foreach(Transform child in CurrentMap)
        {
            a++;
            if(a > 3)
            {
                GameObject spawnedObstacle = Instantiate(Obstacles[Random.Range(0, Obstacles.Length)], child.transform.GetChild(0).position - transform.forward, Quaternion.identity);
                spawnedObstacle.transform.SetParent(child.transform);

            }

        }
    }
    private void Update()
    {
        CurrentMap.position -= transform.forward * (Time.deltaTime * PM.moveVelocity);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            other.transform.position = SpawnPoint.position;
            SpawnPoint = other.transform.GetChild(0);

            if (other.transform.childCount > 3)
                Destroy(other.transform.GetChild(3).gameObject);

            GameObject spawnedObstacle = Instantiate(Obstacles[Random.Range(0, Obstacles.Length)],
            SpawnPoint.position - transform.forward, Quaternion.identity);
            spawnedObstacle.transform.SetParent(other.transform);

            if (Random.Range(0f, 1f) > 0.5f)
                spawnedObstacle.transform.GetChild(0).gameObject.SetActive(false);

            if (Random.Range(0f, 1f) > 0.8f)
            {
                // set a random powerUp and activate it
                GameObject randomPowerUp = PowerUps[Random.Range(0, PowerUps.Length)];
                GameObject powerUp = Instantiate(randomPowerUp, spawnedObstacle.transform.GetChild(1).position,
                    randomPowerUp.transform.rotation);
                powerUp.transform.SetParent(spawnedObstacle.transform.GetChild(1));
            }
        }
    }
}
