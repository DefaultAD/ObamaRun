using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float dealay = 3;

    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, player.position.x / dealay, Time.deltaTime * 10), transform.position.y, transform.position.z);


    }
}
