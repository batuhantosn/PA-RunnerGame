using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObsFour : MonoBehaviour
{
    public Transform[] _innerShape;
    public float rotateSpeed;

    void Start() {
        for (int i = 0; i < _innerShape.Length; i++)
        {
            _innerShape[i].DOLocalRotate(new Vector3(0, 0, 0), rotateSpeed, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        }
    }
}
