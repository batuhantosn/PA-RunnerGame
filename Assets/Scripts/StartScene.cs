using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartScene : MonoBehaviour
{
    public GameObject Canvas;
    public Button StartButton;
    void Start()
    {
        StartCoroutine(StartSceneCoroutine());
    }

    private IEnumerator StartSceneCoroutine()
    {
        yield return new WaitForSeconds(3.0f);
        Canvas.SetActive(true);
        StartButton.transform.DOShakeRotation(1,90,10,90,true);
    }
}
