using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PotatoBehavior : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private TMP_Text healthText;

    [SerializeField] private float maxHealth;
    [SerializeField] private float health;

    void Start()
    {
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
        healthText.text = health + "/" + maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            if (!other.GetComponent<EnemyBehavior>().isAttacking)
            {
                StartCoroutine(other.GetComponent<EnemyBehavior>().Attack());
            }
        }
    }

    public void AddHealth(float amount)
    {
        health = Mathf.Clamp(health + amount, 0, maxHealth);
        healthBar.value = health;
        healthText.text = health + "/" + maxHealth;

        if(health <= 0)
        {
            GameManager.Instance.win = false;
            SceneManager.LoadScene("End");
        }
    }

}
