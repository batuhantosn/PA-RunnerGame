using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class CollisionCollect : MonoBehaviour
{

    public PlayerController playerController;
    public Animator PlayerAnim;
    public GameObject Player;
    public GameObject EndPanel;
    public GameObject StartPanel;
    public Vector3 PLayerStartPos;
    public GameObject SpeedBoosterIcon;
    private InGameRanking ig;

    private void Start()
    {
        SpeedBoosterIcon.SetActive(false);
        PLayerStartPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        PlayerAnim = Player.GetComponentInChildren<Animator>();
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            if (ig.nameText[4].text == "Player")
            {
                Debug.Log("you win");
            }else
            {
                Debug.Log("you lose");
            }
                   PlayerFinished();
        }
        if (other.CompareTag("Speedboost"))
        {
            SpeedBoosterIcon.SetActive(true);
            playerController.runningSpeed += 3f ;
            StartCoroutine(SlowWileCoroutine()); 
        }
    }
    void PlayerFinished(){
            playerController.runningSpeed = 0;
            transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
            EndPanel.SetActive(true);
            PlayerAnim.SetBool("win", true);
            GameManager.instance.isGameOVer = true;      
    }


    public void StartGame(){
        StartPanel.SetActive(false);
        PlayerAnim.SetBool("start",true);
        transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
        playerController.runningSpeed = 8f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            RestartGame();
        }
    }
        public void RestartGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        transform.position = PLayerStartPos;
    }
    private IEnumerator SlowWileCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        playerController.runningSpeed-=3f;
        SpeedBoosterIcon.SetActive(false);
    }
    

}
