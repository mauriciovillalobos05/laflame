using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 3f;
    private Transform player;

    public Transform spriteTransform; // Asigna el GameObject hijo con el sprite
    private bool facingRight = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        // Movimiento hacia el jugador
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        // Ajuste para sprites que por defecto miran a la izquierda
        if (player.position.x > transform.position.x && facingRight)
        {
            Flip();
        }
        else if (player.position.x < transform.position.x && !facingRight)
        {
            Flip();
        }


    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = spriteTransform.localScale;
        scale.x *= -1;
        spriteTransform.localScale = scale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(1);
        }
    }
}
