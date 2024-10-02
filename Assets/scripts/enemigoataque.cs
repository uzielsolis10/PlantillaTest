using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoataque : MonoBehaviour


{
    public float vidaMaxima = 100f;
    public float vidaActual;

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDanio(float cantidad)
    {
        vidaActual -= cantidad;
        Debug.Log("Jugador recibió daño: " + cantidad);

        if (vidaActual <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        Debug.Log("El jugador ha muerto");
    }
}

    


