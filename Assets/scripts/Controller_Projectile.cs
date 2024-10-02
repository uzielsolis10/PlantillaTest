using UnityEngine;

public class Controller_Projectile : Projectile
{
    public float projectileSpeed;
    public int danio = 20; // Daño que inflige la bala

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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

    // Método para manejar la colisión
    internal override void OnCollisionEnter(Collision collision)
    {
        // Verifica si colisiona con el enemigo
        EnemigoSeguir enemigo = collision.gameObject.GetComponent<EnemigoSeguir>();
        if (enemigo != null)
        {
            enemigo.RecibirDanio(danio); // Inflige daño al enemigo
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }

        // Destruye la bala después de colisionar
        Destroy(gameObject);
    }
}

