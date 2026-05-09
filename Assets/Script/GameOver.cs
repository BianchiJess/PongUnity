using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public string winner;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            gameObject.SetActive(false); //Desativa a bola
            gameOverText.gameObject.SetActive(true); //Ativar o texto
            gameOverText.text = $"Parabéns! {winner} wins!";
            Time.timeScale = 0f; //Pausa o jogo
        }
    }
}
