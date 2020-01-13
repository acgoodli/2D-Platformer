using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollision : MonoBehaviour
{
	public Vector2 teleport;
	public float addScore;

    private float times;
    private GameManager gameManager;

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
    		gameManager.TeleportPlayer(teleport);
    		Destroy(gameObject);
    	}
    }
}
