using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cañon : MonoBehaviour
{
  
    public GameObject projectilePrefab; 
    public Transform spawnPoint; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

    

