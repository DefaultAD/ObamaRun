using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAudio : MonoBehaviour
{
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        camera.GetComponent<AudioListener>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
