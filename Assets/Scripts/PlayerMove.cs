using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 8f;
    public float horizontal;
    public float jump = 5f;
    private bool right = true;
    public int maxJumps = 2;
    private int jumpCount;
    private bool top;
    private bool upsideDown = false;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Animator animator;
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (isGrounded())
        {
            jumpCount = 0;
        }
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            float jumpDirection = upsideDown ? -1f : 1f;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump * jumpDirection);
            jumpCount++;
        }
        if (horizontal == 0f)
        {
            animator.SetBool("run", false);
        }
        else
        {
            animator.SetBool("run", true);
        }
        if (isGrounded())
        {
            animator.SetBool("jump", false);
        }
        else
        {
            animator.SetBool("jump", true);
        }
        animator.SetBool("fall", !isGrounded() && rb.linearVelocity.y < 0);

        flip();
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.gravityScale *= -1;
            upsideDown = !upsideDown;
            Rotation();
        }
        

    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void flip()
    {
        if (right == true && horizontal < 0f || right == false && horizontal > 0f)
        {
            right = !right;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

    }
    void Rotation()
    {
        if (top == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);

        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }

        top = !top;
    }
}
