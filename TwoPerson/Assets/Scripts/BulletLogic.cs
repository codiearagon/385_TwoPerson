using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    private float bulletDamage = 2.0f;

    private float speed = 10.0f;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Ground"))
                Destroy(gameObject);
            else if(collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<EnemyBehavior>().ChangeHealthBy(-bulletDamage);
                Destroy(gameObject);
            }
        }
        
    }
}
