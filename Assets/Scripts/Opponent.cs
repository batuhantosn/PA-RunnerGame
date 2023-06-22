using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : Runner
{
    public NavMeshAgent OpponentAgent;
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        SpeedBoosterIcon.SetActive(false);
        OpponentAgent = GetComponent<NavMeshAgent>();
        
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
