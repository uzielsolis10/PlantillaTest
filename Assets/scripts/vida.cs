using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Necesario para trabajar con TextMeshPro

public class PlayerHealthTMP : MonoBehaviour
{
    public int playerHealth = 100;
    public TextMeshProUGUI healthText; // Referencia al texto de TextMeshPro UI
    private Vector3 initialPosition;

    void Start()
    {
        UpdateHealthText();
        initialPosition = transform.position;
    }
    public virtual void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemi"))
        {
            playerHealth -= 20;
            UpdateHealthText();
            transform.position = initialPosition;
            if (playerHealth <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Debug.Log("Game Over");

            }
            else
            {

            }
        }
    }
    void UpdateHealthText()
    {
        healthText.text = "Vida del Jugador: " + playerHealth.ToString();
    }
}

