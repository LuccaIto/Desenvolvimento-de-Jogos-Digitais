using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public static int Score = 0; 
    public static int Vidas = 3; 

    public GUISkin layout;
    
    [Header("Interface Gráfica")]
    // Variável para colocar a imagem da vida no Inspector
    public Texture2D iconeVida; 

    void Start()
    {
        Time.timeScale = 1.0f;
    }

    public static void MarcarPonto(int pontosGanhos) {
        Score += pontosGanhos;
    }

    public static void PerderVida() {
        Vidas--;

        if (Vidas <= 0)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                Destroy(player);
            }
        }
    }

    public static void InvasaoDetectada() {
        Vidas = 0; 
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Destroy(player);
        }
    }

    void OnGUI () {
        if (layout != null) GUI.skin = layout;
        
        // PONTOS (Mantido no canto superior esquerdo)
        GUI.Label(new Rect(20, 20, 200, 50), "PONTOS: " + Score);

        // VIDAS (Desenhadas como imagens no canto superior direito)
        if (iconeVida != null && Vidas > 0)
        {
            int tamanhoIcone = 30;  // Largura e altura de cada ícone
            int espacamento = 10;   // Espaço entre as imagens
            int margemTopo = 20;    // Distância do topo da tela
            int margemDireita = 20; // Distância da lateral direita da tela

            // Calcula a largura total para alinhar tudo corretamente à direita
            int larguraTotal = (Vidas * tamanhoIcone) + ((Vidas - 1) * espacamento);
            int startX = Screen.width - margemDireita - larguraTotal;

            // Desenha a imagem X vezes (dependendo de quantas vidas o jogador tem)
            for (int i = 0; i < Vidas; i++)
            {
                GUI.DrawTexture(new Rect(startX + (i * (tamanhoIcone + espacamento)), margemTopo, tamanhoIcone, tamanhoIcone), iconeVida);
            }
        }
        else if (iconeVida == null)
        {
            // Fallback: se esquecer de colocar a imagem no Inspector, mostra em texto
            GUI.Label(new Rect(Screen.width - 150, 20, 150, 50), "VIDAS: " + Vidas);
        }

        // TELA DE GAME OVER
        if (Vidas <= 0)
        {
            Time.timeScale = 0.0f;

            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 300, 100), "GAME OVER");
            
            if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 + 50, 120, 53), "RESTART"))
            {
                Score = 0;
                Vidas = 3;
                Time.timeScale = 1.0f; 
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}