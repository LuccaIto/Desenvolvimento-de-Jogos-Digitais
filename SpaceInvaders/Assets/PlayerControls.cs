using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public KeyCode moveLeft = KeyCode.A;      // Move a raquete para cima
    public KeyCode moveRight = KeyCode.D;    // Move a raquete para baixo
    public KeyCode shootKey = KeyCode.Space;
    public float speed = 5.0f;             // Define a velocidade da raquete
    public float boundX = 6.5f;            // Define os limites em X
    private Rigidbody2D rb2d;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject bulletPrefab;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.linearVelocity;                // Acessa a velocidade da raquete
        if (Input.GetKey(moveLeft)) {             // Velocidade da Raquete para ir para cima
            vel.x = -speed;
        }
        else if (Input.GetKey(moveRight)) {      // Velocidade da Raquete para ir para cima
            vel.x = speed;                    
        }
        else {
            vel.x = 0;                          // Velociade para manter a raquete parada
        }
        rb2d.linearVelocity = vel;                    // Atualizada a velocidade da raquete

        var pos = transform.position;           // Acessa a Posição da raquete
        if (pos.x > boundX) {                  
            pos.x = boundX;                     // Corrige a posicao da raquete caso ele ultrapasse o limite lateral
        }
        else if (pos.x < -boundX) {
            pos.x = -boundX;                    // Corrige a posicao da raquete caso ele ultrapasse o limite lateral
        }
        transform.position = pos;               // Atualiza a posição da raquete

        if (Input.GetKeyDown(shootKey))
        {
            Atirar();
        }

    }

    void Atirar()
    {
        if (bulletPrefab != null)
        {
            // Cria o tiro e não precisa configurar mais nada!
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}
