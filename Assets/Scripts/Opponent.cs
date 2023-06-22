using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{

    public NavMeshAgent OpponentAgent;
    public GameObject Target;
    public Vector3 OpponentStartPos;
    public GameObject SpeedBoosterIcon;
    // Start is called before the first frame update
    void Start()
    {
        SpeedBoosterIcon.SetActive(false);
        OpponentAgent = GetComponent<NavMeshAgent>();
        OpponentStartPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        OpponentAgent.SetDestination(Target.transform.position);
        if (GameManager.instance.isGameOVer)
        {
            OpponentAgent.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = OpponentStartPos;
        }
    }

    private void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Speedboost"))
    {
        OpponentAgent.speed +=3f; 
        StartCoroutine(SlowWileCoroutine());
        SpeedBoosterIcon.SetActive(true);
    }    
    }
     private IEnumerator SlowWileCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        OpponentAgent.speed-=3f;
        SpeedBoosterIcon.SetActive(false);
    }

}
