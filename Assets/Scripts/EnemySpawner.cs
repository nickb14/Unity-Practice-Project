using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int initialEnemies = 5;

    void Awake()
    {
        Enemy.onEnemyHit += spawnEnemy;
    }

    void Start()
    {
        for (int i = 0; i < initialEnemies; i++)
            spawnEnemy();
    }

    void Onable()
    {
        Enemy.onEnemyHit += spawnEnemy;
    }

    void OnDisable()
    {
        Enemy.onEnemyHit -= spawnEnemy;
    }

    private void spawnEnemy()
    {
        Vector2 newPos = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
        Instantiate(enemy, newPos, Quaternion.identity);
    }
}
