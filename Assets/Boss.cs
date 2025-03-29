using UnityEngine;

public class Boss : MonoBehaviour
{
    public float maxHealth = 600f; // เลือดสูงสุดของบอส
    private float currentHealth; // เลือดปัจจุบันของบอส

    public AudioClip deathSound; // เสียงเมื่อบอสตาย
    private AudioSource audioSource; // AudioSource สำหรับเล่นเสียง

    void Start()
    {
        currentHealth = maxHealth; // กำหนดค่าของเลือด

        // เพิ่ม AudioSource ให้กับบอส
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // ปิดการเล่นอัตโนมัติ
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
        Debug.Log("Boss is dead!"); // แสดงข้อความใน Console

        if (deathSound != null)
        {
            audioSource.PlayOneShot(deathSound); // เล่นเสียงตายของบอส
            StartCoroutine(DieCoroutine()); // รอให้เสียงเล่นจนจบก่อนทำลายบอส
        }
        else
        {
            Destroy(gameObject); // ถ้าไม่มีเสียงให้ทำลายทันที
        }
    }

    System.Collections.IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(deathSound.length); // รอจนกว่าเสียงจะเล่นจบ
        Destroy(gameObject); // ทำลายบอสหลังเสียงจบ
    }
}
