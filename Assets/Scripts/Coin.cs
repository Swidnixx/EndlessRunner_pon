using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Transform player;

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        bool atract = GameManager.Instance.powerupManager.Magnet.magnetActive;
        bool inRange = Vector2.Distance(transform.position, player.position) < GameManager.Instance.powerupManager.Magnet.magnetRange;
        if(atract && inRange)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                Time.deltaTime * 5);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.CoinCollect();
            Destroy(gameObject);
        }
    }
}
