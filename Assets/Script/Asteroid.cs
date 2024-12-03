using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    public float fallSpeed = 2f; // Tốc độ rơi của thiên thạch

    void Update()
    {
        // Di chuyển thiên thạch xuống dưới (trục Y âm)
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        // Hủy thiên thạch khi nó rơi ra khỏi màn hình
        if (transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize - 1f)
        {
            Destroy(gameObject);
        }
    }
}
