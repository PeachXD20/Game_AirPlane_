using UnityEngine;

public class SoundGun : MonoBehaviour
{
    // สร้างตัวแปร AudioSource เพื่อเก็บการเล่นเสียง
    private AudioSource gunAudioSource;

    // ตัวแปรเก็บเสียงปืน
    public AudioClip gunShotSound;

    void Start()
    {
        // หา Component AudioSource จาก GameObject นี้
        gunAudioSource = GetComponent<AudioSource>();

        // กำหนดว่าให้เสียงที่เล่นไปมาจากไฟล์เสียงปืนที่กำหนด
        gunAudioSource.clip = gunShotSound;
    }

    void Update()
    {
        // เมื่อกดปุ่ม Spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // เรียกฟังก์ชั่น Play เพื่อเล่นเสียงปืน
            PlayGunShotSound();
        }
    }

    // ฟังก์ชั่นเล่นเสียงปืน
    private void PlayGunShotSound()
    {
        // ตรวจสอบว่า AudioSource พร้อมเล่นหรือไม่ และเล่นเสียงปืน
        if (gunAudioSource != null)
        {
            gunAudioSource.Play();
        }
    }
}