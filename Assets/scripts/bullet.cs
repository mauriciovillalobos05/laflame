using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
{
    Debug.Log("Bullet triggered with: " + other.name); // Ver si entra
    EnemyHealth enemy = other.GetComponent<EnemyHealth>();
    if (enemy != null)
    {
        Debug.Log("Enemy found: " + other.name);
        enemy.TakeDamage(damage);
    }
    else
    {
        Debug.Log("EnemyHealth component NOT found on: " + other.name);
    }

    Destroy(gameObject);
}
}
