using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCollision : MonoBehaviour
{
	private GameManager gameManager;
	private float times;

	void Awake()
	{
		times = 1;
		gameManager = GameObject.FindObjectOfType<GameManager>();
	}

     void OnTriggerEnter2D(Collider2D other)
    {
    	if (other.gameObject.tag == "Player" && times == 1){
    		times --;
    		gameManager.Death();
    	}
    }
}
