using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3f;
    public int enemiesPerWave = 3;
    public float spawnRadius = 8f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            for (int i = 0; i < enemiesPerWave; i++)
            {
                Vector2 spawnPos = (Vector2)transform.position + Random.insideUnitCircle.normalized * spawnRadius;
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            }
            timer = 0f;
        }
    }
}
