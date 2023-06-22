using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Runner : MonoBehaviour
{
    public Vector3 RunnerStartPos;
    public GameObject SpeedBoosterIcon;
    public Animator PlayerAnim;
    public GameObject Player;


    private void Start() {
        RunnerStartPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        PlayerAnim = Player.GetComponentInChildren<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = RunnerStartPos;
        }
    }
}
