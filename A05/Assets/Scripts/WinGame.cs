using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public float addScore;

    private float times;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        times = 1;
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && times == 1){
            times --;
            gameManager.UpdateScore(addScore);
            gameManager.Win();
            Destroy(gameObject);
        }
    }
}

