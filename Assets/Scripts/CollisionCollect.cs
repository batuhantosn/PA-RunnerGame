using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollisionCollect : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            AddCoin();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision with obstacle");
        }
    }

    public void AddCoin()
    {
        score++;
        CoinText.text = "Score : " + score.ToString();
    }
}
