using UnityEngine;
using UnityEngine.UI; // ใช้ UI สำหรับแถบเลือด

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public GameObject bulletPrefab; // กระสุนของศัตรู
    public Transform firePoint; // จุดที่กระสุนออก (สำหรับศัตรูทั่วไป)

    // จุดยิงเฉพาะบอส
    public Transform firePoint_Boss1;
    public Transform firePoint_Boss2;
    public Transform firePoint_Boss3;
    public Transform firePoint_Boss4;
    public Transform firePoint_Boss5;

    public float fireRate = 1f; // ความถี่ในการยิง
    private float nextFireTime = 0f;
    private Transform player; // ผู้เล่น
    private bool isBoss; // เช็คว่าเป็นบอสหรือไม่

    public float maxHealth = 20f; // เลือดสูงสุดของศัตรูทั่วไป
    private float currentHealth; // เลือดปัจจุบัน

    public Image healthBar; // แถบเลือด UI ของศัตรู

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        isBoss = CompareTag("Boss"); // ถ้าเป็นบอส ค่า isBoss = true

        // ถ้าเป็นบอส ให้เพิ่มเลือด
        if (isBoss)
        {
            maxHealth = 800f; // เลือดของบอสมากกว่าปกติ
        }
        currentHealth = maxHealth; // ตั้งค่าเลือดเริ่มต้น

        // อัปเดตแถบเลือดเริ่มต้น
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }

    void Update()
    {
        // เล็งไปที่ผู้เล่น
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.y = 0; // ป้องกันการหมุนขึ้นลง
            transform.rotation = Quaternion.LookRotation(direction);
        }

        transform.position += Vector3.back * speed * Time.deltaTime;

        // เช็คว่ายิงได้หรือยัง
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null)
        {
            if (!isBoss && firePoint != null)
            {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            }
            else if (isBoss)
            {
                if (firePoint_Boss1 != null) Instantiate(bulletPrefab, firePoint_Boss1.position, firePoint_Boss1.rotation);
                if (firePoint_Boss2 != null) Instantiate(bulletPrefab, firePoint_Boss2.position, firePoint_Boss2.rotation);
                if (firePoint_Boss3 != null) Instantiate(bulletPrefab, firePoint_Boss3.position, firePoint_Boss3.rotation);
                if (firePoint_Boss4 != null) Instantiate(bulletPrefab, firePoint_Boss4.position, firePoint_Boss4.rotation);
                if (firePoint_Boss5 != null) Instantiate(bulletPrefab, firePoint_Boss5.position, firePoint_Boss5.rotation);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // เรียก GameOver เมื่อผู้เล่นชนกับศัตรู
            if (GameManager.instance != null)
            {
                GameManager.instance.GameOver();
            }
        }
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(20); // กระสุนลดเลือด 20 หน่วย
            Destroy(other.gameObject); // ทำลายกระสุน

            // เพิ่มคะแนนเมื่อศัตรูถูกทำลาย
            if (GameManager.instance != null)
            {
                GameManager.instance.AddScore(100); // เพิ่มคะแนน 100
            }
        }
    }


    // ฟังก์ชันลดเลือด
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        // อัปเดตแถบเลือดทุกครั้งที่รับความเสียหาย
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }

    void Die()
    {
        if (isBoss)
        {
            Debug.Log("Boss Defeated!");
            // อาจจะให้เปลี่ยนไปฉากใหม่ หรือให้ไอเท็มพิเศษ
        }
        else
        {
            Debug.Log("Enemy Destroyed!");
        }

        Destroy(gameObject); // ลบตัวศัตรูหรือบอสออกจากเกม
    }
}
