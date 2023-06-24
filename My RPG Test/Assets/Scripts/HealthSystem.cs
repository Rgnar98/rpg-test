using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        Debug.Log(gameObject.name + " ha recibido " + damageAmount + " puntos de daño.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        Debug.Log(gameObject.name + " ha sido curado en " + healAmount + " puntos.");
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " ha sido derrotado.");

        // Aquí puedes implementar cualquier lógica adicional cuando el personaje muere, como reproducir una animación o desactivar el objeto.
    }
}