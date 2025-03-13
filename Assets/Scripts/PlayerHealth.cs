using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public Slider healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        
    }
        public void TakeDamage()
    {
        currentHealth -= 1;
        healthBar.value = currentHealth;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
        void Die()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
