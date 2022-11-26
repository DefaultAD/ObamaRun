using System;
using UnityEngine;

[Serializable]
public class PowerUp
{
    public PowerUpEnum powerUpEnum;
    [HideInInspector] public float startingElapsedTime;
    public float duration;
}

public enum PowerUpEnum
{
    None,
    Magnet,
    Strength,
    TwoXCoin
}