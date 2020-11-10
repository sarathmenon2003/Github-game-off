using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 10f;
    public Animator animator;
    public float jumpForce;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int extraJumps;
    public int extraJumpsValue;
    bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);
        Walk(dir);
        animator.SetFloat("speed", Mathf.Abs(x));
        
        if (x < 0 && facingRight)
        {
            flip();
        }
        else if (x > 0 && !facingRight)
		{
            flip();
		}

    }
    private void Walk(Vector2 dir)
    {
        rb.velocity = (new Vector2(dir.x * speed, rb.velocity.y));

    }
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
       
        if(isGrounded == true)
		{
            extraJumps = extraJumpsValue;
		}
        
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0) 
        {
            animator.SetBool("isJumping", true);
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if(isGrounded == true && Input.GetKeyDown(KeyCode.Space) && extraJumps == 0)
		{
            animator.SetBool("isJumping", true);
            rb.velocity = Vector2.up * jumpForce;
        }
        
        
        animator.SetBool("isJumping", !isGrounded);
        animator.SetFloat("yVel", rb.velocity.y);
        
    }
    void flip()
	{

        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
	}

}