using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab; // Prefab thiên thạch
    public float spawnRate = 2f;      // Thời gian spawn (giây)
    public Vector2 spawnAreaMin;      // Góc dưới cùng bên trái của vùng spawn
    public Vector2 spawnAreaMax;      // Góc trên cùng bên phải của vùng spawn
    private float timer = 0f;         // Bộ đếm thời gian spawn

    void Update()
    {
        timer += Time.deltaTime;

        // Spawn thiên thạch nếu đủ thời gian
        if (timer >= spawnRate)
        {
            SpawnAsteroid();
            timer = 0f;
        }
    }

    void SpawnAsteroid()
    {
        if (asteroidPrefab == null)
        {
            Debug.LogError("Asteroid Prefab chưa được gán trong Inspector!");
            return;
        }

        // Random vị trí trong vùng spawn
        float spawnX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float spawnY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);

        // Tạo thiên thạch tại vị trí spawn
        Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        // Vẽ vùng spawn trong Scene View để kiểm tra
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube((spawnAreaMin + spawnAreaMax) / 2f, spawnAreaMax - spawnAreaMin);
    }
}
