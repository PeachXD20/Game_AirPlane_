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
                other.GetComponent<PlayerController>().TakeDamage(10f); // ลดเลือด 200
                Destroy(gameObject); // ทำลายกระสุน
            }
        }

        // ตรวจสอบว่ากระสุนชนกับศัตรู
        if (other.CompareTag("Enemy") || other.CompareTag("Boss"))
        {
            if (other.CompareTag("Boss")) // ถ้าเป็นบอส
            {
                other.GetComponent<Boss>().TakeDamage(20f); // ลดเลือดบอส 100
            }

            Destroy(gameObject); // ทำลายกระสุน
        }
    }
}
