using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // ใช้สำหรับการจัดการฉาก

public class GameManager : MonoBehaviour
{
    public static GameManager instance;  // ตัวแปร static ที่จะใช้เข้าถึง GameManager จากที่อื่น
    public Text scoreText;  // UI Text ที่แสดงคะแนน
    public Text highScoreText;  // UI Text ที่แสดงคะแนนสูงสุด

    private int score = 0;  // คะแนนปัจจุบัน
    private int highScore = 0;  // คะแนนสูงสุด

    void Awake()
    {
        // ตรวจสอบให้แน่ใจว่า GameManager มีแค่ตัวเดียว
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // ทำให้ GameManager อยู่ระหว่างการเปลี่ยนฉาก
        }
        else
        {
            Destroy(gameObject);
        }

        LoadScore();  // โหลดคะแนนสูงสุดจาก PlayerPrefs เมื่อเริ่มเกม
    }

    // ฟังก์ชันเพิ่มคะแนนและตรวจสอบคะแนนสูงสุด
    public void AddScore(int amount)
    {
        score += amount;

        // ถ้าคะแนนปัจจุบันมากกว่าคะแนนสูงสุด ให้ปรับคะแนนสูงสุด
        if (score > highScore)
        {
            highScore = score;
        }

        UpdateScoreText();  // อัปเดต UI ให้แสดงคะแนนและคะแนนสูงสุด
    }

    // ฟังก์ชันอัปเดต UI คะแนน
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    // ฟังก์ชันบันทึกคะแนนสูงสุด
    public void SaveScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);  // บันทึกคะแนนสูงสุดลงใน PlayerPrefs
        PlayerPrefs.Save();  // บันทึกข้อมูลทั้งหมด
    }

    // ฟังก์ชันโหลดคะแนนสูงสุดจาก PlayerPrefs
    public void LoadScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);  // โหลดคะแนนสูงสุด (ถ้าไม่มีก็ให้เป็น 0)
        UpdateScoreText();  // อัปเดต UI คะแนน
    }

    // ฟังก์ชันที่ทำงานเมื่อเกมจบ
    public void GameOver()
    {
        // หยุดเวลาของเกม
        Time.timeScale = 0f;  // เกมจะหยุดนิ่ง

        // บันทึกคะแนนเมื่อเกมจบ
        SaveScore();

        // แสดงข้อความ Game Over หรือแสดง UI เกมจบ
        Debug.Log("Game Over! Final Score: " + score);

        // ตัวอย่าง: ถ้าต้องการโหลดฉากเกมจบ
        // SceneManager.LoadScene("GameOverScene");
    }
}
