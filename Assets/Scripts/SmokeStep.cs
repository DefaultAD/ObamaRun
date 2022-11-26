using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeStep : MonoBehaviour
{
    public ParticleSystem Smoke;
    public bool emit;
    bool a = true;
    // Update is called once per frame
    void Update()
    {
        if (emit)
        {
            if (a)
            {
                a = false;
                Smoke.Play();
            }
        }
        else
            a = true;
    }
}
