using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    public GameObject ui;
    public GameObject uiWinner; // เมนูชนะ
    public float maxHealth = 600f; // เลือดสูงสุดของบอส
    private float currentHealth; // เลือดปัจจุบันของบอส

    public AudioClip deathSound; // เสียงเมื่อบอสตาย
    private AudioSource audioSource; // AudioSource สำหรับเล่นเสียง

    void Start()
    {
        currentHealth = maxHealth; // กำหนดค่าของเลือด

                

       

        // เพิ่ม AudioSource ให้กับบอส
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
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
        Debug.Log("Boss is dead!");
        
        if (deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
            ui = Instantiate(uiWinner);
            
            StartCoroutine(DieCoroutine());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DieCoroutine()
    {

        yield return new WaitForSeconds(deathSound.length); // รอจนกว่าเสียงจะเล่นจบ
        Destroy(ui);

        Destroy(gameObject); // ทำลายบอสหลังเสียงจบ
    }
}