using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	//0,-13
    	Vector3 playerPosition = new Vector3(player.transform.position.x, 0f, -10f);
        transform.position = playerPosition;
    }
}
