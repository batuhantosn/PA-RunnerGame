using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using DG.Tweening;

public class CollisionCollect : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;

    public PlayerController playerController;
    public int maxScore;

    public Animator PlayerAnim;
    public GameObject Player;
    public GameObject EndPanel;
    public GameObject StartPanel;

    public Transform targetLoc;
    public GameObject coinPrefab;

    public Queue<GameObject> coinQueue = new Queue<GameObject>();
    private Vector3 targetPosition;
    public GameObject canvasObject;

    public AudioSource _audioSource;
    public AudioClip _clip;

    private void Awake()
    {
        CreateCoin();
    }

    private void Start()
    {
        PlayerAnim = Player.GetComponentInChildren<Animator>();
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            _audioSource.PlayOneShot(_clip);
            Destroy(other.gameObject);
            AddCoin();
        }
        else if (other.CompareTag("End"))
        {
            playerController.runningSpeed = 0;
            transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
            EndPanel.SetActive(true);
            if (score >= maxScore)
            {
                //Debug.Log("You Win!..");
                PlayerAnim.SetBool("win", true);
            }
            else
            {
                //Debug.Log("You Lose!..");
                PlayerAnim.SetBool("lose", true);
            }

        }
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
    public void CreateCoin()
    {
        for (int i = 0; i < 15; i++)
        {
            GameObject coin = Instantiate(coinPrefab);
            coin.transform.SetParent(canvasObject.transform, false);
            coin.transform.position = transform.position;
            coin.SetActive(false);
            coinQueue.Enqueue(coin);
           
        }
    }
    public void AddCoin()
    {
        
        

        for (int i = 0; i < 1; i++)
        {
            GameObject coin = coinQueue.Dequeue();
            coin.transform.position = Player.transform.position;
            coin.SetActive(true);

            coin.transform.DOMove(targetLoc.position, Random.Range(1f, 3f)).SetEase(Ease.OutSine).OnComplete(() =>
            {
                coin.SetActive(false);
                coinQueue.Enqueue(coin);
            });

        }
        score++;
        CoinText.text = "x " + score.ToString();


    }

    

}
