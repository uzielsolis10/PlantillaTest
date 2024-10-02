using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab; // El prefab que deseas spawnear
    public Transform spawnPoint; // Punto de spawn (puedes arrastrar un objeto vac�o en la escena)    

    public float timer = 10f;

    void Update()
    {
        // Actualiza el temporizador en funci�n del tiempo transcurrido
        timer -= Time.deltaTime;

        // Si han pasado 10 segundos (o el valor definido en spawnInterval)
        if (timer < 0)
        {
            SpawnPrefab(); // Spawnea el prefab
            timer = 10f;    // Reinicia el temporizador
        }
    }

    void SpawnPrefab()
    {
        // Instancia el prefab en la posici�n y rotaci�n del spawnPoint
        Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
    }
}
