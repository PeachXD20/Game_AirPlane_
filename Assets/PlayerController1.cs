using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform firePoint2;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        transform.position += new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }

    }

    private float fireRate = 0.5f; // ความเร็วในการยิง (ยิงทุก 0.2 วิ)
    private float nextFireTime = 0.5f;

    void Shoot()

    {
        if (Time.time >= nextFireTime)
        {
            GameObject Bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            GameObject Bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
            nextFireTime = Time.time + fireRate; // อัปเดตเวลายิงครั้งถัดไป
            Destroy(Bullet , 3);
            Destroy(Bullet2, 3);
        }

    }

}

