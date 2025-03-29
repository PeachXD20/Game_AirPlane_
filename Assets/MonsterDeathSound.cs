using UnityEngine;

public class MonsterDeathSound : MonoBehaviour
{

    public AudioClip deathSound; // ไฟล์เสียงที่ต้องการเล่นเมื่อมอนสเตอร์ตาย
    private AudioSource audioSource;

    void Start()
    {

        // เพิ่ม AudioSource ลงในตัวมอนสเตอร์ หากไม่มี
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // ไม่ให้เล่นเสียงอัตโนมัติ

    }

    public void PlayDeathSound()
    {

        if (deathSound != null)
        {
            audioSource.PlayOneShot(deathSound); // เล่นเสียงมอนสเตอร์ตาย
        }
        else
        {
            Debug.LogWarning("ไม่มีไฟล์เสียงสำหรับมอนสเตอร์ตาย!");
        }

     







    }
}
