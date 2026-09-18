using UnityEngine;

public class Naves : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    private float waitTime = 1.0f;
    private float speed = 2.0f;

    [Header("Configurações do Tiro")]
    public GameObject bulletPrefab; // O Prefab do projetil
    public int valorPontos = 10;
    private float shootTimer = 0.0f;
    private float nextShootTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();  

        var vel = rb2d.linearVelocity;
        vel.x = speed;
        rb2d.linearVelocity = vel;

        // Sorteia o tempo do primeiro tiro
        nextShootTime = Random.Range(2.0f, 6.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Lógica de movimento e mudança de direção
        timer += Time.deltaTime;
        if (timer >= waitTime){
            ChangeState();
            timer = 0.0f;
        }

        // Disparo de mísseis de forma aleatória
        shootTimer += Time.deltaTime;
        if (shootTimer >= nextShootTime)
        {
            Atirar();
            shootTimer = 0.0f;
            nextShootTime = Random.Range(3.0f, 10.0f); // Sorteia o intervalo para o próximo tiro
        }

    }

    void Atirar()
    {
        if (bulletPrefab != null)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }

    void ChangeState(){
        // Inverte a direção
        var vel = rb2d.linearVelocity;
        vel.x *= -1;
        rb2d.linearVelocity = vel;

        // Decrementa unidades no eixo Y a cada volta
        Vector3 pos = transform.position;
        pos.y -= 0.5f; 
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.CompareTag("ParedeInferior")){
            GameManager.InvasaoDetectada();
        }
    }

}
