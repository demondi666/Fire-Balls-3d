using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstaclePattern : MonoBehaviour
{
    [SerializeField] private float _animationDuration;
    [SerializeField] private float _angleRotation;
    private void Start()
    {
        transform.DORotate(new Vector3(0, _angleRotation, 0), _animationDuration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
    }

}
