using System.Collections;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private float health;

    private Rigidbody2D rb;
    [SerializeField] private Transform potatoTarget;
    public bool isAttacking;
    public float attackCooldown; // Time in seconds before the enemy can attack again
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), FindAnyObjectByType<PlayerController>().GetComponent<Collider2D>());
        potatoTarget = FindAnyObjectByType<PotatoBehavior>().transform.GetChild(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(Vector2.MoveTowards(rb.position, potatoTarget.position, speed * Time.fixedDeltaTime));
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), FindAnyObjectByType<EnemyBehavior>().GetComponent<Collider2D>());
    }

    public IEnumerator Attack()
    {
        isAttacking = true;
        potatoTarget.GetComponentInParent<PotatoBehavior>().AddHealth(-damage);
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }
}
