using UnityEngine;

public class Bola : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private float increaseSpeed = 0.5f;

    [SerializeField]
    private float maxSpeed = 20f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Lançar a bola em direção aleatória
        float x = Random.value > 0.5f ? -1 : 1;
        float y = Random.Range(-0.5f, 0.5f);

        rb.linearVelocity = new Vector2(x, y).normalized * speed;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = rb.linearVelocity.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            speed += increaseSpeed; //Aumentar velocidade ao bater na Raquete
            if (speed > maxSpeed) //Limitar a velocidade
            {
                speed = maxSpeed;
            }

            //Descobrir ponto de contato da Bola
            float impactoY = transform.position.y - collision.transform.position.y;
            //Definir a direção onde a Bola vai ser impulsionada
            float directionX = collision.gameObject.CompareTag("Player") ? 1 : -1;
            //Criar uma nova direção
            Vector2 direction = new Vector2(directionX, impactoY).normalized;
            //Aplicar a nova velocidade
            rb.linearVelocity = direction * speed;
        }
    }
}