using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;
    protected Rigidbody2D rb;
    
    // Variável protegida: os filhos podem ver e modificar, mas outros scripts não.
    protected float direcaoY = 1f; 

    // 'virtual' permite que os filhos usem ou modifiquem este Start se precisarem
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; 
        
        // Aplica o movimento: 1 para cima (Player), -1 para baixo (Inimigo)
        var vel = rb.linearVelocity;
        vel.y = speed * direcaoY; 
        rb.linearVelocity = vel; 
        
        Destroy(gameObject, 3.0f); // Destrói após 3 segundos
    }
}
