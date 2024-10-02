using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Para mostrar la vida en pantalla

public class EnemigoSeguir : MonoBehaviour
{
    public Transform objetivo; // El jugador u objeto que el enemigo seguirá
    public float velocidad = 5f;
    public float distanciaDeParada = 1.5f;

    public int vida = 100; // Vida del enemigo
    public Slider barraDeVida; // Referencia a la barra de vida en la UI

    void Update()
    {
        // Actualizar la barra de vida
        if (barraDeVida != null)
        {
            barraDeVida.value = vida; // Asegúrate de que la barra de vida se actualice
        }

        // Verifica si el objetivo es nulo antes de calcular la distancia
        if (objetivo != null)
        {
            float distanciaAlObjetivo = Vector3.Distance(transform.position, objetivo.position);

            if (distanciaAlObjetivo > distanciaDeParada)
            {
                // Calcular la dirección hacia el objetivo
                Vector3 direccion = (objetivo.position - transform.position).normalized;

                // Mover al enemigo hacia el objetivo
                transform.position += direccion * velocidad * Time.deltaTime;

                // Hacer que el enemigo mire al objetivo
                transform.LookAt(objetivo);
            }
        }
    }

    public void RecibirDanio(int danio)
    {
        vida -= danio;

        if (vida <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Destroy(gameObject); // Destruir el enemigo cuando su vida sea 0
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si colisiona con el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Suponiendo que el jugador tiene un método para recibir daño
            Controller_Player playerController = collision.gameObject.GetComponent<Controller_Player>();
            if (playerController != null)
            {
                playerController.RecibirDanio(20); // Ajusta el daño según sea necesario
            }

            // Reiniciar la posición del jugador
            collision.gameObject.transform.position = Vector3.zero; // Cambia esto a la posición deseada
        }

        // Verifica si colisiona con un proyectil
        if (collision.gameObject.CompareTag("Proyectil"))
        {
            RecibirDanio(20); // Asumiendo que el proyectil hace 20 de daño
            Destroy(collision.gameObject); // Destruir el proyectil después de colisionar
        }
    }
}


