using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject); // ทำลายผู้เล่น
            Destroy(gameObject); // ทำลายศัตรู
        }
        if (other.CompareTag("Bullet"))
        {
            ScoreManager.instance.AddScore(10); // เพิ่มคะแนน 10
        }
    }
}
