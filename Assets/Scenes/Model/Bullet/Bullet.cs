using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 40f;

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        // ตรวจสอบว่ากระสุนชนกับผู้เล่น
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("EnemyBullet"))
            {
                PlayerController playerController = other.GetComponent<PlayerController>(); // หา PlayerController
                if (playerController != null) // ตรวจสอบว่า PlayerController ไม่เป็น null
                {
                    playerController.TakeDamage(10f); // ลดเลือด 10
                }
                Destroy(gameObject); // ทำลายกระสุน
            }
        }

        // ตรวจสอบว่ากระสุนชนกับศัตรูหรือบอส
        if (other.CompareTag("Enemy") || other.CompareTag("Boss"))
        {
            if (other.CompareTag("Boss")) // ถ้าเป็นบอส
            {
                Boss boss = other.GetComponent<Boss>(); // หา Boss
                if (boss != null) // ตรวจสอบว่า Boss ไม่เป็น null
                {
                    boss.TakeDamage(20f); // ลดเลือดบอส 20
                    GameManager.instance.AddScore(500); // เพิ่มคะแนน 500 เมื่อบอสถูกทำลาย
                }
            }
            else if (other.CompareTag("Enemy"))
            {
                Enemy enemy = other.GetComponent<Enemy>(); // หา Enemy
                if (enemy != null) // ตรวจสอบว่า Enemy ไม่เป็น null
                {
                    enemy.TakeDamage(20f); // ลดเลือดศัตรูทั่วไป 20
                    GameManager.instance.AddScore(50); // เพิ่มคะแนน 50 เมื่อศัตรูถูกทำลาย
                }
            }

            Destroy(gameObject); // ทำลายกระสุน
        }
    }
}
