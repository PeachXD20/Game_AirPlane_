using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public GameObject explosionPrefab; // เอฟเฟกต์ระเบิด

    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // TODO: เรียกฟังก์ชัน Game Over แทนการลบผู้เล่นเลย
            GameManager.instance.GameOver();
        }
        if (other.CompareTag("Bullet"))
        {
            ScoreManager.instance.AddScore(10); // เพิ่มคะแนน

            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity); // เอฟเฟกต์ระเบิด
            }

            Destroy(gameObject); // ทำลายศัตรู
            Destroy(other.gameObject); // ทำลายกระสุน
        }
    }
}
