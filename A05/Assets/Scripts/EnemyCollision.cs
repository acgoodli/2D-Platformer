using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
	public Transform aboveLeft;
	public Transform aboveRight;
	public LayerMask playerLayer;

	public float hopSpeed;
	public float score;

    private float times;
    private GameManager gameManager;

	void Awake()
	{
		times = 1;
		gameManager = GameObject.FindObjectOfType<GameManager>();
	}

     void OnTriggerEnter2D(Collider2D other)
    {
    	if (other.gameObject.tag == "Player" && times == 1 && Physics2D.OverlapArea(aboveLeft.position, aboveRight.position, playerLayer)){
    		times --;
    		gameManager.UpdateScore(score);
    		gameManager.Hop(hopSpeed);
    		Destroy(gameObject);
    	}
    	else if (other.gameObject.tag == "Player" && times == 1)
    	{
    		gameManager.Death();
    	}
    	
    }
}
