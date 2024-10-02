using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeedPowerUp : MonoBehaviour
{
    public float speedBoost = 10f; // Aumento 
    public float duration = 5f; // Duración 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            StartCoroutine(GiveSpeedBoost(other.gameObject));
            Destroy(gameObject); // desaparece el Power up
        }
    }

    private IEnumerator GiveSpeedBoost(GameObject player)
    {
        Controller_Player playerMovement = player.GetComponent<Controller_Player>();

        if (playerMovement != null)
        {
            playerMovement.speed += speedBoost; // + velocidad
            yield return new WaitForSeconds(duration);
            playerMovement.speed -= speedBoost; // - velocidad al terminar 
        }
    }
}





