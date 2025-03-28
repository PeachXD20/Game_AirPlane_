using UnityEngine;
using UnityEngine.UI; // ใช้งาน UI

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform firePoint2;

    public float maxHealth = 100f; // ค่าเลือดสูงสุด
    private float currentHealth; // ค่าเลือดปัจจุบัน
    public Image healthBarImage; // UI ของแถบเลือด

    private float fireRate = 0.5f; // ความเร็วในการยิง
    private float nextFireTime = 0f; // เวลาที่ยิงได้ครั้งถัดไป

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        // การเคลื่อนที่
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        transform.position += new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;

        // ให้กด Space ค้างไว้แล้วยิงต่อเนื่อง
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        nextFireTime = Time.time + fireRate; // อัปเดตเวลายิงครั้งถัดไป
        GameObject Bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject Bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);

        Destroy(Bullet, 3);
        Destroy(Bullet2, 3);
    }

    // ฟังก์ชันลดเลือดเมื่อโดนโจมตี
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die(); // ตายเมื่อเลือดหมด
        }
        UpdateHealthBar();
    }

    // อัปเดต UI ของแถบเลือด
    void UpdateHealthBar()
    {
        if (healthBarImage != null)
        {
            healthBarImage.fillAmount = currentHealth / maxHealth;
        }
    }

    // ฟังก์ชันตาย
    void Die()
    {
        Debug.Log("Player has died!");
        Time.timeScale = 0f; // หยุดเกม

        // เรียก GameOver ได้ถ้าต้องการ
        // GameManager.instance.GameOver();
    }

    // เมื่อโดนกระสุนศัตรู
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet")) // ตรวจสอบว่าถูกยิงโดยกระสุนของศัตรู
        {
            TakeDamage(10); // ลดเลือด 10
            Destroy(other.gameObject); // ทำลายกระสุนศัตรู
        }
    }
}
