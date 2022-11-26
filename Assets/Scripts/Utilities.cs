using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    public static float Distance_Z(Vector3 a1, Vector3 a2)
    {
        a1.x = a1.y = a2.x = a2.y = 0;
        return Vector3.Distance(a1, a2);
    }
}
