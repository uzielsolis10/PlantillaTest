using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Para mostrar la vida en pantalla

public class EnemigoSeguir : MonoBehaviour

{
    public Transform objetivo; // El jugador u objeto que el enemigo seguir�
    public float velocidad = 5f;
    public float distanciaDeParada = 1.5f;

    public int vida = 100; // Vida del enemigo
    public Slider barraDeVida; // Referencia a la barra de vida en la UI

    void Update()
    {
     

        // Verifica si el objetivo es nulo antes de calcular la distancia
        if (objetivo != null)
        {
            float distanciaAlObjetivo = Vector3.Distance(transform.position, objetivo.position);

            if (distanciaAlObjetivo > distanciaDeParada)
            {
                // Calcular la direcci�n hacia el objetivo
                Vector3 direccion = (objetivo.position - transform.position).normalized;

                // Mover al enemigo hacia el objetivo
                transform.position += direccion * velocidad * Time.deltaTime;

                // Hacer que el enemigo mire al objetivo
                transform.LookAt(objetivo);
            }
        }
        else
        {
            // Opcional: Puedes manejar el caso cuando el objetivo es nulo (ej. detener al enemigo)
            // Puedes destruir el enemigo o detener su movimiento
            // Destroy(gameObject); // Si decides destruirlo
        }
    }



// M�todo para recibir da�o
public void RecibirDanio(int danio)
    {
        vida -= danio;

        // Si la vida llega a 0, el enemigo muere
        if (vida <= 0)
        {
            Morir();
        }
    }

    // M�todo para "morir"
    void Morir()
    {
        // Aqu� podr�as agregar animaciones o efectos de destrucci�n
        Destroy(gameObject); // Destruir el enemigo cuando su vida sea 0
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si colisiona con el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destruir el jugador
            Destroy(collision.gameObject);
            // Reiniciar la escena
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Clase interna para la bala
    public class Bala : MonoBehaviour
    {
        public int danio = 20;

        private void OnCollisionEnter(Collision collision)
        {
            EnemigoSeguir enemigo = collision.gameObject.GetComponent<EnemigoSeguir>();

            if (enemigo != null)
            {
                enemigo.RecibirDanio(danio);
            }

            // Destruir la bala despu�s de colisionar
            Destroy(gameObject);
        }
    }
}
