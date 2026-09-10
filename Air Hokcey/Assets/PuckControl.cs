using UnityEngine;

public class PuckControl : MonoBehaviour
{
    private Rigidbody2D rb2d;      // Define o corpo rigido 2D que representa a bola

    // inicializa a bola randomicamente para esquerda ou direita
    void GoPuck(){                      
        float rand = Random.Range(0, 2);
        if(rand < 1){
            rb2d.AddForce(new Vector2(40, -30));
        } else {
            rb2d.AddForce(new Vector2(-40, -30));
        }
    }

    // Determina o comportamento da bola nas colisões com os Players (raquetes)
    void OnCollisionEnter2D (Collision2D coll) {
        if(coll.collider.CompareTag("Player")){
            Vector2 vel;
            vel.x = rb2d.linearVelocity.x;
            vel.y = (rb2d.linearVelocity.y / 2) + (coll.collider.attachedRigidbody.linearVelocity.y / 3);
            rb2d.linearVelocity = vel;
        }
    }

    // Reinicializa a posição e velocidade da bola
    void ResetPuck(){
        rb2d.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    // Reinicializa o jogo
    void RestartGame(){
        ResetPuck();
        Invoke("GoPuck", 1);
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa o objeto bola
        Invoke("GoPuck", 2);    // Chama a função GoBall após 2 segundos
   
    }

    // Update is called once per frame
    void Update(){
        
    }
}