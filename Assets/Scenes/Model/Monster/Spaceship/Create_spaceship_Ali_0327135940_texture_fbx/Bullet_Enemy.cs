using UnityEngine;

public class Bullet_Enemy : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // กระสุนจะเคลื่อนที่ไปข้างหน้า
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject); // ทำลายผู้เล่น
            Destroy(gameObject, 3f); // ทำลายกระสุน
        }
    }
}
