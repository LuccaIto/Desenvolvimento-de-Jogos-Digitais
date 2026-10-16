using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public static int Score = 0; 
    public static int Vidas = 3; 

    public GUISkin layout;
    
    [Header("Interface Gráfica")]
    public Texture2D iconeVida; 

    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // ADICIONADO: Verifica constantemente se a condição de vitória foi atingida
    void Update()
    {
        // Conta todos os objetos com a tag "Inimigo"
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");
        
        // Se a quantidade de inimigos for 0, carrega a CenaVitoria
        if (inimigos.Length == 0) 
        {
            SceneManager.LoadScene("CenaVitoria"); // Transição de cena[cite: 4]
        }
    }

    public static void MarcarPonto(int pontosGanhos) {
        Score += pontosGanhos;
    }

    public static void PerderVida() {
        Vidas--;

        // MODIFICADO: Em vez de apenas destruir o jogador, carrega a cena de derrota
        if (Vidas <= 0)
        {
            SceneManager.LoadScene("CenaDerrota"); // Transição de cena[cite: 4]
        }
    }

    public static void InvasaoDetectada() {
        Vidas = 0; 
        
        // MODIFICADO: Se os alienígenas tocarem no chão, muda para derrota direto
        SceneManager.LoadScene("CenaDerrota"); // Transição de cena[cite: 4]
    }

    void OnGUI () {
        if (layout != null) GUI.skin = layout;
        
        // PONTOS 
        GUI.Label(new Rect(20, 20, 200, 50), "PONTOS: " + Score);

        // VIDAS (Ícones)
        if (iconeVida != null && Vidas > 0)
        {
            int tamanhoIcone = 30;  
            int espacamento = 10;   
            int margemTopo = 20;    
            int margemDireita = 20; 

            int larguraTotal = (Vidas * tamanhoIcone) + ((Vidas - 1) * espacamento);
            int startX = Screen.width - margemDireita - larguraTotal;

            for (int i = 0; i < Vidas; i++)
            {
                GUI.DrawTexture(new Rect(startX + (i * (tamanhoIcone + espacamento)), margemTopo, tamanhoIcone, tamanhoIcone), iconeVida);
            }
        }
        else if (iconeVida == null)
        {
            GUI.Label(new Rect(Screen.width - 150, 20, 150, 50), "VIDAS: " + Vidas);
        }

        // A TELA DE GAME OVER FOI APAGADA DAQUI! 
        // Em vez de desenhar botões aqui, o jogo agora muda para a "CenaDerrota" onde teremos um menu dedicado.
    }
}