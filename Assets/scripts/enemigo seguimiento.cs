using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Para mostrar la vida en pantalla(no utilizado)

public class EnemigoSeguir : MonoBehaviour

{
    public Transform objetivo; // para seleccionar a que va a seguir 
    public float velocidad = 5f;
    public float distanciaDeParada = 1.5f;

    public int vida = 100; 
    public Slider barraDeVida; // Referencia a la barra de vida en la UI(tampoco lo use)

    void Update()
    {
     
        if (objetivo != null)
        {
            float distanciaAlObjetivo = Vector3.Distance(transform.position, objetivo.position);

            if (distanciaAlObjetivo > distanciaDeParada)
            {
                Vector3 direccion = (objetivo.position - transform.position).normalized;

                // esto es para mover a la direccion
                transform.position += direccion * velocidad * Time.deltaTime;

                transform.LookAt(objetivo);
            }
        }
      
    }



//no lo use este codigo
//public void RecibirDanio(int danio)
//    {
//        vida -= danio;

//        
//        if (vida <= 0)
//        {
//            Morir();
//        }
//    }

//    // Método para morir
//    void Morir()
//    {
//       
//        Destroy(gameObject); 
//    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Destroy(collision.gameObject);
            // Reinicia
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
