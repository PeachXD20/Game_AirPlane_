using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    public static ScoreManager instance;

    public int enemyKillCount = 0;
    public int maxEnemyKills = 10; // ยิงครบ 10 ตัว บอสจะเกิด
    public GameObject bossPrefab;
    public Transform bossSpawnPoint;

    void Awake()
    {
        instance = this;
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;

        enemyKillCount++; // นับจำนวนศัตรูที่ถูกฆ่า

        if (enemyKillCount >= maxEnemyKills)
        {
            SpawnBoss();
        }
    }

    void SpawnBoss()
    {
        if (bossPrefab != null && bossSpawnPoint != null)
        {
            Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);
        }
    }
}
