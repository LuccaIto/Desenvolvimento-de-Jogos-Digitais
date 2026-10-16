
using UnityEngine;

public class PlayerController : MonoBehaviour{
    public float velocidade = 5f;
    public float forcaPulo = 12f;
    public float velocidadeEscada = 3f;

    private Rigidbody2D rb;
    private bool noChao;
    private bool naEscada;
    private float gravidadeOriginal;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        gravidadeOriginal = rb.gravityScale;
    }

    void Update(){
        float movimento = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (naEscada)
        {
            rb.gravityScale = 0f;

            rb.linearVelocity = new Vector2(
                movimento * velocidade,
                vertical * velocidadeEscada
            );

            return;
        }

        rb.gravityScale = gravidadeOriginal;

        rb.linearVelocity = new Vector2(
            movimento * velocidade,
            rb.linearVelocity.y
        );

        if (Input.GetButtonDown("Jump") && noChao){
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                forcaPulo
            );

            noChao = false;
        }
    }

    void OnTriggerEnter2D(Collider2D outro){
        if (outro.CompareTag("Escada")){
            naEscada = true;
            rb.gravityScale = 0f;
            rb.linearVelocity = Vector2.zero;
        }
    }

    void OnTriggerExit2D(Collider2D outro){
        if (outro.CompareTag("Escada")){
            naEscada = false;
            rb.gravityScale = gravidadeOriginal;

            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                0f
            );
        }
    }

    void OnCollisionStay2D(Collision2D colisao){
        foreach (ContactPoint2D contato in colisao.contacts){
            if (contato.normal.y > 0.5f)
            {
                noChao = true;
                return;
            }
        }
    }

    void OnCollisionExit2D(Collision2D colisao){
        noChao = false;
    }
}
