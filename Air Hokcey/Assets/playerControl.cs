using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb2d;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float minY = -4.5f; // Limite inferior (ajuste conforme o seu cenário)
    public float maxY = -0.5f; // Limite superior (se for o player 1, metade inferior da quadra)
    public float minX = -12.0f; // Limite esquerdo
    public float maxX = 4.0f;  // Limite direito
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // Aplica os limites diretamente na posição desejada do mouse antes de mover
        mousePos.x = Mathf.Clamp(mousePos.x, minX, maxX);
        mousePos.y = Mathf.Clamp(mousePos.y, minY, maxY);

        var pos = transform.position;
        pos.x = mousePos.x;
        pos.y = mousePos.y;
        transform.position = pos;

        Vector3 playerPos = transform.position;

        Vector3 dir = mousePos - playerPos;
        dir.Normalize();

        Vector3 speedVec = dir * speed;

        var vel = rb2d.linearVelocity;
        vel.x = speedVec.x;
        vel.y = speedVec.y;
        rb2d.linearVelocity = vel; 
    }
}