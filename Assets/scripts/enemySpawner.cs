using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3f;
    public int enemiesPerWave = 3;
    public float minSpawnDistance = 10f;
    public float maxSpawnDistance = 18f;

    private float timer;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            for (int i = 0; i < enemiesPerWave; i++)
            {
                Vector2 spawnPos = GetValidSpawnPosition();
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            }
            timer = 0f;
        }
    }

    Vector2 GetValidSpawnPosition()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        float distance = Random.Range(minSpawnDistance, maxSpawnDistance);
        return (Vector2)player.position + randomDirection * distance;
    }
}