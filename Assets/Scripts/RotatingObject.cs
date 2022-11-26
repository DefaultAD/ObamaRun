using DG.Tweening;
using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    [SerializeField] private RotationAxis rotationAxis;
    [SerializeField] private float rotationDuration;

    private void Start()
    {
        Vector3 tmpAxis = Vector3.zero;
        if (rotationAxis == RotationAxis.XAxis)
            tmpAxis = Vector3.forward;
        else if(rotationAxis == RotationAxis.YAxis)
            tmpAxis = Vector3.up;
        else if (rotationAxis == RotationAxis.ZAxis)
            tmpAxis = Vector3.right;
        
        transform.DORotate(transform.rotation.eulerAngles + tmpAxis * 180, rotationDuration / 2)
            .SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental).Play();
    }
}

enum RotationAxis
{
    XAxis,
    YAxis,
    ZAxis
}
