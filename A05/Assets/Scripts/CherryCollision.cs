using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryCollision : MonoBehaviour
{
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
    		gameManager.UpdateScore(10);
    		Destroy(gameObject);
    	}
    }
}
