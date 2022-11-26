using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    private static Store _store;
    public static Store Singleton => _store;
    [HideInInspector] public Character myCharacters;
    [HideInInspector] public Map myMaps;
    

    private void Awake()
    {
        if (_store != null)
        {
            Destroy(_store);
        }
        else
        {
            _store = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        myCharacters = (Character)PlayerPrefs.GetInt("myCharacters");
        myMaps = (Map)PlayerPrefs.GetInt("myMaps");
    }
}

[Flags]
public enum Character
{
    Putin = 1,
    Obama = 2
}

[Flags]
public enum Map
{
    Putin = 1,
    Obama = 2
}
