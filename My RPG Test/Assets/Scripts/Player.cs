using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int startingHealth = 100;  // Vida inicial del jugador
    public int startingDamage = 10;  // Daño inicial del jugador

    private int currentHealth;  // Vida actual del jugador
    public int attackDamage;  // Daño actual del jugador

    private void Start()
    {
        InitializePlayer();
    }

    private void InitializePlayer()
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
        // Aquí puedes agregar cualquier lógica adicional cuando el jugador muere
        Debug.Log("El jugador ha muerto");
    }
}