using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class CheckConnection : MonoBehaviour
{
    public GameObject connectionPrefab;
    public Button tryAgain;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckInternetConnection());
    }

    IEnumerator CheckInternetConnection()
    {
        UnityWebRequest request = new UnityWebRequest("https://www.google.com/");
        yield return request.SendWebRequest();

        if (request.error != null)
        {
            connectionPrefab.SetActive(true);
        }
        else
        {
            connectionPrefab.SetActive(false);
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
