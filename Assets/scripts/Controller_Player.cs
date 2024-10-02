using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller_Player : MonoBehaviour
{
    

    public float speed = 5;
    private Rigidbody rb;
    public static bool lastKeyUp;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public virtual void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        Movement();
    }
    private void Movement()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(speed * inputX, speed * inputY);
        rb.velocity = movement;
        if (Input.GetKey(KeyCode.W))
        {
            lastKeyUp = true;
        }
        else
        if (Input.GetKey(KeyCode.S))
        {
            lastKeyUp = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            speed = 20f;
            Destroy(collision.gameObject);  // Destruye el objeto de boost
        }
    }
}


