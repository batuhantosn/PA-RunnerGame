using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class CollisionCollect : Runner
{

    public PlayerController playerController;
    public Animator PlayerAnim;
    public GameObject Player;
    public GameObject EndPanel;
    public GameObject StartPanel;

    private void Start()
    {
        SpeedBoosterIcon.SetActive(false);
        PlayerAnim = Player.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            if (GameManager.instance.ig.nameText[4].text == "Player")
            {
                PlayerAnim.SetBool("win", true);
            }
            else
            {
                PlayerAnim.SetBool("lose", true);
            }
            PlayerFinished();
        }
        if (other.CompareTag("Speedboost"))
        {
            SpeedBoosterIcon.SetActive(true);
            playerController.runningSpeed += 3f;
            StartCoroutine(SlowWileCoroutine());
        }
    }
    void PlayerFinished()
    {
        playerController.runningSpeed = 0;
        transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
        EndPanel.SetActive(true);
        GameManager.instance.isGameOVer = true;
    }


    public void StartGame()
    {
        StartPanel.SetActive(false);
        PlayerAnim.SetBool("start", true);
        transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
        playerController.runningSpeed = 8f;
    }
    public void RestartGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private IEnumerator SlowWileCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        playerController.runningSpeed -= 3f;
        SpeedBoosterIcon.SetActive(false);
    }


}
