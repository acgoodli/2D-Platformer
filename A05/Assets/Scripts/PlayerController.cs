using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public Transform ground;
    public float radius;
    public LayerMask groundLayer;
    public LayerMask wallLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;

    private bool isGround;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        isGround = true;

        animator.SetBool("Jump", false);
        animator.SetBool("Fall", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGround = (Physics2D.OverlapCircle(ground.position, radius, groundLayer) || Physics2D.OverlapCircle(ground.position, radius, wallLayer));

        //control left + right movement
        float movement = Input.GetAxis("Horizontal") * moveSpeed;
        animator.SetFloat("Speed", Mathf.Abs(movement));
        rb.velocity = new Vector2(movement, rb.velocity.y);

        if(sprite.flipX == true && movement > 0)
            sprite.flipX = false;
        else if(sprite.flipX == false && movement < 0)
            sprite.flipX = true;
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && isGround){
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
        }
        else if(rb.velocity.y <= 0 && !isGround)
            animator.SetBool("Fall", true);
        else if(rb.velocity.y == 0 || isGround)
            animator.SetBool("Fall", false);

        if(rb.velocity.y <= 0)
            animator.SetBool("Jump", false);
    }

    public void Hop(float jumpSpeed)
    {
        rb.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
        animator.SetBool("Jump", true);
    }
}
