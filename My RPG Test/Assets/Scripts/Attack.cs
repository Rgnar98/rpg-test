using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public Button attackButton;  // Referencia al botón de ataque en el sistema de Unity
    public int attackDamage = 10;  // Daño del ataque

    private GameObject enemy;  // Referencia al enemigo

    private void Start()
    {
        attackButton.onClick.AddListener(Attack);
    }

    private void Attack()
    {
        if (enemy != null)
        {
            // Aquí puedes agregar cualquier lógica adicional al ataque
            // Por ejemplo, aplicar daño al enemigo
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemy = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemy = null;
        }
    }
}
