using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    private bool facingRight = true;

    public Transform spriteTransform; // hijo con SpriteRenderer
    public Transform firePoint;

    public Sprite idleSprite;
    public Sprite movingSprite;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Cambiar sprite según movimiento
        if (movement != Vector2.zero)
        {
            spriteRenderer.sprite = movingSprite;
        }
        else
        {
            spriteRenderer.sprite = idleSprite;
        }

        // Girar sprite si cambia de dirección
        if (movement.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (movement.x < 0 && facingRight)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        facingRight = !facingRight;

        // Voltear visualmente el sprite
        Vector3 scale = spriteTransform.localScale;
        scale.x *= -1;
        spriteTransform.localScale = scale;

        // Voltear también el punto de disparo
        firePoint.Rotate(0f, 180f, 0f);
    }
}
