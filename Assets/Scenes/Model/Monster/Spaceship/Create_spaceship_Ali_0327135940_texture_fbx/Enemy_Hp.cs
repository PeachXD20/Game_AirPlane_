using UnityEngine;

public class Enemy_Hp : MonoBehaviour
{
    public float maxHealth = 20f;  // เลือดสูงสุดของศัตรู
    private float currentHealth;    // เลือดปัจจุบันของศัตรู

    void Start()
    {
        currentHealth = maxHealth; // กำหนดค่าเลือดเริ่มต้น
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // ลดเลือดของศัตรู
        if (currentHealth <= 0)
        {
            Die(); // ถ้าเลือดหมดให้ทำการตาย
        }
    }

    void Die()
    {
        Destroy(gameObject); // ทำลายศัตรูเมื่อเลือดหมด
    }

    // ฟังก์ชันอื่นๆ ของศัตรู
}
