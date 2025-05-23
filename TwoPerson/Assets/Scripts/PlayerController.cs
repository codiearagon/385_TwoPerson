using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpForce = 5.0f;

    private Rigidbody2D rb;
    [SerializeField] private bool grounded = false;
    [SerializeField] private bool jumpPressed = false;

    private float horizontalInput;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            grounded = false;
            jumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        if (jumpPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpPressed = false;
        }

        // Move horizontally
        if(horizontalInput != 0)
        {
            Vector2 movement = new Vector2(horizontalInput * speed, rb.linearVelocity.y) ;
            rb.linearVelocity = movement;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Testing purposes
        if (collision.gameObject.CompareTag("Potato"))
        {
            Debug.Log("Colliding with Potato");

            if(Input.GetKeyDown(KeyCode.Z))
            {
                collision.GetComponent<PotatoBehavior>().AddHealth(-10f);
            }
        }
    }
}
