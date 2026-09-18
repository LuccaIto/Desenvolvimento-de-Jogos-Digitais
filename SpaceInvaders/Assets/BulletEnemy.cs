using UnityEngine;

// Herda de Bullet também
public class BulletEnemy : Bullet
{
    void Awake()
    {
        // Definimos a direção para BAIXO (-1).
        direcaoY = -1f; 
    }

    void OnTriggerEnter2D(Collider2D coll) 
    {
        // O tiro do inimigo SÓ se importa em bater no jogador
        if (coll.CompareTag("Player"))
        {
            GameManager.PerderVida(); 
            Destroy(gameObject);
        }
        else if (coll.CompareTag("ParedeInferior"))
        {
            Destroy(gameObject);
        }
    }
}