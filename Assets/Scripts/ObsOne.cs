using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Net.Sockets;

public class ObsOne : MonoBehaviour
{
    public Transform[] _innerShape;
    public float transformSpeed;
    public float rotateSpeed;
    void Start()
    {
        Sequence mySequence = DOTween.Sequence();
        float mult = Random.Range(0.5f,1.5f);
        mySequence.Append(transform.DOLocalMove(new Vector3(3.5f, 0.2f, 0), transformSpeed*mult).SetEase(Ease.InOutQuad));
        mySequence.Append(transform.DOLocalMove(new Vector3(-3.5f, 0.2f, 0), transformSpeed*mult).SetEase(Ease.InOutQuad));
        mySequence.SetLoops(-1 , LoopType.Restart);

        for (int i = 0; i < _innerShape.Length; i++)
        {
            _innerShape[i].DORotate(new Vector3(0, 0, 0), rotateSpeed ,RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
            
        }

    }
}
