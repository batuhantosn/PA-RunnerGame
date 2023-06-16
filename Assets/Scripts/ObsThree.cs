using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObsThree : MonoBehaviour
{
    [SerializeField] private Transform blade;
    [SerializeField] private float rotateArmSpeed;

    private void Start() {
            Sequence mySequence = DOTween.Sequence();
            mySequence.Append(transform.DOLocalRotate(new Vector3(0,0,90),rotateArmSpeed*Random.Range(0.5f,1.5f),RotateMode.LocalAxisAdd).SetEase(Ease.Linear));
            mySequence.Append(blade.DOLocalRotate(new Vector3(-360,0,0),rotateArmSpeed,RotateMode.LocalAxisAdd).SetEase(Ease.Linear));
            mySequence.Append(transform.DOLocalRotate(new Vector3(0,0,-90),rotateArmSpeed,RotateMode.LocalAxisAdd).SetEase(Ease.Linear));

            mySequence.SetLoops(-1,LoopType.Restart);

    }
}
