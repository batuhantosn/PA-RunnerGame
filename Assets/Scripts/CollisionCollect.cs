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

    private void Start()
    {
        PLayerStartPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        PlayerAnim = Player.GetComponentInChildren<Animator>();
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            playerController.runningSpeed = 0;
            transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
            EndPanel.SetActive(true);
            PlayerAnim.SetBool("win", true);             
        }
        if (other.CompareTag("Speedboost"))
        {
            playerController.runningSpeed += 3f ;
            StartCoroutine(SlowWileCoroutine()); 
        }
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
    }
    

}
