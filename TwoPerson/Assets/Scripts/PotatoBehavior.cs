using UnityEngine;
using UnityEngine.UI;

public class PotatoBehavior : MonoBehaviour
{
    [SerializeField] private Slider healthBar;

    [SerializeField] private float maxHealth;
    [SerializeField] private float health;

    void Start()
    {
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddHealth(float amount)
    {
        health = Mathf.Clamp(health + amount, 0, maxHealth);
        healthBar.value = health;
    }

}
