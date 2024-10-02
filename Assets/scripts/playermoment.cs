using System.Collections;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float boostDuration = 5f; // Duración 
    public float speedBoost = 2f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aplicar 
            StartCoroutine(ApplyPowerUp(other));

            // Destruir el objeto 
            Destroy(gameObject);
        }
    }

    private IEnumerator ApplyPowerUp(Collider player)
    {
        Controller_Player playerMovement = player.GetComponent<Controller_Player>();
        if (playerMovement != null)
        {
            Debug.Log("Power-up recogido, aumentando velocidad del jugador.");

            // Aumentar la velocidad del jugador
            playerMovement.speed *= speedBoost;

            // Esperar la duración del boost
            yield return new WaitForSeconds(boostDuration);

            // Restaurar la velocidad original
            playerMovement.speed /= speedBoost;

        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Power"))
        {
            Controller_Player playerMovement = collision.gameObject.GetComponent<Controller_Player>();
            if (playerMovement != null)
            {
                playerMovement.speed = 20f; // Aumenta la velocidad al colisionar con un objeto de tipo Power
                Destroy(collision.gameObject);  // Destruye el objeto de boost
            }
        }
    }
}


