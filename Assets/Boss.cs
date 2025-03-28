using UnityEngine;

public class Boss : MonoBehaviour
{
    public float maxHealth = 600f; // เลือดสูงสุดของบอส
    private float currentHealth; // เลือดปัจจุบันของบอส

    void Start()
    {
        currentHealth = maxHealth; // กำหนดค่าของเลือด
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // ลดเลือดของบอส
        if (currentHealth <= 0)
        {
            Die(); // ถ้าเลือดหมดให้บอสตาย
        }
    }

    void Die()
    {
        // เพิ่มการทำงานเมื่อบอสตาย เช่น ทำลายบอสหรือทำให้เกมจบ
        Debug.Log("Boss is dead!");
        Destroy(gameObject); // ทำลายบอส
    }
}
