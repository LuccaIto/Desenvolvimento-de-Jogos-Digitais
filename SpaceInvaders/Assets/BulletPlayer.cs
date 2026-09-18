using UnityEngine;

// Herda de Bullet: Já ganha a velocidade, o Rigidbody e o tempo de destruição automático
public class BulletPlayer : Bullet
{
    void Awake()
    {
        // O Awake roda antes do Start. Definimos a direção para CIMA (+1).
        direcaoY = 1f; 
    }

    void OnTriggerEnter2D(Collider2D coll) 
    {
        // O tiro do jogador SÓ se importa em bater no inimigo
        if (coll.CompareTag("Inimigo"))
        {
            Naves alien = coll.GetComponent<Naves>();
            if (alien != null) GameManager.MarcarPonto(alien.valorPontos);
            
            Destroy(coll.gameObject); // Destrói o alien
            Destroy(gameObject);      // Destrói o tiro
        }
        else if (coll.CompareTag("ParedeInferior"))
        {
            Destroy(gameObject);
        }
    }
}