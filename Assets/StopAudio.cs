using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public void Mute()
    {
        AudioListener.volume = 0f;
    }
}
