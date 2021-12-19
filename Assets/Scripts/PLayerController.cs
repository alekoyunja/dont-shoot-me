using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehaviour
{

    Rigidbody2D playerRB;

    Animator playerAnimator;

    public float moveSpeed = 1f;
    public float jumpSpeed = 1f, jumpFrequency=1f, nextJumpTime;

    bool facingRight = true;

    public bool isGrounded = false;
    public Transform groundCheckPosition;
    public float groudnCheckRadius;
    public LayerMask groundLayer;

   
    
    void Awake()
    {
        
    }

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRB =GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        HorizontalMove();
        onGroundCheck();
        

        if (playerRB.velocity.x < 0 && facingRight)
        {
            flipFace();
        }
        else if (playerRB.velocity.x > 0 && !facingRight)
        {
            flipFace();
        }

        if(Input.GetAxis("Vertical")>0 && isGrounded  && (nextJumpTime<Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            jump();
        }

    }

    

    void FixedUpdate()
    {

    }

    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, playerRB.velocity.y);

        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
    }

    void flipFace()
    {
        facingRight = !facingRight;

        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void jump()
    {
        playerRB.AddForce(new Vector2(0f,jumpSpeed));
    }

    void onGroundCheck()
    {
        isGrounded=Physics2D.OverlapCircle(groundCheckPosition.position, groudnCheckRadius, groundLayer);
        playerAnimator.SetBool("isGrounded", isGrounded);
    }

    

}
