using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumController : MonoBehaviour
{
	public float moveSpeed;

	public Transform groundRight;
	public Transform groundLeft;
	public float radius;
	public LayerMask groundLayer;

	private SpriteRenderer sprite;
	private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
    	moveSpeed *= -1;

        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!Physics2D.OverlapCircle(groundRight.position, radius, groundLayer))
        	FlipOpossum();
        else if(!Physics2D.OverlapCircle(groundLeft.position, radius, groundLayer))
        	FlipOpossum();

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

    }

    void FlipOpossum()
    {
    	moveSpeed *= -1;

    	if(sprite.flipX == false)
    		sprite.flipX = true;
    	else
    		sprite.flipX = false;


    }
}
