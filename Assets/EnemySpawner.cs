using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bossPrefab; // เพิ่มตัวแปรสำหรับบอส
    public float spawnRate = 2f;
    public float spawnRange = 8f;
    public float stopSpawningTime = 5f; // เวลาที่จะหยุดการเกิดศัตรู
    public Vector3 bossSpawnPosition = new Vector3(0, 0, 80); // ตำแหน่งเกิดบอส

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnRate);
        Invoke("StopSpawning", stopSpawningTime); // หยุดเกิดศัตรูหลังจาก stopSpawningTime วินาที
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPosition = new Vector3(randomX, 0, 60);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0, 180, 0));
    }

    void StopSpawning()
    {
        CancelInvoke("SpawnEnemy"); // หยุดการเรียกฟังก์ชัน SpawnEnemy
        Debug.Log("Enemy spawning stopped! Boss incoming...");
        Invoke("SpawnBoss", 3f); // รอ 3 วินาทีแล้วเกิดบอส
    }

    void SpawnBoss()
    {
        Instantiate(bossPrefab, bossSpawnPosition, Quaternion.identity);
        Debug.Log("Boss has arrived!");
    }
}
