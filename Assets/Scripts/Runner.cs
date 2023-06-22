using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public abstract class Runner : MonoBehaviour
{
    public Vector3 RunnerStartPos;
    public GameObject SpeedBoosterIcon;
   


    private void Start() {
        RunnerStartPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") && gameObject.name == "Player")
        {   

            transform.position = RunnerStartPos;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = RunnerStartPos;
        }
    }

    
}
