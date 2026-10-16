using UnityEngine;
using UnityEngine.SceneManagement;

public class CenaDerrota : MonoBehaviour
{
    [Header("Configurações da Tela")]
    public string mensagemPrincipal = "YOU LOSE!";
    public GUISkin layout;

    void OnGUI()
    {
        if (layout != null) GUI.skin = layout;

        // Desenha a mensagem principal no centro
        GUI.Label(new Rect(Screen.width / 2 - 20, Screen.height / 2 - 140, 400, 60), mensagemPrincipal);
        
        // Desenha a pontuação final
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 120, 200, 50), "PONTOS FINAIS: " + GameManager.Score);

        // Desenha o botão de reiniciar
        if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 + 180, 120, 53), "RESTART"))
        {
            GameManager.Score = 0;
            GameManager.Vidas = 3;
            Time.timeScale = 1.0f; 
            SceneManager.LoadScene("SampleScene");
        }
    }
}