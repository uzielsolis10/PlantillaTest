using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPoint : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("power"))
        {
            float speed = 18f; // Variable local
            Destroy(collision.gameObject);
            // Aquí puedes usar speed como necesites dentro de este método
        }
    }
}

