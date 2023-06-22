using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : Runner
{
    public Animator PlayerAnim;
    private Transform PlayerRotation;
    public GameObject Player;
    public NavMeshAgent OpponentAgent;
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        
        PlayerAnim = Player.GetComponentInChildren<Animator>();
        PlayerRotation = Player.GetComponentInChildren<Transform>();
        SpeedBoosterIcon.SetActive(false);
        OpponentAgent = GetComponent<NavMeshAgent>();
        OpponentAgent.isStopped = true;
        PlayerRotation.Rotate(transform.rotation.x, 180, transform.rotation.z,Space.Self);
        
        
    }
    // Update is called once per frame
    void Update()
    {
        OpponentAgent.SetDestination(Target.transform.position);

        if (GameManager.instance.isGameOVer)
        {
            OpponentAgent.isStopped = true;
            PlayerAnim.SetBool("lose",true);
        }
    }
    public void StartButton(){
        OpponentAgent.isStopped = false;
        PlayerAnim.SetBool("start",true);
        
    }

    private void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Speedboost"))
    {
        OpponentAgent.speed +=3f; 
        StartCoroutine(SlowWileCoroutine());
        SpeedBoosterIcon.SetActive(true);
    }
    if (other.CompareTag("End"))
        {
            if (GameManager.instance.ig.nameText[4].text == Player.name)
            {
                PlayerAnim.SetBool("win", true);
            }else
            {
                PlayerAnim.SetBool("lose", true);
            }
        }    
    }
     private IEnumerator SlowWileCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        OpponentAgent.speed-=3f;
        SpeedBoosterIcon.SetActive(false);
    }

}
