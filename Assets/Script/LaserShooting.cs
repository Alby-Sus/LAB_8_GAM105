using UnityEngine;

public class LaserShooting : MonoBehaviour
{
    public GameObject laserPrefab; // Prefab của laser
    public float laserSpeed = 10f; // Tốc độ của laser
    public Transform firePoint; // Vị trí bắn laser (gắn vị trí nòng súng)

    void Update()
    {
        // Nhấn phím Space để bắn
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootLaser();
        }
    }

    void ShootLaser()
    {
        if (laserPrefab == null || firePoint == null)
        {
            Debug.LogError("Laser Prefab hoặc Fire Point chưa được gán!");
            return;
        }

        // Tạo laser tại vị trí bắn
        GameObject laser = Instantiate(laserPrefab, firePoint.position, Quaternion.identity);

        // Thêm vận tốc cho laser
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = transform.up * laserSpeed;
        }

        // Hủy laser sau 2 giây để tránh quá tải
        Destroy(laser, 2f);
    }
}
