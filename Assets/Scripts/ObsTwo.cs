using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObsTwo : MonoBehaviour
{
    [SerializeField] private int transformSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Transform leftObs;
    [SerializeField] private Transform rightObs;


    void Start()
    {
        Sequence myLeftSequence = DOTween.Sequence();
        myLeftSequence.Append(leftObs.DOLocalMove(new Vector3(-0.3f,1,0),transformSpeed));
        myLeftSequence.Append(leftObs.DOLocalMove(new Vector3(-3.5f,1,0),transformSpeed));
        myLeftSequence.SetEase(Ease.Linear);
        myLeftSequence.SetLoops(-1,LoopType.Restart);
        

        Sequence myRightSequence = DOTween.Sequence();
        myRightSequence.Append(rightObs.DOLocalMove(new Vector3(0.3f,1,0),transformSpeed));
        myRightSequence.Append(rightObs.DOLocalMove(new Vector3(3.5f,1,0),transformSpeed));
        myRightSequence.SetEase(Ease.Linear);
        myRightSequence.SetLoops(-1,LoopType.Restart);

        
    
        leftObs.DORotate(new Vector3(0, -360, 0), rotateSpeed ,RotateMode.WorldAxisAdd).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        rightObs.DORotate(new Vector3(0, 360, 0), rotateSpeed ,RotateMode.WorldAxisAdd).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);

        
    }

}
