using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller_Projectile : Projectile
{
    public float projectileSpeed;

    public Rigidbody rb;

    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }
    public int vida = 100;

    public void RecibirDanio(int danio)
    {
        vida -= danio;
        Debug.Log("Vida del jugador: " + vida);

        if (vida <= 0)
        {
            // Aquí puedes manejar lo que pasa cuando el jugador muere
            Destroy(gameObject);
            // También puedes reiniciar la escena si lo prefieres
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public override void Update()
    {
        ProjectileDirection();
        base.Update();
    }

    public virtual void ProjectileDirection()
    {
        rb.velocity = new Vector3(1 * projectileSpeed, rb.velocity.y, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemi"))
        {
            Destroy(collision.gameObject);
        }
    }
}
