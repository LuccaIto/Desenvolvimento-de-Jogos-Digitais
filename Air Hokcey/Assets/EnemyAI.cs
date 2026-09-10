using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 12f;
    private Rigidbody2D rb2d;
    private Transform puck;

    // Limites ajustados com margem das paredes
    public float minY = 0.5f;   
    public float maxY = 4.5f;   
    public float minX = -12.0f; 
    public float maxX = 3.5f;   // Reduzido levemente para a mallet não colar na parede da direita

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
        GameObject puckObject = GameObject.FindGameObjectWithTag("puck");
        if (puckObject != null)
        {
            puck = puckObject.transform;
        }
    }

    void Update()
    {
        if (puck == null) return;

        Vector2 targetPos = transform.position;

        if (puck.position.y > 0)
        {
            // DETECÇÃO DE CANTO: Se a bolinha estiver muito no canto/parede
            bool puckInCorner = (puck.position.x > maxX - 0.5f || puck.position.x < minX + 0.5f);

            if (puckInCorner)
            {
                // Em vez de ir direto no canto, a IA recua em X e Y para dar espaço e fazer curva de impacto
                float offsetX = (puck.position.x > 0) ? -1.0f : 1.0f; 
                targetPos = new Vector2(puck.position.x + offsetX, puck.position.y + 0.8f);
            }
            else
            {
                // Ataque padrão com pequeno recuo para bater de cima para baixo
                targetPos = new Vector2(puck.position.x, puck.position.y + 0.4f);
            }
        }
        else
        {
            // Posição defensiva
            targetPos = new Vector2(0f, (minY + maxY) / 2f);
        }

        // Aplica os limites de segurança
        targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
        targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

        // Movimento
        Vector2 currentPos = transform.position;
        Vector2 newPos = Vector2.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);

        if (Time.deltaTime > 0)
        {
            rb2d.linearVelocity = (newPos - currentPos) / Time.deltaTime;
        }

        transform.position = newPos;
    }
}