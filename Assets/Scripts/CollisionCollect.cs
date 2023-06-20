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

    private void Start()
    {
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
        else
        {
            PlayerAnim.SetBool("lose", true);
        }
    }


    public void StartGame(){
        StartPanel.SetActive(false);
        PlayerAnim.SetBool("start",true);
        transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
        playerController.runningSpeed = 10;
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
    }
    

}
