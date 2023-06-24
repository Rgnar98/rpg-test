using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnBasedCombat : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    private bool isPlayerTurn = true;
    private bool isPlayerActionDone = false;

    private void Start()
    {
      StartCombat();
    }

    private void StartCombat()
    {
        Debug.Log("Comienza el combate!");

          // Obtener referencia al componente Button
          Button attackButton = GetComponent<Button>();

          // Verificar si se encontró el componente Button
          if (attackButton != null)
          {
              // Escuchar el evento onClick del botón
              attackButton.onClick.AddListener(AttackButtonClicked);
          }
          else
          {
              Debug.LogError("El componente Button no se encontró en el objeto actual.");
          }

        // Iniciar la rutina de combate
        StartCoroutine(CombatRoutine());
    }

    private System.Collections.IEnumerator CombatRoutine()
    {
        while (true)
        {
            if (isPlayerTurn)
            {
                yield return WaitForPlayerAction();

                // Attack(player, enemy);

                if (IsDefeated(enemy))
                {
                    Debug.Log("¡Enemigo derrotado! ¡Victoria!");
                    break;
                }

                isPlayerTurn = false;
            }
            else
            {
                Attack(enemy, player);

                if (IsDefeated(player))
                {
                    Debug.Log("¡El jugador ha sido derrotado! ¡Derrota!");
                    break;
                }

                isPlayerTurn = true;
            }

            yield return null;
        }
    }

  private System.Collections.IEnumerator WaitForPlayerAction()
  {
         // Esperar hasta que el jugador realice una acción (pulsar el botón de ataque en la UI)
      isPlayerActionDone = false;

      // Mientras el jugador no haya realizado la acción, esperar en un bucle
      while (!isPlayerActionDone)
      {
          yield return null;
      }

      // El jugador ha realizado la acción (pulsó el botón de ataque)
      isPlayerActionDone = false; // Reiniciar la variable de control para futuras acciones del jugador
  }

  private void AttackButtonClicked()
    {
        if (isPlayerTurn)
        {
            Attack(player, enemy);
            // Marcar la acción del jugador como completada
            isPlayerActionDone = true;
        }
    }


    private void Attack(GameObject attacker, GameObject target)
    {
        int damage = CalculateDamage(attacker);

        target.GetComponent<HealthSystem>().TakeDamage(damage);

        Debug.Log(attacker.name + " ataca a " + target.name + " y causa " + damage + " de daño.");
    }

    private int CalculateDamage(GameObject attacker)
    {
      // Aquí puedes implementar la lógica para calcular el daño del ataque.
      // Por ejemplo, puedes tener una estadística de ataque en el jugador y utilizarla en el cálculo.

      int attackStat = 10; // Ejemplo: estadística de ataque del jugador
      int baseDamage = 5; // Ejemplo: daño base del ataque

      int damage = attackStat + baseDamage;

      return damage;
    }

    private bool IsDefeated(GameObject character)
    {
        // Implementa la lógica de derrota aquí

        return false;
    }
}