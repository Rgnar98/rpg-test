using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int startingHealth = 25;  // Vida inicial del enemigo
    public int startingDamage = 3;  // Daño inicial del enemigo

    private int currentHealth;  // Vida actual del enemigo
    public int attackDamage;  // Daño actual del enemigo

    private void Start()
    {
        InitializeEnemy();
    }

    private void InitializeEnemy()
    {
        currentHealth = startingHealth;
        attackDamage = startingDamage;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Aquí puedes agregar cualquier lógica adicional cuando el enemigo muere
        Debug.Log("El enemigo ha muerto");
    }
}